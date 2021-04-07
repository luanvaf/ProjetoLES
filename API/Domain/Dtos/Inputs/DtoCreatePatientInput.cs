using Domain.Entities;
using System;

namespace Domain.Dtos.Inputs
{
    public class DtoCreatePatientInput
    {
        public string Name { get; set; }
        public string Cpf { get; set; }
        public DateTime BirthDate { get; set; }
        public SexType Sex { get; set; }
        public string Phone { get; set; }
        public DtoAddress Address { get; set; }


    }
    public class DtoAddress
    {
        public string District { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public string Street { get; set; }
    }
}
