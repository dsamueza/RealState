using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Realstate.Models.Struct
{
    public class DetailViewModel
    {
        public int Id { get; set; }
        public int IdTask { get; set; }
        public string addressee { get; set; }
        public string coment { get; set; }
        public string attached { get; set; }
        public string subjects { get; set; }
        public DateTime creation_date { get; set; }
        public DateTime creation_meeting { get; set; }
        public DateTime ENDMeting { get; set; }

    }
}
