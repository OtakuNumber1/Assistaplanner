using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assistaplanner
{
    public class TerminZeit
    {
        public string tag { get; set; }
        public int stunde { get; set; }
        public int minute { get; set; }

        public static string GetTimeString(TerminZeit zeit)
        {
            string ganzeZeit = zeit.tag + ", " + zeit.stunde + ":" + zeit.minute;
            return ganzeZeit;
        }
    }
}
