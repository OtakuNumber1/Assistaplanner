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
        public int TerminKategorie { get; set; }
        public string TerminTitel { get; set; }
        public string TerminUntertitel { get; set; }
        public string Wochentag { get; set; }
        public int vonStunde { get; set; }
        public int vonMinute { get; set; }
         public int bisStunde { get; set; }
        public int bisMinute { get; set; }
        public string beschreibung { get; set; }
    }
}
