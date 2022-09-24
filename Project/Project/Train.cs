using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    public class Train
    {
        private List<Station> Stationlist = new List<Station>();
        public Train(String[] lines)
        {
            foreach (string line in lines)
                Stationlist.Add(new Station(line));
            if(Stationlist.Count() <= 1) {
                Console.WriteLine("must have more then 1 station in input file");
                System.Environment.Exit(1);
            }
        }

        public void runTrain()
        {
                String[] twoStopTest = twoStops();
                if (twoStopTest[0] != "False")
                {
                    Console.WriteLine("This train stops at " + twoStopTest[0] + " and " + twoStopTest[1] + " only");
                    System.Environment.Exit(1);
                }
                if (allStops() == true) {
                    Console.WriteLine("This train stops at all stations");
                    System.Environment.Exit(1);
                }
                String OneExpressCheck = allStopsOneExpress();
                if (OneExpressCheck != "False") {
                    Console.WriteLine("This train stops at all stations except " + OneExpressCheck);
                    System.Environment.Exit(1);
                }
            
        }
        private String[] twoStops()
        {
            int numStops = 0;
            String Stop1 = "Error";
            String Stop2 = "Error";
            String[] failTest = { "False" };
            foreach (Station station in Stationlist)
            {
                if (station.GetStop() == true)
                {
                    numStops++;
                    if (numStops == 1) {
                        Stop1 = station.GetSName();
                    }
                    if (numStops == 2)
                    {
                        Stop2 = station.GetSName();
                    }
                }
            }
            if (numStops == 2)
            {
                String[] finalStops =   { Stop1, Stop2 };
                return finalStops;
            }
            else 
            {
                return failTest;
            }
        }
        private bool allStops() 
        {
            foreach (Station station in Stationlist)
            {
                if (station.GetStop() == false) { 
                    return false;   
                }
            }
            return true;
        }

        private String allStopsOneExpress()
        {
            int FalseCounter = 0;
            string SkippedStation = "None";
            foreach (Station station in Stationlist)
            {
                if (station.GetStop() == false)
                {
                    FalseCounter++;
                    SkippedStation = station.GetSName();
                }
            }
            if (FalseCounter == 1) {
                return SkippedStation;
            }
            return "False";
        }
        private bool singleExpress()
        {
            int numStops;
            String Stop1 = "Error";
            String Stop2 = "Error";

            return true;
        }
        private bool singleExpressOneStop()
        {
            int numStops;
            String Stop1 = "Error";
            String Stop2 = "Error";

            return true;
        }

        private bool comExpression()
        {
            int numStops;
            String Stop1 = "Error";
            String Stop2 = "Error";

            return true;
        }
    }
}
