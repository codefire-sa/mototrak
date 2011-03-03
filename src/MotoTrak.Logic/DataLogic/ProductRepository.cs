using System;
using System.Collections.Generic;
using MotoTrak.Entities;

namespace MotoTrak.DataLogic
{
    public class ProductRepository : EntityRepository<ProductEntity>
    {
        public ProductEntity GetByCode(string code)
        {
            return Context.FindOne<ProductEntity>(x => x.Code == code && x.IsActive == true);
        }

        public List<ProductEntity> GetAll()
        {
            return Context.Find<ProductEntity>()
                          .Where(x => x.IsActive == true)
                          .List();
        }
    }
}