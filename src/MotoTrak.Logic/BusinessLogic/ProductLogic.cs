using System;
using System.Collections.Generic;
using MotoTrak.Entities;

namespace MotoTrak.BusinessLogic
{
    public class ProductLogic : BaseLogic
    {
        public ProductLogic(SecurityTicket ticket)
            : base(ticket)
        {
        }

        public ProductEntity GetById(int id)
        {
            using (var db = CreateCatalog())
            {
                return db.Products.GetById(id);
            }
        }

        public List<ProductEntity> GetAll()
        {
            using (var db = CreateCatalog())
            {
                return db.Products.GetAll();
            }
        }
    }
}