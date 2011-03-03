using System;
using System.Collections.Generic;
using MotoTrak.Entities;

namespace MotoTrak.BusinessLogic
{
    public class ClaimTypeLogic : BaseLogic
    {
        public ClaimTypeLogic(SecurityTicket ticket)
            : base(ticket)
        {
        }

        public ClaimTypeEntity GetById(int id)
        {
            using (var db = CreateCatalog())
            {
                return db.ClaimTypes.GetById(id);
            }
        }

        public List<ClaimTypeEntity> GetAll()
        {
            using (var db = CreateCatalog())
            {
                return db.ClaimTypes.GetAll();
            }
        }
    }
}