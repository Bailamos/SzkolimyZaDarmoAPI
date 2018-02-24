using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Szkolimy_za_darmo_api.Core.Interfaces;
using Szkolimy_za_darmo_api.Core.Models;

namespace Szkolimy_za_darmo_api.Persistance
{
    public class InstructorRepository : IInstructorRepository
    {
        private readonly SzdDbContext context;

        public InstructorRepository(SzdDbContext context)
        {
            this.context = context;
        }

        public void Add(Instructor instructor)
        {
           context.Instructors.Add(instructor);
        }

        public async Task<Instructor> GetOne(int id)
        {
            return await context.Instructors.SingleOrDefaultAsync(instructor => instructor.Id == id);
        }
    }
}