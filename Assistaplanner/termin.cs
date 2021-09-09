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
        int KategorieID { get; set; }
        string Titel { get; set; }
        string Untertitel { get; set; }
        int von { get; set; }
        int bis { get; set; }
        string beschreibung { get; set; }
    }
}
