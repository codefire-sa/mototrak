using System;
using System.Collections.Generic;
using MotoTrak.Entities;

namespace MotoTrak.DataLogic
{
    public class ProgramRepository : EntityRepository<ProgramEntity>
    {
        public List<ProgramEntity> GetAll()
        {
            return Context.Find<ProgramEntity>()
                          .Where(x => x.IsActive == true)
                          .List();
        }
    }
}