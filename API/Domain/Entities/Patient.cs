﻿using System;
using System.Collections;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class Patient : Entity<Guid>
    {
        public string Name { get; set; }
        public string Cpf { get; set; }
        public DateTime BirthDate { get; set; }
        public SexType Sex { get; set; }
        public string Phone { get; set; }
        public Guid AddressId { get; set; }
        public virtual Address Address { get; set; }
        public virtual IEnumerable<MedicalConsultation> MedicalConsultations{ get; set; }
    }
}
