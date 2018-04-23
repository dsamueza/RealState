﻿using System;
using System.Collections.Generic;

namespace Realstate.Models.BaseDatos
{
    public partial class Account
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string StatusRegister { get; set; }
        public IEnumerable<Project> Project { get; internal set; }
    }
}
