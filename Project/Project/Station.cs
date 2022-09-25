using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    //Station class contain information regarding a single station/line in the input file 
    internal class Station
    {
        private String SName;//namne of station 
        private bool Stop;//determines if train will stop at this station
        public Station(String line)
        {
            //convert input strings to station name(SName var) and Stop var  
            string[] SplitLine = line.Split(',');//used to seperated input string into components  
            //a check for input file formatted correctly 
            if (SplitLine.Length != 2)
            {
                Console.WriteLine("input file formatted incorrectly");
                System.Environment.Exit(1);
            }
            SName = SplitLine[0].Trim();//remove white space from inputs 
            //convert string true and false values to bool 
            if (SplitLine[1].Trim() == "True")
            {
                Stop = true;
            }
            else if (SplitLine[1].Trim() == "False")
            {
                Stop = false;
            }
            else 
            {
                Console.WriteLine("input file formatted incorrectly");
                System.Environment.Exit(1);
            }
        }
        //GetSname is a getter for SName var
        public string GetSName()
        {
            return SName;
        }
        //GetStop is a getter for Stop var
        public bool GetStop()
        {
            return Stop;
        }
    }
}
