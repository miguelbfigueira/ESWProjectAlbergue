using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ESWProjectAlbergue.Models
{
    public class Reminder
    {
        public int ReminderId { get; set; }
        [DisplayName("Autor")]
        public string UserCreater { get; set; }
        [DisplayName("Autor")]
        public ApplicationUser UserCreaterId { get; set; }

        [DisplayName("Data Criação")]
        public DateTime DateCreate { get; set; }

        [DisplayName("Prazo para a Realização")]
        public DateTime DateEnd { get; set; }
        [DisplayName("Título")]
        public string Title { get; set; }
        [DisplayName("Descrição")]
        public string Description { get; set; }
        [DisplayName("É um evento?")]
        public bool IsEvent { get; set; }
        [DisplayName("Feito?")]
        public bool IsDone { get; set; }
        [DisplayName("Destinatário")]
        public string UserReminder { get; set; }
        [DisplayName("Destinatário")]
        public ApplicationUser UserReminderId { get; set; }
    }
}
