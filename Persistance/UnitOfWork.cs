using System.Threading.Tasks;
using Szkolimy_za_darmo_api.Core.Interfaces;

namespace Szkolimy_za_darmo_api.Persistance
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SzdDbContext context;

        public async Task CompleteAsync()
        {
            await context.SaveChangesAsync();
        }

        public UnitOfWork(SzdDbContext context)
        {
            this.context = context;

        }
    }
}