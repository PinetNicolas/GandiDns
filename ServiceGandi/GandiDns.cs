using Api.Gandi;
using Api.Gandi.Domain.Api;
using Api.Gandi.Domain.Response;
using Api.Gandi.Record.Response;
using Api.Gandi.Zone.Api;
using Api.Gandi.Zone.Response;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using System.ServiceProcess;
using System.Threading.Tasks;

namespace ServiceGandi
{
    /// <summary>
    /// Service GandiDns
    /// </summary>
    public partial class GandiDns : ServiceBase
    {
        private string _domain;
        private string _apikey;
        private int _verifinterval;
        private int eventId = 1;

        /// <summary>
        /// DEfault constructor for designer
        /// </summary>
        public GandiDns()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Constructor with parameter
        /// </summary>
        /// <param name="domain">Domain name</param>
        /// <param name="apikey">api gandi key</param>
        /// <param name="verifinterval">Duration between 2 checks</param>
        public GandiDns(string domain, string apikey, string verifinterval) :this()
        {
            _domain = domain;
            _apikey = apikey;
            _verifinterval = Convert.ToInt32(verifinterval);
            eventLog1 = new System.Diagnostics.EventLog();
            if (!System.Diagnostics.EventLog.SourceExists("GandiDns"))
            {
                System.Diagnostics.EventLog.CreateEventSource(
                    "GandiDns", "Application");
            }
            eventLog1.Source = "GandiDns";
            eventLog1.Log = "Application";
#if DEBUG
            eventLog1.WriteEntry($"Start with Domain {_domain} and key {_apikey}", EventLogEntryType.Information, eventId++);
#endif
        }

        /// <summary>
        /// On start of service
        /// Create a timer that run check every minute
        /// </summary>
        /// <param name="args">args comming from system</param>
        protected override void OnStart(string[] args)
        {
            eventLog1.WriteEntry("In OnStart");
            // Set up a timer that triggers every minute.
            System.Timers.Timer timer = new System.Timers.Timer();
            timer.Interval = _verifinterval; // 60 seconds
            timer.Elapsed += new System.Timers.ElapsedEventHandler(this.OnTimer);
            timer.Start();
        }

        public void OnTimer(object sender, System.Timers.ElapsedEventArgs args)
        {
#if DEBUG
            eventLog1.WriteEntry($"OnTimer start", EventLogEntryType.Information, eventId++);
#endif
            //Read ip
            //https://api.ipify.org?format=json
            //https://api.myip.com
            //https://ip.seeip.org/jsonip?
            // brute
            //http://ipv4bot.whatismyipaddress.com/
            string ip = GetIPJson("https://api.ipify.org?format=json");
            if(string.IsNullOrEmpty(ip))
            {
                ip = GetIPJson("https://api.myip.com");
            }
            if (string.IsNullOrEmpty(ip))
            {
                ip = GetIPJson("https://ip.seeip.org/jsonip?");
            }
            if (string.IsNullOrEmpty(ip))
            {
                ip = GetIP("http://ipv4bot.whatismyipaddress.com/");
            }

#if DEBUG
            eventLog1.WriteEntry($"Ip find {ip}", EventLogEntryType.Information, eventId++);
#endif
            using (ManagerZone GandiZone = new ManagerZone("https://dns.api.gandi.net/api/v5/", _apikey))
            using (ManagerDomain GandiDomain = new ManagerDomain("https://dns.api.gandi.net/api/v5/", _apikey))
            {
                DomainDetailResponse rep= GandiDomain.GetDetail(_domain);
                if(rep.ErrorMessage != null)
                {
                    eventLog1.WriteEntry("Error occurs on getting domain :" + _domain + " \r\nError:" + rep.ErrorMessage.GetMessage(), EventLogEntryType.Error, eventId++);
                    return;
                }

                RecordListResponse rec = GandiZone.GetAllRecords(rep.Data.Domain.ZoneUuid);
                if (rec.ErrorMessage != null)
                {
                    eventLog1.WriteEntry("Error occurs on getting Record of zone :" + rep.Data.Domain.ZoneUuid + " \r\nError:" + rec.ErrorMessage.GetMessage(), EventLogEntryType.Error, eventId++);
                    return;
                }

                //find record and modify it if different
                foreach(RecordDto r in rec.Data.Records)
                {
                    if(r.RrsetName == "@" && r.RrsetType == "A")
                    {
                        string before = string.Empty;
                        foreach(string s in r.RrsetValues)
                        {
                            before += s + " ";
                            if (s == ip)
                                return;
                        }

                        r.RrsetValues = new List<string>() { ip };
                        ZoneUpdateResponse zu = GandiZone.UpdateOneRecords(rep.Data.Domain.ZoneUuid, "@", "A", r);
                        if (rec.ErrorMessage != null)
                        {
                            eventLog1.WriteEntry("Error occurs on update Record @ A with ip :"+ip+" of zone :" + rep.Data.Domain.ZoneUuid + " \r\nError:" + rec.ErrorMessage.GetMessage(), EventLogEntryType.Error, eventId++);
                        }
                        else
                        {
                            string message = $"Record of zone: {rep.Data.Domain.ZoneUuid} has been change from {before} to {ip}";
                            eventLog1.WriteEntry(message, EventLogEntryType.Information, eventId++);
                        }
                        return;
                    }
                }
            }
#if DEBUG
            eventLog1.WriteEntry($"OnTimer Stop", EventLogEntryType.Information, eventId++);
#endif
        }

        /// <summary>
        /// Get Public ip via json api
        /// </summary>
        /// <param name="url">url of api</param>
        /// <returns>an ip v4 adress or string.Empty if problem</returns>
        private string GetIPJson(string url)
        {
            try
            {
                HttpClient _clientweb = new HttpClient();
                _clientweb.BaseAddress = new Uri(url);
                _clientweb.DefaultRequestHeaders.Accept.Clear();
                _clientweb.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));


                Task<string> task = Task.Run(async () => await _clientweb.GetStringAsync(""));
                task.Wait();
                return JsonConvert.DeserializeObject<dynamic>(task.Result).ip;
            }catch(Exception)
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// Get Public ip via text/plain api
        /// </summary>
        /// <param name="url">url of api</param>
        /// <returns>an ip v4 adress or string.Empty if problem</returns>
        private string GetIP(string url)
        {
            try
            {
                HttpClient _clientweb = new HttpClient();
            _clientweb.BaseAddress = new Uri(url);
            _clientweb.DefaultRequestHeaders.Accept.Clear();
            _clientweb.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));


            Task<string> task = Task.Run(async () => await _clientweb.GetStringAsync(""));
            task.Wait();
            return task.Result;
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }

        protected override void OnStop()
        {
            eventLog1.WriteEntry("In OnStop.");
        }
    }
}
