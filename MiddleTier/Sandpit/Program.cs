using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Horizon4.GF.Network;
using Horizon4.GF;
using Horizon4.GF.RollingStock;
using Horizon4.GF.Logical;
using Horizon4.GF.WTT;
using Horizon4.GF.Build;

namespace Sandpit
{
    class Program
    {
        static void Main(string[] args)
        {
            Common.SQLDBConn = @"Server=.;Database=GF_DEV;Trusted_Connection=True;";
            Console.ForegroundColor = ConsoleColor.White;
            Common.Application = Application.Sandpit;
            try
            {
                Console.WriteLine("Started..");
                //Console.WriteLine();
                //Common.CurrentYMDV = new YMDV(DateTime.Today);
                //Console.WriteLine(string.Format(@"Date:- {0}", Common.CurrentYMDV.Date.ToString("dd/MM/yyyy")));
                //Console.WriteLine();
                //Console.WriteLine();
                TestShorestPath();


                //List<BuildResponse> BuildResponses = new List<BuildResponse>();
                //Build.BuildAll(ref BuildResponses, @"G:\GitHub\GroundFrame\SQL", @"G:\GitHub\GroundFrame\SQL\BuildScript.sql", ".", "GF_DEV");

                ////Check for Error. If Found Quit.
                //if (BuildResponses.Count(x => x.ReponseType == BuildResponseType.Error) > 0)
                //{
                //    BuildResponses.Where(x => x.ReponseType == BuildResponseType.Error).ToList().ForEach(s =>
                //        {
                //            Console.WriteLine(s.ResponseMessage);
                //        });
                //    throw new Exception("Build Failed. See Responses");
                //}

                //ListSystemLocations();
                //Console.WriteLine();
                //ListTokens();
                //Console.WriteLine();
                //ListLocations();
                //Console.WriteLine();
                //TestDistance();
                //Console.WriteLine();
                //ListSystemPaths();
                //Console.WriteLine();
                //ListPaths();
                //Console.WriteLine();
                //ListDepots();
                //Console.WriteLine();
                //TestSpeeds();
                //Console.WriteLine();
                //TestTractionClasses();
                //Console.WriteLine();
                //TestSectors();
                //Console.WriteLine();
                //TestRakes();
                //Console.WriteLine();
                //TestTrains();
                //Console.WriteLine();
                //TestRegions();
                //Console.WriteLine();
                 Console.WriteLine("Completed.");
            }
            catch (Exception Ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(Ex.InnerException == null ? Ex.Message : string.Format(@"{0} ({1}", Ex.Message, Ex.InnerException.Message));
            }
            finally
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Press Any Key..");
                Console.ReadKey();
            }
        }

        private static void TestShorestPath()
        {
            Common.SystemLocations = new SystemLocationCollection();
            Common.Tokens = new TokenCollection();
            Location Start = new Location(23);
            Location End = new Location(2);
            YMDV YMDV = new YMDV(19000101);

            Console.WriteLine("Dijkstra:");
            List<Node> Test = ShortestPath.Calculate(Start, End, YMDV, ShortestPathMethod.DijkstraSearch);
            int NodeVists = ShortestPath.NodeVists;

            foreach (Node T in Test)
            {
                Console.WriteLine(string.Format(@"{0} | {1}", T.DisplayName, T.Path == null ? string.Empty : T.Path.Label));
            }

            Console.WriteLine("Node Vists: {0}", NodeVists);

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("A Star:");
            Test = ShortestPath.Calculate(Start, End, YMDV, ShortestPathMethod.DijkstraSearch);
            NodeVists = ShortestPath.NodeVists;

            foreach (Node T in Test)
            {
                Console.WriteLine(string.Format(@"{0} | {1}", T.DisplayName, T.Path == null ? string.Empty : T.Path.Label));
            }

            Console.WriteLine("Node Vists: {0}", NodeVists);
        }

        private static void TestDistanceCalc()
        {
            Common.SystemLocations = new SystemLocationCollection();
            Common.Tokens = new TokenCollection();
            Location Salisbury = new Location(1);
            Location Tisbury = new Location(20);
            Console.WriteLine(string.Format(@"Distance: {0} meters", Salisbury.Distance(Tisbury)));
        }

        private static void TestRegions()
        {
            Console.WriteLine("Regions:-");

            Common.Regions = new RegionCollection(Common.CurrentYMDV);

            foreach (Region _Region in Common.Regions.OrderBy(x => x.Name))
            {
                Console.WriteLine(string.Format(@"{0} ({1})", _Region.Name, _Region.Description));
            }
        }

        private static void TestTrains()
        {
            Console.WriteLine("Trains:-");

            Common.Trains = new TrainCollection(Common.CurrentYMDV);

            foreach (Train _Train in Common.Trains.OrderBy(x => x.Headcode))
            {
                Console.WriteLine(string.Format(@"{0} ({1})", _Train.Headcode, _Train.Description));
            }
        }

        private static void TestRakes()
        {
            Console.WriteLine("Rakes:-");

            Common.Rakes = new RakeCollection(Common.CurrentYMDV);

            foreach (Rake _Rake in Common.Rakes.OrderBy(x => x.Name))
            {
                Console.WriteLine(string.Format(@"{0} ({1})", _Rake.Name, _Rake.Description));
            }
        }


        private static void TestStock()
        {
            Console.WriteLine("Stock:-");

            Common.StockList = new StockCollection(Common.CurrentYMDV);

            foreach (Stock _Stock in Common.StockList.OrderBy(x => x.Name))
            {
                Console.WriteLine(string.Format(@"{0} ({1} Tons)", _Stock.Name, _Stock.Weight.Tons));
            }
        }


        private static void TestSectors()
        {
            Console.WriteLine("Sectors:-");

            Common.Sectors = new SectorCollection(Common.CurrentYMDV);

            foreach (Sector _Sector in Common.Sectors.OrderBy(x => x.Code))
            {
                Console.WriteLine(string.Format(@"{0} ({1})", _Sector.Code, _Sector.Description));
            }
        }

        private static void TestTractionClasses()
        {
            Console.WriteLine("Traction Classes:-");

            Common.TractionClasses = new TractionClassCollection(Common.CurrentYMDV);

            foreach (TractionClass _TractionClass in Common.TractionClasses.OrderBy(x => x.Name))
            {
                Console.WriteLine(string.Format(@"{0} ({1}) | Profile Count: {2}", _TractionClass.Name, _TractionClass.TractionType.ToString(), _TractionClass.TractionProfile.Count()));
            }
        }

        private static void TestSpeeds()
        {
            Console.WriteLine("Speed (100MPH):-");
            Speed _Speed = new Speed(100);
            Console.WriteLine(string.Format(@"MPH - {0}", _Speed.MPH));
            Console.WriteLine(string.Format(@"KPH - {0}", _Speed.KPH));
        }

        private static void ListDepots()
        {
            Console.WriteLine("Depots:-");

            Common.Depots = new DepotCollection(Common.CurrentYMDV);

            foreach (Depot _Depot in Common.Depots.OrderBy(x => x.Code))
            {
                Console.WriteLine(string.Format(@"{0} ({1})", _Depot.Code, _Depot.Location.DisplayName));
            }
        }


        private static void ListTokens()
        {
            Console.WriteLine("Tokens:-");

            Common.Tokens = new TokenCollection();

            foreach (Token _Token in Common.Tokens.OrderBy(x => x.Name))
            {
                Console.WriteLine(_Token.Name);
            }

            Console.WriteLine("Complete.");
        }

        private static void ListSystemPaths()
        {
            Console.WriteLine("System Paths:-");

            Common.SystemPaths = new SystemPathCollection();

            foreach (SystemPath _SystemPaths in Common.SystemPaths.OrderBy(x => x.Name))
            {
                Console.WriteLine(_SystemPaths.Name);
            }

            Console.WriteLine("Complete.");
        }

        private static void ListLocations()
        {
            Console.WriteLine("Locations:-");

            Common.Locations = new LocationCollection(Common.CurrentYMDV);

            foreach (Location _Location in Common.Locations.OrderBy(x => x.Name))
            {
                Console.WriteLine(string.Format(@"{0} ({1})", _Location.Name, _Location.Length.MilesAndChains));
            }
        }

        private static void ListPaths()
        {
            Console.WriteLine("Paths:-");

            Common.Paths = new PathCollection(Common.CurrentYMDV);

            foreach (Path _Path in Common.Paths.OrderBy(x => x.ID))
            {
                Console.WriteLine(_Path.Label);
            }

            Console.WriteLine("Complete.");
        }

        private static void ListSystemLocations()
        {
            Console.WriteLine("System Locations:-");

            Common.SystemLocations = new SystemLocationCollection();

            foreach (SystemLocation _SystemLocation in Common.SystemLocations.OrderBy(x => x.Name))
            {
                Console.WriteLine(_SystemLocation.Name);
            }

            Console.WriteLine("Complete.");
        }

        private static void TestDistance()
        {
            Console.WriteLine("Distance (67 Chains):-");

            Distance TestDistance = new Distance(67);

            Console.WriteLine("Miles And Chains");
            Console.WriteLine(TestDistance.MilesAndChains);

            Console.WriteLine("Meters");
            Console.WriteLine(TestDistance.Meters);

            Console.WriteLine("Inches");
            Console.WriteLine(TestDistance.Inches);

            Console.WriteLine("Distance (7 Miles, 19 Chains):-");

            TestDistance = new Distance(7,19);

            Console.WriteLine("Miles And Chains");
            Console.WriteLine(TestDistance.MilesAndChains);

            Console.WriteLine("Meters");
            Console.WriteLine(TestDistance.Meters);

            Console.WriteLine("Inches");
            Console.WriteLine(TestDistance.Inches);

            Console.WriteLine("Chains");
            Console.WriteLine(TestDistance.Chains);

            Console.WriteLine("Distance 69385 Meters):-");

            TestDistance = new Distance((decimal)69385.00);

            Console.WriteLine("Miles And Chains");
            Console.WriteLine(TestDistance.MilesAndChains);

            Console.WriteLine("Meters");
            Console.WriteLine(TestDistance.Meters);

            Console.WriteLine("Inches");
            Console.WriteLine(TestDistance.Inches);

            Console.WriteLine("Chains");
            Console.WriteLine(TestDistance.Chains);

            Console.WriteLine("Complete.");
        }
    }
}
