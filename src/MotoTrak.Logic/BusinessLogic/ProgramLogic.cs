using System;
using System.Collections.Generic;
using MotoTrak.Entities;

namespace MotoTrak.BusinessLogic
{
    public class ProgramLogic : BaseLogic
    {
        public ProgramLogic(SecurityTicket ticket)
            : base(ticket)
        {
        }

        public ProgramEntity GetById(int id)
        {
            using (var db = CreateCatalog())
            {
                return db.Programs.GetById(id);
            }
        }

        public List<ProgramEntity> GetAll()
        {
            using (var db = CreateCatalog())
            {
                return db.Programs.GetAll();
            }
        }
    }
}