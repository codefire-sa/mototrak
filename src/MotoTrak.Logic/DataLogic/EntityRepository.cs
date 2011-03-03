using System;
using System.Collections.Generic;
using MotoTrak.Entities;
using Codefire.Storm;

namespace MotoTrak.DataLogic
{
    public abstract class EntityRepository<TEntity> : IRepository where TEntity : Entity
    {
        private IDataContext _context;

        public EntityRepository()
        {
        }

        public IDataContext Context
        {
            get { return _context; }
        }

        public void Initialize(IDataContext context)
        {
            _context = context;
        }

        public TEntity GetById(int id)
        {
            return _context.GetById<TEntity>(id);
        }

        public int Insert(TEntity entity)
        {
            return Convert.ToInt32(_context.Insert<TEntity>(entity));
        }

        public void Update(TEntity entity)
        {
            _context.Update<TEntity>(entity);
        }

        public void Save(TEntity entity)
        {
            if (entity.Id == 0)
            {
                _context.Insert<TEntity>(entity);
            }
            else
            {
                _context.Update<TEntity>(entity);
            }
        }

        public void Save(List<TEntity> entityList)
        {
            entityList.ForEach(obj => Save(obj));
        }

        public void Delete(int id)
        {
            _context.Delete<TEntity>(id);
        }

        public void Reinstate(int id)
        {
            _context.Reinstate<TEntity>(id);
        }
    }
}