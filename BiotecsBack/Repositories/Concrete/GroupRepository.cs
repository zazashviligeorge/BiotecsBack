using BiotecsBack.Data;
using BiotecsBack.Repositories.Abstractions;
using Data.DTOs.FordAdmin;
using Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BiotecsBack.Repositories.Concrete
{
    public class GroupRepository : RepositoryBase<Group>, IGroupRepository
    {
        public GroupRepository(ApplicationDbContext ctx) : base(ctx) { }

        public async Task<IList<AdminGroupDto>> GetAllGroups(CancellationToken token)
        {
            return await RepositoryContext.Groups.Select(c => c.GetDto()).ToListAsync(token);
        }

        public async Task<AdminGroupDto> GetByIdForAdminAsync(int groupId, CancellationToken token)
        {
            return await RepositoryContext.Groups.Where(c => c.Id == groupId).Select(c => c.GetDto()).FirstOrDefaultAsync(token);
        }
    }


}
