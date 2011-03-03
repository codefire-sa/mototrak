using System;
using System.Collections.Generic;
using System.Data;
using MotoTrak.DataLogic;
using MotoTrak.Entities;
using Codefire.Storm;

namespace MotoTrak.BusinessLogic
{
    public class VehicleServiceLogic : BaseLogic
    {
        public VehicleServiceLogic(SecurityTicket ticket)
            : base(ticket)
        {
        }

        public VehicleServiceEntity GetById(int id)
        {
            using (var db = CreateCatalog())
            {
                return db.VehicleServices.GetById(id);
            }
        }

        public List<VehicleServiceEntity> GetByVehicle(int vehicleId)
        {
            using (var db = CreateCatalog())
            {
                return db.VehicleServices.GetByVehicle(vehicleId);
            }
        }

        public void Save(VehicleServiceEntity serviceObj)
        {
            using (var db = CreateCatalog())
            {
                db.VehicleServices.Save(serviceObj);
            }
        }

        public void Delete(int id)
        {
            using (var db = CreateCatalog())
            {
                db.VehicleServices.Delete(id);
            }
        }

        public void Reinstate(int id)
        {
            using (var db = CreateCatalog())
            {
                db.VehicleServices.Reinstate(id);
            }
        }
    }
}