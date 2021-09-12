using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assistaplanner
{
    public class Termin
    {
        public int TerminID { get; set; }
        public int KategorieID { get; set; }
        public string Titel { get; set; }
        public string Untertitel { get; set; }
        public string Wochentag { get; set; }
        public int vonStunde { get; set; }
        public int vonMinute { get; set; }
         public int bisStunde { get; set; }
        public int bisMinute { get; set; }
        public string beschreibung { get; set; }
    }
}
