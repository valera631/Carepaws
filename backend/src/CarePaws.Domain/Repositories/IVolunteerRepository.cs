using CarePaws.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarePaws.Domain.Repositories
{
    public interface IVolunteerRepository
    {
        Task<Volunteer?> GetByEmailAsync(string email);
        Task<Volunteer?> GetByIdAsync(Guid id);
        Task AddAsync(Volunteer volunteer);
        Task SaveChangesAsync();
    }
}
