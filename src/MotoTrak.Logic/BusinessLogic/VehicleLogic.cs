using System;
using System.Collections.Generic;
using System.Data;
using MotoTrak.DataLogic;
using MotoTrak.Entities;
using MotoTrak.Models;
using Codefire.Storm;

namespace MotoTrak.BusinessLogic
{
    public class VehicleLogic : BaseLogic
    {
        public VehicleLogic(SecurityTicket ticket)
            : base(ticket)
        {
        }

        public DataTable Search(VehicleSearchRequest request)
        {
            using (var db = CreateCatalog())
            {
                return db.Vehicles.Search(request);
            }
        }

        public List<VehicleNoteEntity> ListNotes(int vehicleId)
        {
            using (var db = CreateCatalog())
            {
                return db.VehicleNotes.GetByVehicle(vehicleId);
            }
        }

        public int AddNote(int vehicleId, int claimId, string note)
        {
            using (var db = CreateCatalog())
            {
                var noteObj = new VehicleNoteEntity();
                noteObj.VehicleId = vehicleId;
                noteObj.ClaimId = claimId;
                noteObj.Note = note;

                return db.VehicleNotes.Insert(noteObj);
            }
        }

        public VehicleEntity GetById(int id)
        {
            using (var db = CreateCatalog())
            {
                return db.Vehicles.GetById(id);
            }
        }

        public VehicleModel GetModel(int id, bool includePolicies)
        {
            using (var db = CreateCatalog())
            {
                var msg = new VehicleModel();
                msg.Vehicle = db.Vehicles.GetById(id);
                if (msg.Vehicle.CustomerId > 0)
                {
                    msg.Customer = db.Customers.GetById(msg.Vehicle.CustomerId);
                }

                if (includePolicies)
                {
                    msg.Policies = db.Policies.GetByVehicle(msg.Vehicle.Id);
                }

                return msg;
            }
        }

        public VehicleSummaryEntity GetSummary(int id)
        {
            using (var db = CreateCatalog())
            {
                return db.GetById<VehicleSummaryEntity>(id);
            }
        }

        public int Create(VehicleEntity vehicleObj)
        {
            using (var db = CreateCatalog())
            {
                var statusObj = db.VehicleStatuses.GetByCode("ACT");

                vehicleObj.CurrentDistanceUser.Id = Ticket.UserId;
                vehicleObj.CurrentDistanceDate = DateTime.Now;
                vehicleObj.VehicleStatus.Id = statusObj.Id;

                return db.Vehicles.Insert(vehicleObj);
            }
        }

        public void Update(VehicleEntity vehicleObj)
        {
            using (var db = CreateCatalog())
            {
                vehicleObj.CurrentDistanceUser.Id = Ticket.UserId;
                vehicleObj.CurrentDistanceDate = DateTime.Now;

                db.Vehicles.Update(vehicleObj);
            }
        }

        public void CreateModel(VehicleModel msg)
        {
            using (var db = CreateCatalog())
            {
                int customerId = db.Customers.Insert(msg.Customer);

                msg.Vehicle.CustomerId = customerId;
                msg.Vehicle.CurrentDistanceUser.Id = Ticket.UserId;
                msg.Vehicle.CurrentDistanceDate = DateTime.Now;

                db.Vehicles.Update(msg.Vehicle);
            }
        }

        public void UpdateModel(VehicleModel msg)
        {
            using (var db = CreateCatalog())
            {
                db.Customers.Update(msg.Customer);

                msg.Vehicle.CurrentDistanceUser.Id = Ticket.UserId;
                msg.Vehicle.CurrentDistanceDate = DateTime.Now;

                db.Vehicles.Update(msg.Vehicle);
            }
        }
    }
}