using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TW.ConferenceLib
{
    public class Track
    {
        public List<Session> Sessions;

        public Track(Session session)
        {
            Sessions = new List<Session> { session };
        }

        public bool AddTalk(Talk talk)
        {
            foreach (var session in Sessions)
            {
                if (session.Available >= talk.Duration)
                {
                    session.AddTalk(talk);
                    return true;
                }
            }


            return false;
        }

        public void AddSession(Session session)
        {
            Sessions.Add(session);
        }

        public void AddNetworkEvent(TimeSpan networkEventStartTime)
        {
            var lastSession = Sessions[Sessions.Count - 1];
            var lastTalkEndTime = networkEventStartTime;

            if (lastSession.Talks != null && lastSession.Talks.Count > 0)
            {
                var lastTalk = lastSession.Talks[lastSession.Talks.Count - 1];
                lastTalkEndTime = lastTalk.Time + new TimeSpan(0, lastTalk.Duration, 0);
            }

            if (lastTalkEndTime > networkEventStartTime)
            {
                networkEventStartTime = lastTalkEndTime;
            }

            var netWorkSession = new Session(networkEventStartTime, 0);

            var networkTalk = new Talk("Networking Event") {Duration = 0};
            netWorkSession.AddTalk(networkTalk);
            Sessions.Add(netWorkSession);
        }


        public void AddLunchSession(Session lunchSession)
        {

            var lunch = new Talk("Lunch") {Duration = lunchSession.Duration};

            lunchSession.AddTalk(lunch);
            Sessions.Insert(1, lunchSession);
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            foreach (var session in Sessions)
            {
                sb.Append(session);
            }

            return sb.ToString();
        }
    }
}