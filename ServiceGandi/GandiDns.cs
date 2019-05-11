using ApiGandiStandard;
using System;
using System.Diagnostics;
using System.ServiceProcess;

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
            eventLog1 = new EventLog();
            if (!EventLog.SourceExists("GandiDns"))
            {
                EventLog.CreateEventSource("GandiDns", "Application");
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
            foreach (string dom in _domain.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                string message = DomainManager.UpdateDomainGandi(dom, _apikey);
                if (!string.IsNullOrEmpty(message))
                    eventLog1.WriteEntry(message, EventLogEntryType.Error, eventId++);
            }

#if DEBUG
            eventLog1.WriteEntry($"OnTimer Stop", EventLogEntryType.Information, eventId++);
#endif
        }

        protected override void OnStop()
        {
            eventLog1.WriteEntry("In OnStop.");
        }
    }
}
