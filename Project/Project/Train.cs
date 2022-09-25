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
        private List<Station> Stationlist = new List<Station>();//info from input file 
        public Train(String[] lines)//constructer 
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
            //following if statments checks for each of the output scenarios then prints stopping sequence description to console then terminates the program 
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
            //if all above stopping scenarios fail then com Expression return all stopped at station to craft a msg to print to console  
            String[][] comExp = comExpression();//returns all express stops in a matrix 
            int i;//hold current express section of train journey
            for (i = 0; i < comExp[0].Length-1; i++)
            {
                if (i == 0) //if first messages removes the word "then"
                {
                    Console.WriteLine("This train runs express from " + comExp[0][i] + " to " + comExp[2][i] + ", stopping only at " + comExp[1][i]+",");
                } 
                else 
                {
                    Console.WriteLine("then this train runs express from " + comExp[0][i] + " to " + comExp[2][i] + ", stopping only at " + comExp[1][i]+",");
                }
            }
            //last express section may not have 3 stops each of the following if statments handles different combination
            if (comExp[0][i] == null && comExp[1][i] == null && comExp[2][i] == null) 
            {
                //should never be called
                Console.WriteLine("Error");
                System.Environment.Exit(1);
            }
            else if (comExp[1][i] == null && comExp[2][i] == null)
            {
                Console.WriteLine("then this train runs express to " + comExp[0][i]);
                System.Environment.Exit(1);
            }
            else if (comExp[2][i] == null)
            {
                Console.WriteLine("then this train runs express from " + comExp[0][i] + " to " + comExp[1][i]);
                System.Environment.Exit(1);
            }
            else 
            {
                //should never be called
                Console.WriteLine("Error");
                System.Environment.Exit(1);
            }



        }
        //twoStops function used to check for station list with only two stops
        //and to return the two stops
        //input - void 
        //output - on fail - { "False" };
        //output - on pass - { FirstStop1, LastStop2 };
        private String[] twoStops()
        {
            int numStops = 0;//counts stops the train takes 
            String Stop1 = "Error";//holds first stop name 
            String Stop2 = "Error";//holds second stop name 
            String[] failTest = { "False" };
            foreach (Station station in Stationlist)
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
        //check to see if train stops at all stations 
        //returns true if all station have been stopped at
        //or false if train skips a station 
        public bool allStops() //convert to private after testing
        {
            foreach (Station station in Stationlist)
            {
                if (station.GetStop() == false) { 
                    return false;   
                }
            }
            return true;
        }
        //checks to see if trains stops at all except one stop 
        //input - void 
        //output - on fail - "False";
        //output - on pass - SkippedStation;
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
        //check for - if there are more than 2 stations in a trainstop sequence but only 2 stops 
        //output - on fail - { "False",};
        //output - on pass - { "True", Stop1, Stop2 };
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
        //checks for - check for a single express section with 1 intermediate stop 
        //output - on fail - { "False",};
        //output - on pass - { "True", Stop1, Stop2, Stop3 };
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

        //function used to organise express sections for description if above checks fail
        //output - String[][] Return = { Stop1,Stop2,Stop3 };//each stop is array of the corresponding  stops in each express section - eg { Stop1[0],Stop2[0],Stop3[0] } is the first express section 
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
