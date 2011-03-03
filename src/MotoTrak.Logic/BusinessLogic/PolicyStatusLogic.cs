using System;
using System.Collections.Generic;
using MotoTrak.Entities;

namespace MotoTrak.BusinessLogic
{
    public class PolicyStatusLogic : BaseLogic
    {
        public PolicyStatusLogic(SecurityTicket ticket)
            : base(ticket)
        {
        }

        public List<PolicyStatusEntity> GetAll()
        {
            using (var db = CreateCatalog())
            {
                return db.PolicyStatuses.GetAll();
            }
        }
    }
}