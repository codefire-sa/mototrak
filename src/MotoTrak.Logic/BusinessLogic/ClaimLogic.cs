using System;
using System.Collections.Generic;
using System.Data;
using MotoTrak.DataLogic;
using MotoTrak.Entities;
using Codefire.Storm;

namespace MotoTrak.BusinessLogic
{
    public class ClaimLogic : BaseLogic
    {
        public ClaimLogic(SecurityTicket ticket)
            : base(ticket)
        {
        }

        public ClaimEntity GetById(int id)
        {
            using (var db = CreateCatalog())
            {
                return db.Claims.GetById(id);
            }
        }

        public DataTable Search(ClaimSearchRequest request)
        {
            using (var db = CreateCatalog())
            {
                return db.Claims.Search(request);
            }
        }

        public List<VehicleNoteEntity> ListNotes(int claimId)
        {
            using (var db = CreateCatalog())
            {
                return db.VehicleNotes.GetByClaim(claimId);
            }
        }

        public List<ClaimHistoryEntity> ListStatusHistory(int claimId)
        {
            using (var db = CreateCatalog())
            {
                return db.ClaimHistory.GetByClaim(claimId);
            }
        }

        public DataTable GetQueue()
        {
            using (var db = CreateCatalog())
            {
                return db.ClaimQueues.GetByUser(Ticket.UserId);
            }
        }

        public void Save(ClaimEntity obj)
        {
            using (var db = CreateCatalog())
            {
                db.Claims.Save(obj);
            }
        }
    }
}