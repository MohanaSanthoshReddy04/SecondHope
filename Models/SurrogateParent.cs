using Microsoft.VisualStudio.DebuggerVisualizers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Surrogacy.Entity;
using Surrogacy.Util;

namespace Surrogacy.Models
{
    public class SurrogateParent : BaseEntity
    {
        public string UserID { get; set; }
        public int SurrogateID { get; set; }
        public int ParentID { get; set; }
        public string SurroagateFirstName { get; set; }
        public string SurrogateLastName { get; set; }
        public string ParentFirstName { get; set; }
        public string ParentLastName { get; set; }
        public string DoctorName { get; set; }
        public string SurrogateEmailID { get; set; }
        public string ParentEmailID { get; set; }
        public string DoctorEmailID { get; set; }
        public string SurrogateAge { set; get; }
    }
}