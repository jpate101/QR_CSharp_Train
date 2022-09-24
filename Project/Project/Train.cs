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
        private List<Station> Stationlist = new List<Station>();//hold info from input file 
        public Train(String[] lines)
        {
            //convert input string array into variable or a list of Stations(class) 
            foreach (string line in lines)
                Stationlist.Add(new Station(line));
            //check to see if there is more than one station in input fiile 
            if(Stationlist.Count() <= 1) {
                Console.WriteLine("must have more then 1 station in input file");
                System.Environment.Exit(1);
            }
        }
        //runTrain function used to write output msg to console 
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
            String[] singleEx = singleExpress();
            if (singleEx[0] != "False")
            {
                Console.WriteLine("This train runs express from "+ singleEx[1] + " to "+ singleEx[2]);
                System.Environment.Exit(1);
            }

            String[] singleExOneStop = singleExpressOneStop();
            if (singleExOneStop[0] != "False")
            {
                Console.WriteLine("This train runs express from "+ singleExOneStop[1]+" to "+singleExOneStop[3]+", stopping only at "+ singleExOneStop[2]);
                System.Environment.Exit(1);
            }
            String[][] comExp = comExpression();
            for (int i = 0; i < comExp[0].Length; i++)
            {
                if (i == 0) 
                {
                    Console.WriteLine("This train runs express from " + comExp[0][i] + " to " + comExp[2][i] + ", stopping only at " + comExp[1][i]);
                } 
                else 
                {
                    Console.WriteLine("then this train runs express from " + comExp[0][i] + " to " + comExp[2][i] + ", stopping only at " + comExp[1][i]);
                }
            }



        }
        //twoStops function used to check for station list with only two stops
        //and to return the two stops
        //input - void 
        //output - on fail - { "False" };
        //output - on pass - { FirstStop1, LastStop2 };
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
        private string[] singleExpress()
        {
            int numStops = 0;
            String Stop1 = "Error";
            String Stop2 = "Error";

            foreach (Station station in Stationlist)
            {
                if (station.GetStop() == true)
                {
                    numStops++;
                    if (numStops == 1) 
                    { 
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
                String[] succReturn = { "True", Stop1, Stop2 };
                return succReturn;
            }
            String[] FailReturn = { "False",};
            return FailReturn;
        }
        private string[] singleExpressOneStop()
        {
            int numStops = 0;
            int totalStops = Stationlist.Count;
            String Stop1 = "Error";
            String Stop2 = "Error";
            String Stop3 = "Error";

            foreach (Station station in Stationlist)
            {
                if (station.GetStop() == true)
                {
                    numStops++;
                    if (numStops == 1)
                    {
                        Stop1 = station.GetSName();
                    }
                    if (numStops == 2)
                    {
                        Stop2 = station.GetSName();
                    }
                    if (numStops == 3)
                    {
                        Stop3 = station.GetSName();
                    }

                }
            }

            if (numStops == 3 && numStops < totalStops)
            {
                String[] succReturn = { "True", Stop1, Stop2, Stop3 };
                return succReturn;
            }

            String[] FailReturn = { "False", };
            return FailReturn;
        }

        private string[][] comExpression()
        {
            int totalNumStations = Stationlist.Count;//total number of stations 
            int NumStops = 0;//current number of stops 
            int NumExpress = 0;//current express section 
            int CurStopInExpress = 0;

            //counts stops in Station list 
            foreach (Station station in Stationlist)
            {
                if (station.GetStop() == true)
                {
                    NumStops++;
                }
            }
            String[] Stop1 = new string[(NumStops/3)+1];
            String[] Stop2 = new string[(NumStops/3)+1];
            String[] Stop3 = new string[(NumStops/3)+1];

            foreach (Station station in Stationlist)
            {
                //Console.WriteLine("station ");
                if (station.GetStop() == true)
                {
                    //Console.WriteLine("True" + NumExpress + " " + CurStopInExpress);
                    if (CurStopInExpress == 0)
                    {
                        Stop1[NumExpress] = station.GetSName();
                        CurStopInExpress++;
                    }
                    else if (CurStopInExpress == 1) 
                    {
                        Stop2[NumExpress] = station.GetSName();
                        CurStopInExpress++;
                    }
                    else if (CurStopInExpress == 2)
                    {
                        Stop3[NumExpress] = station.GetSName();
                        CurStopInExpress = 0;
                        NumExpress++;
                    }

                }             
            }
            String[][] Return = { Stop1,Stop2,Stop3 };
            return Return;
        }
    }
}
