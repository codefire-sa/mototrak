using System;
using System.Collections.Generic;
using MotoTrak.Entities;

namespace MotoTrak.BusinessLogic
{
    public class GenderLogic : BaseLogic
    {
        public GenderLogic(SecurityTicket ticket)
            : base(ticket)
        {
        }

        public List<GenderEntity> GetAll()
        {
            using (var db = CreateCatalog())
            {
                return db.Genders.GetAll();
            }
        }
    }
}