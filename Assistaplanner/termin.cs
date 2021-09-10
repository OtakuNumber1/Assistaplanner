using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assistaplanner
{
    class Termin
    {
        int TerminID { get; set; }
        TerminKategorie KategorieID { get; set; }
        string Titel { get; set; }
        string Untertitel { get; set; }
        string Wochentag { get; set; }
        int vonStunde { get; set; }
        int vonMinute { get; set; }
        int bisStunde { get; set; }
        int bisMinute { get; set; }
        string beschreibung { get; set; }
    }
}
