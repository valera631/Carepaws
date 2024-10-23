using CarePaws.Domain.Entities;
using CarePaws.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarePaws.Infrastructure.Repositories
{
    public class VolunteerRepository : IVolunteerRepository
    {
        private readonly ApplicationDbContext _context;

        public VolunteerRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Volunteer?> GetByEmailAsync(string email)
        {
            return await _context.Volunteers
                .Include(v => v.SocialNetworks)
                .Include(v => v.PaymentDetails)
                .FirstOrDefaultAsync(v => v.Email == email);
        }

        public async Task<Volunteer?> GetByIdAsync(Guid id)
        {
            return await _context.Volunteers
                .Include(v => v.SocialNetworks)
                .Include(v => v.PaymentDetails)
                .FirstOrDefaultAsync(v => v.Id == id);
        }

        public async Task AddAsync(Volunteer volunteer)
        {
            await _context.Volunteers.AddAsync(volunteer);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
