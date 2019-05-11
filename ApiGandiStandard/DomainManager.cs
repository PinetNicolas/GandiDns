using Api.Gandi;
using Api.Gandi.Domain.Api;
using Api.Gandi.Domain.Response;
using Api.Gandi.Record.Response;
using Api.Gandi.Zone.Api;
using Api.Gandi.Zone.Response;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ApiGandiStandard
{
    public class DomainManager
    {
        /// <summary>
        /// Function to update a domain in Gandi
        /// </summary>
        /// <param name="domain">domain name</param>
        /// <param name="apikey">The Gandi api key</param>
        /// <returns>a message in case of error</returns>
        public static string UpdateDomainGandi(string domain, string apikey)
        {
            //Read ip
            //https://api.ipify.org?format=json
            //https://api.myip.com
            //https://ip.seeip.org/jsonip?
            // brute
            //http://ipv4bot.whatismyipaddress.com/
            string ip = GetIPJson("https://api.ipify.org?format=json");
            if (string.IsNullOrEmpty(ip))
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

            using (ManagerZone GandiZone = new ManagerZone("https://dns.api.gandi.net/api/v5/", apikey))
            using (ManagerDomain GandiDomain = new ManagerDomain("https://dns.api.gandi.net/api/v5/", apikey))
            {
                DomainDetailResponse rep = GandiDomain.GetDetail(domain);
                if (rep.ErrorMessage != null)
                {
                    return "Error occurs on getting domain :" + domain + " \r\nError:" + rep.ErrorMessage.GetMessage();
                }

                RecordListResponse rec = GandiZone.GetAllRecords(rep.Data.Domain.ZoneUuid);
                if (rec.ErrorMessage != null)
                {
                    return "Error occurs on getting Record of zone :" + rep.Data.Domain.ZoneUuid + " \r\nError:" + rec.ErrorMessage.GetMessage();
                }

                //find record and modify it if different
                foreach (RecordDto r in rec.Data.Records)
                {
                    if (r.RrsetName == "@" && r.RrsetType == "A")
                    {
                        string before = string.Empty;
                        foreach (string s in r.RrsetValues)
                        {
                            before += s + " ";
                            if (s == ip)
                                return string.Empty;
                        }

                        r.RrsetValues = new List<string>() { ip };
                        ZoneUpdateResponse zu = GandiZone.UpdateOneRecords(rep.Data.Domain.ZoneUuid, "@", "A", r);
                        if (rec.ErrorMessage != null)
                        {
                            return "Error occurs on update Record @ A with ip :" + ip + " of zone :" + rep.Data.Domain.ZoneUuid + " \r\nError:" + rec.ErrorMessage.GetMessage();
                        }
                    }
                }
            }

            return string.Empty;
        }

        /// <summary>
        /// Get Public ip via json api
        /// </summary>
        /// <param name="url">url of api</param>
        /// <returns>an ip v4 adress or string.Empty if problem</returns>
        private static string GetIPJson(string url)
        {
            try
            {
                HttpClient _clientweb = new HttpClient();
                _clientweb.BaseAddress = new Uri(url);
                _clientweb.DefaultRequestHeaders.Accept.Clear();
                _clientweb.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));


                Task<string> task = Task.Run(async () => await _clientweb.GetStringAsync(""));
                task.Wait();
                var ret = JsonConvert.DeserializeAnonymousType(task.Result,new { ip = "" });
                return ret.ip;

            }
            catch (Exception)
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// Get Public ip via text/plain api
        /// </summary>
        /// <param name="url">url of api</param>
        /// <returns>an ip v4 adress or string.Empty if problem</returns>
        private static string GetIP(string url)
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
    }
}
