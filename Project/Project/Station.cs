using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    internal class Station
    {
        private String SName;
        private bool Stop;
        public Station(String line)
        {
            string[] SplitLine = line.Split(',');
            if (SplitLine.Length != 2)
            {
                Console.WriteLine("input file formatted incorrectly");
                System.Environment.Exit(1);
            }
            SName = SplitLine[0].Trim();
            if (SplitLine[1].Trim() == "True")
            {
                Stop = true;
            }
            else if (SplitLine[1].Trim() == "False")
            {
                Stop = false;
            }
            else {
                Console.WriteLine("input file formatted incorrectly");
                System.Environment.Exit(1);
            }
            //Console.WriteLine(SName);
            //Console.WriteLine(Stop);
        }

        public string GetSName()
        {
            return SName;
        }
        public bool GetStop()
        {
            return Stop;
        }
    }
}
