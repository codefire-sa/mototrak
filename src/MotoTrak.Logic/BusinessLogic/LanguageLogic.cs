using System;
using System.Collections.Generic;
using MotoTrak.Entities;

namespace MotoTrak.BusinessLogic
{
    public class LanguageLogic : BaseLogic
    {
        public LanguageLogic(SecurityTicket ticket)
            : base(ticket)
        {
        }

        public List<LanguageEntity> GetAll()
        {
            using (var db = CreateCatalog())
            {
                return db.Languages.GetAll();
            }
        }
    }
}