using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CASTEP_Management
{
    public class CASTEPinfo
    {
        public string substance = "";
        public string task = "";
        public string quality0 = "", quality1 = "";
        public string space = "";
        public double content = -1.0;
        public string functional = "";
        public List<CASTEPsubObj> record = new List<CASTEPsubObj>();
    }

    public class CASTEPsubObj
    {
        public double stress;
        public double pressure;
        public double bulkModulus;
        public double enthalpy;
        public double cellVolumn;
        public double a;
        public double angle;
        public double energy;
        public double V;
        public double E;
    }
}
