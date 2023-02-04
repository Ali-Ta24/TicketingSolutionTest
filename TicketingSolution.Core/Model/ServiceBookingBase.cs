﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketingSolution.Core.Model
{
    public abstract class ServiceBookingBase
    {
        public string Name { get; set; }
        public string Family { get; set; }
        public string Email { get; set; }
    }
}
