
using ApiGandiStandard;
using System;

namespace GandiDns
{
    class Program
    {
        static int Main(string[] args)
        {
            if (args.Length < 2)
            {
                Console.WriteLine("Need two parameters first domain list comma separated, the second is the apikey for Gandi");
                return -1;
            }

            foreach (string dom in args[0].Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                string message = DomainManager.UpdateDomainGandi(dom, args[1]);
                if (!string.IsNullOrEmpty(message))
                    Console.WriteLine(message);
            }

            return 0;
        }
    }
}
