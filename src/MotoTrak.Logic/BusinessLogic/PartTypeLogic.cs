using System;
using System.Collections.Generic;
using MotoTrak.Entities;

namespace MotoTrak.BusinessLogic
{
    public class PartTypeLogic : BaseLogic
    {
        public PartTypeLogic(SecurityTicket ticket)
            : base(ticket)
        {
        }

        public PartTypeEntity GetById(int id)
        {
            using (var db = CreateCatalog())
            {
                return db.PartTypes.GetById(id);
            }
        }

        public List<PartTypeEntity> GetAll()
        {
            using (var db = CreateCatalog())
            {
                return db.PartTypes.GetAll();
            }
        }
    }
}