using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ESWProjectAlbergue.Models
{
    public class Reminder
    {
        public int ReminderId { get; set; }
        public ApplicationUser Creater { get; set; }
        public DateTime DateCreate { get; set; }
        public DateTime DateEnd { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsEvent { get; set; }
        public bool IsDone { get; set; }

        public ApplicationUser UserToReminder { get; set; }

    }
}
