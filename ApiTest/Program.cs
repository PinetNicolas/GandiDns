using Api.Gandi;
using Api.Gandi.Domain;
using Api.Gandi.Domain.Api;
using Api.Gandi.Domain.Response;
using Api.Gandi.Record.Response;
using Api.Gandi.Snapshot.Response;
using Api.Gandi.Zone;
using Api.Gandi.Zone.Api;
using Api.Gandi.Zone.Response;
using Newtonsoft.Json;
using System;

namespace ApiTest
{
    class Program
    {
        static void Main(string[] args)
        {
            //using (ManagerZone Gandilecture = new ManagerZone("https://dns.api.gandi.net/api/v5/", "your_api_key"))
            //{
            //    ZoneListResponse repell = Gandilecture.GetList();
            //    ZoneDto zone = null;
            //    foreach(ZoneDto z in repell.Data.Zones)
            //    {
            //        if(z.Name == "your_domain")
            //        {
            //            zone = z;
            //        }

            //        if(z.Name.Contains("bobtest"))
            //        {
            //            Gandilecture.Delete(z.Uuid);
            //        }
            //    }

            //    Console.WriteLine(JsonConvert.SerializeObject(zone));

            //    RecordListResponse repRec = Gandilecture.GetAllRecords(zone.Uuid);

            //    //repRec = Gandilecture.GetNamedRecords(zone.Uuid,"@");
            //    RecordDetailResponse repRecD = Gandilecture.GetOneRecords(zone.Uuid,"@","A");
            //    SnapshotListResponse repSnp = Gandilecture.GetSnapshots(zone.Uuid);
            //    SnapshotDetailResponse repSnpD = Gandilecture.GetOneSnapshot(zone.Uuid,"");


            //    ZoneDto create = new ZoneDto() { Name = "bobtest"+DateTime.Now.ToLongTimeString() };
            //    ZoneCreateResponse resp = Gandilecture.Create(create);
            //    if(resp.ErrorMessage !=null)
            //    {

            //    }
            //    create.Uuid = resp.Data.Uuid;
            //    ZoneUpdateResponse repU = Gandilecture.CreateRecords(create.Uuid, repRecD.Data.Record);
            //    repU = Gandilecture.CreateSnapshot(create.Uuid);
            //    repU = Gandilecture.UpdateAllRecords(create.Uuid, repRec.Data.Records);
            //    create.Name = "2" + create.Name;
            //    repU = Gandilecture.UpdateDetail(create.Uuid, create);

            //    repRecD.Data.Record.RrsetValues.Add("127.0.0.1");
            //    repU = Gandilecture.UpdateOneRecords(create.Uuid, "@", "A",repRecD.Data.Record);
            //    repSnp = Gandilecture.GetSnapshots(create.Uuid);
            //    repSnpD = Gandilecture.GetOneSnapshot(create.Uuid, repSnp.Data.Snapshots[0].Uuid);

            //    repU = Gandilecture.DeleteAllRecords(create.Uuid);
            //    repU = Gandilecture.Delete(create.Uuid);
            //}

            using (ManagerZone Gandilecture = new ManagerZone("https://dns.api.gandi.net/api/v5/", "your_api_key"))
            using (ManagerDomain GandiDomain = new ManagerDomain("https://dns.api.gandi.net/api/v5/", "your_api_key"))
            {
                ZoneListResponse repell = Gandilecture.GetList();
                ZoneDto zone = null;
                foreach (ZoneDto z in repell.Data.Zones)
                {
                    if (z.Name == "your_domain")
                    {
                        zone = z;
                    }

                    if (z.Name.Contains("bobtest"))
                    {
                        Gandilecture.Delete(z.Uuid);
                    }
                }

                DomainDetailResponse zz = GandiDomain.GetDetail("your_domain");
                Console.WriteLine(JsonConvert.SerializeObject(zz.Data.Domain));

                DomainDto dom = new DomainDto() { FQDN = "bob.your_domain", ZoneUuid = zone.Uuid };

                DomainCreateResponse repC = GandiDomain.Create(dom);
                DomainUpdateResponse repU = GandiDomain.UpdateZone(dom.FQDN, repell.Data.Zones[0].Uuid);

            }

            Console.ReadKey();
        }

    }
}
