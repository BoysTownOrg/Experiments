using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Experiments
{
    public class Subject
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string DoB { get; set; }
        public string SubjectID { get; set; }
        public string GroupID { get; set; }
        public List<GateUnit> TestsTaken;

    }
}
