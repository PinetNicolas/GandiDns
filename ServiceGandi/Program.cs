using System.Configuration;
using System.ServiceProcess;

namespace ServiceGandi
{
    static class Program
    {
        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        static void Main()
        {
            string domain = ConfigurationManager.AppSettings.Get("domain");
            string apikey = ConfigurationManager.AppSettings.Get("apikey");
            string verifinterval = ConfigurationManager.AppSettings.Get("verifinterval");
            
            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[]
            {
                new GandiDns(domain,apikey,verifinterval)
            };
            ServiceBase.Run(ServicesToRun);
        }
    }
}
