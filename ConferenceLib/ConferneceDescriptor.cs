using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TW.ConferenceLib
{
    public class ConferneceDescriptor
    {
        public Session FirstSession;
        public Session LunchSession;
        public Session SecondSession;
        public TimeSpan NetworkEventStartTime;
        public List<Talk> Talks;
    }
}
