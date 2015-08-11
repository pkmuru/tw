using System;
using System.Text.RegularExpressions;

namespace TW.ConferenceLib
{
    public class Talk
    {
        private int _duration;

        public Talk(string input)
        {

            if (Regex.Matches(input, @"\d+").Count > 1)
            {
                throw new Exception("Talk title has numbers in it.");
            }
            //Todo: validate title

            var matchString = Regex.Match(input, @"\d+").Value;
            int.TryParse(matchString, out _duration);


            if (_duration == 0 && input.IndexOf("lightning") > 0)
            {
                _duration = 5;
            }


            Title = input;
        }

       

        public int Duration
        {
            get { return _duration; }
            set { _duration = value; }
        }

        public string Title { get; set; }
        public TimeSpan Time { get; set; }

        public override string ToString()
        {
            return string.Format("{0} {1}", DateTime.Today.Add(Time).ToString("hh:mmtt"), Title);
        }
    }
}