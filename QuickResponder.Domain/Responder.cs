﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickResponder.Domain
{
    public class Responder : User
    {
        public Guid ID { get; set; }
        public List<Patient> PatientHistory { get; set; } = new List<Patient>();
    }
}
