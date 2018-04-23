using System;
using System.Collections.Generic;

namespace Realstate.Models
{
    public partial class Task
    {
        public int Id { get; set; }
        public int IdAccount { get; set; }
        public string Code { get; set; }
        public DateTime DateCreation { get; set; }
        public int IdProject { get; set; }
        public DateTime StartDate { get; set; }
        public string Description { get; set; }
        public int IdProspectoAreas { get; set; }
        public string StatusRegister { get; set; }
        public int IdStatusTask { get; set; }
        public string Route { get; set; }
        public DateTime DateModification { get; set; }
        public string ExternalCode { get; set; }
        public string AggregateUri { get; set; }
        public DateTime DateValidation { get; set; }
    }
}
