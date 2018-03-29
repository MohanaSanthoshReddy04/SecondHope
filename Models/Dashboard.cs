using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using Surrogacy.Entity;
using Surrogacy.Util;

namespace Surrogacy.Models
{
    public class Dashboard : BaseEntity
    {
        public string UserID { get; set; }
        public int EmailBoxID { get; set; }
        public string UserRoleDetail { get; set; }
        public string FolderType { get; set; }
        public string EmailFrom { get; set; }
        public string EmailTo { get; set; }
        public string EmailCC { get; set; }
        public string EmailBCC { get; set; }
        public string EmailSubject { get; set; }
        public string EmailBody { get; set; }
        public int IsRead { get; set; }
        public string ReceivedTime { get; set; }
        public int EmailFromID { get; set; }
        public int EmailToID { get; set; }
    }                                                                                                               
}