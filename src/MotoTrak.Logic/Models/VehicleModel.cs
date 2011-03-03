using System;
using System.Collections.Generic;
using MotoTrak.Entities;

namespace MotoTrak.Models
{
    public class VehicleModel
    {
        private VehicleEntity _vehicle;
        private CustomerEntity _customer;
        private List<PolicyEntity> _policies;

        public VehicleModel()
        {
            _vehicle = new VehicleEntity();
            _customer = new CustomerEntity();
            _policies = new List<PolicyEntity>();
        }

        public VehicleEntity Vehicle
        {
            get { return _vehicle; }
            set { _vehicle = value; }
        }

        public CustomerEntity Customer
        {
            get { return _customer; }
            set { _customer = value; }
        }

        public List<PolicyEntity> Policies
        {
            get { return _policies; }
            set { _policies = value; }
        }
    }
}