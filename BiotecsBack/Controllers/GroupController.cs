using BiotecsBack.Services;
using Data.DTOs.FordAdmin;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BiotecsBack.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]

    public class GroupController : ControllerBase
    {
        private readonly IGroupService _groupService;

        public GroupController(IGroupService groupService)
        {
            _groupService = groupService;
        }

        public Task<IList<AdminGroupDto>> GetAllGroups(CancellationToken token)
        {
            return _groupService.GetAllGroups(token);
        }

        public Task<AdminGroupDto> GetByIdForAdminAsync(int groupId, CancellationToken token)
        {
            return _groupService.GetByIdForAdminAsync(groupId, token);
        }
    }
}
