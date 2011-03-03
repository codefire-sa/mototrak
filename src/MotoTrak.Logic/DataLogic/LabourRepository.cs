using System;
using System.Collections.Generic;
using MotoTrak.Entities;

namespace MotoTrak.DataLogic
{
    public class LabourRepository : EntityRepository<LabourEntity>
    {
        public LabourEntity GetByCode(string code)
        {
            return Context.FindOne<LabourEntity>(x => x.Code == code && x.IsActive == true);
        }

        public List<SearchEntity> Search(SearchRequest request)
        {
            var mgr = new SearchManager(Context);
            mgr.IdColumn = "Id";
            mgr.CodeColumn = "LabourCode";
            mgr.NameColumn = "LabourName";
            mgr.TableName = "dbo.Labour";
            mgr.ActiveOnly = true;

            return mgr.Execute(request);
        }
    }
}