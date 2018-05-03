using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Realstate.Models.BaseDatos
{
    public class DetailTask
    {

        public int Id { get; set; }
        public int IdTask { get; set; }
        public string addressee { get; set; }
        public string coment { get; set; }
        public string attached { get; set; }
    
        public DateTime creation_date { get; set; }
        public DateTime creation_meeting { get; set; }
       
        public Task task { get; set; }
    }
}
