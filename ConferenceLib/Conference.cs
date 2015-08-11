using System;
using System.Collections.Generic;
using System.Linq;

namespace TW.ConferenceLib
{
    public class Conference
    {
        private ConferneceDescriptor _conferneceDescriptor;

        public Conference(ConferneceDescriptor conferneceDescriptor)
        {
            _conferneceDescriptor = conferneceDescriptor;
            Tracks = new List<Track>();

            var talks = conferneceDescriptor.Talks.OrderByDescending(talk => talk.Duration).ToList();
            Tracks.Add(new Track(new Session(conferneceDescriptor.FirstSession)));


            foreach (var talk in talks)
            {
                var isTalkAdded = false;

                foreach (var track in Tracks)
                {
                    isTalkAdded = track.AddTalk(talk);
                    if (isTalkAdded)
                        break;
                }

                if (isTalkAdded) continue;

                foreach (var track in Tracks)
                {
                    if (track.Sessions.Count == 1)
                    {
                        track.AddSession(new Session(conferneceDescriptor.SecondSession));
                        isTalkAdded = track.AddTalk(talk);
                        if (isTalkAdded)
                            break;
                    }
                }


                if (!isTalkAdded)
                {
                    var newTrack = new Track(new Session(conferneceDescriptor.FirstSession));
                    Tracks.Add(newTrack);
                    isTalkAdded = newTrack.AddTalk(talk);
                }


                if (!isTalkAdded)
                    throw new Exception("talk cant addedd");
            }


            foreach (var track in Tracks)
            {
                track.AddLunchSession(new Session(conferneceDescriptor.LunchSession));
                track.AddNetworkEvent(conferneceDescriptor.NetworkEventStartTime);
                Console.WriteLine(track);
            }
        }

        public List<Track> Tracks { get; set; }
    }
}