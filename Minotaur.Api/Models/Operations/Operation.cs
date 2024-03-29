﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Minotaur.Api.Models.Operations
{
    public class Operation
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public string State { get; set; }
        public string Resource { get; set; }
        public string Code { get; set; }
        public string Reason { get; set; }
    }
}
