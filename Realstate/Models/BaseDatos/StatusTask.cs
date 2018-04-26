using System;
using System.Collections.Generic;

namespace Realstate.Models.BaseDatos
{
    public partial class StatusTask
    {
        public StatusTask()
        {
            Task = new HashSet<Task>();
        }

        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string StatusRegister { get; set; }

        public ICollection<Task> Task { get; set; }
    }
}
