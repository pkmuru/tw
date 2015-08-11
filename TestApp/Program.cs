using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TW.ConferenceLib;

namespace TestApp
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var lines = File.ReadAllLines("TestInput.txt");

            //var talks = lines.Select(line => new Talk(line)).ToList();

            List<Talk> talks = (from line in lines where !string.IsNullOrWhiteSpace(line) select new Talk(line)).ToList();


            var conferneceDescriptor = new ConferneceDescriptor
            {
                FirstSession = new Session(new TimeSpan(9, 00, 0), 180),
                LunchSession = new Session(new TimeSpan(12, 00, 0), 60),
                SecondSession = new Session(new TimeSpan(13, 00, 0), 240),
                NetworkEventStartTime = new TimeSpan(16, 0, 0),
                Talks = talks
            };
            var conf = new Conference(conferneceDescriptor);

            Console.ReadLine();
        }
    }
}