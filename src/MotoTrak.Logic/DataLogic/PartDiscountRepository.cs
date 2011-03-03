using System;
using System.Collections.Generic;
using MotoTrak.Entities;

namespace MotoTrak.DataLogic
{
    public class PartDiscountRepository : EntityRepository<PartDiscountEntity>
    {
        public PartDiscountEntity GetByCode(string code)
        {
            return Context.FindOne<PartDiscountEntity>(x => x.Code == code && x.IsActive == true);
        }

        public List<SearchEntity> Search(SearchRequest request)
        {
            var mgr = new SearchManager(Context);
            mgr.IdColumn = "Id";
            mgr.CodeColumn = "PartDiscountCode";
            mgr.NameColumn = "PartDiscountName";
            mgr.TableName = "dbo.PartDiscounts";
            mgr.ActiveOnly = true;

            return mgr.Execute(request);
        }
    }
}