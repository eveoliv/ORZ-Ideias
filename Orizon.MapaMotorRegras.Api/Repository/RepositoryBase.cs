using System.Linq;
using Orizon.MapaMotorRegras.Api.Context;

namespace Orizon.MapaMotorRegras.Api.Repository
{
    public class RepositoryBase<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly MapaMotorContext context;

        public RepositoryBase(MapaMotorContext context)
        {
            this.context = context;
        }

        public IQueryable<TEntity> All => context.Set<TEntity>().AsQueryable();

        public void Alterar(params TEntity[] obj)
        {
            context.Set<TEntity>().UpdateRange(obj);
            context.SaveChanges();
        }

        public void Excluir(params TEntity[] obj)
        {
            context.Set<TEntity>().RemoveRange(obj);
            context.SaveChanges();
        }

        public TEntity Find(int key)
        {
            return context.Find<TEntity>(key);
        }

        public void Incluir(params TEntity[] obj)
        {
            context.Set<TEntity>().AddRange(obj);
            context.SaveChanges();
        }
    }
}
