using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TW.ConferenceLib
{
    public class Session
    {
        public readonly int Duration;
        public readonly List<Talk> Talks;
        private TimeSpan _startTime;

        public Session(TimeSpan startTime, int duration)
        {
            Talks = new List<Talk>();
            _startTime = startTime;
            Duration = duration;
        }

        public Session(Session session)
            : this(session._startTime, session.Duration)
        {
        }

        public int Available
        {
            get { return Duration - Talks.Sum(talk => talk.Duration); }
        }

        public void AddTalk(Talk talk)
        {
            if (Available >= talk.Duration)
            {
                talk.Time = _startTime;
                _startTime += new TimeSpan(0, talk.Duration, 0);
                Talks.Add(talk);
            }
            else
            {
                throw new Exception("Cant add..");
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            foreach (var talk in Talks)
            {
                sb.AppendLine(talk.ToString());
            }
            return sb.ToString();
        }
    }
}