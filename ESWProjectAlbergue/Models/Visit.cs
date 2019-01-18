using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ESWProjectAlbergue.Models
{
    public class Visit
    {
        public int VisitId { get; set; }
        public string Description { get; set; }
        public string UserToVisitId { get; set; }
        public virtual ApplicationUser UserToVisit { get; set; }
        public DateTime Date { get; set; }

        
       
    }
}
