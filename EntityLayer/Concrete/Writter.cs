using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Writter
    {
        [Key]
        public int WritterID { get; set; }
        public string WritterName { get; set; }
        public string WritterAbout { get; set; }
        public string WritterImage { get; set; }
        public string WritterMail { get; set; }
        public string WritterPassword { get; set; }
        public bool WritterStatus { get; set; }
        public List<Blog> Blogs { get; set; }
        public virtual ICollection<Message2> WritterSender { get;}
        public virtual ICollection<Message2> WritterReceiver { get;}
    }
}
