using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Split_IT.Entities;
using Split_IT.Entities.DTOs;
using Split_IT.Repositories.ExpenseRepository;
using Split_IT.Repositories.GroupRepository;
using Split_IT.Repositories.UserRepository;

namespace Split_IT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupController : ControllerBase
    {
        private readonly IGroupRepository _repository;
        private readonly IUserRepository _userRepository;
        private readonly IExpenseRepository _expenseRepository;

        public GroupController(IGroupRepository repository, IUserRepository userRepository, IExpenseRepository expenseRepository)
        {
            _repository = repository;
            _userRepository = userRepository;
            _expenseRepository = expenseRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllGroups()
        {
            var groups = await _repository.GetAllGroups();
            var groupsToReturn = new List<GroupDTO>();

            foreach (var group in groups)
            {
                groupsToReturn.Add(new GroupDTO(group));
            }

            return Ok(groupsToReturn);
        }

        [HttpGet("user={user}")]
        public async Task<IActionResult> GetAllGroupsByUserId(int user)
        {
            var allGroups = await _repository.GetAllGroups();
            var groupsToReturn = new List<GroupDTO>();

            foreach (var group in allGroups)
            {
                var itsUsers = group.Users;
                if (itsUsers != null)
                    foreach (var itsUser in itsUsers)
                    {
                        if (itsUser.UserId == user)
                        {
                            groupsToReturn.Add(new GroupDTO(group));
                            break;
                        }
                    }

            }

            return Ok(groupsToReturn);
        }


        [HttpPost]
        public async Task<IActionResult> CreateGroup(CreateGroupDTO dto)
        {
            Group newgroup = new Group();
            newgroup.Name = dto.Name;
            newgroup.PhotoUrl = dto.PhotoUrl;

            _repository.Create(newgroup);

            await _repository.SaveAsync();
            
            return Ok(new GroupDTO(newgroup));

        }

        public class GroupModel
        {
            public string Name { get; set; }
            public string PhotoUrl { get; set; }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateGroup([FromBody]GroupModel group)
        {
            var newgroup = await _repository.GetByName(group.Name);
            newgroup.Name = group.Name;
            newgroup.PhotoUrl = group.PhotoUrl;

            _repository.Update(newgroup);
            await _repository.SaveAsync();

            return Ok(new GroupDTO(newgroup));
        }
        
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateGroupById([FromBody]GroupModel group, int id)
        {
            var newgroup = await _repository.GetById(id);
            newgroup.Name = group.Name;
            newgroup.PhotoUrl = group.PhotoUrl;

            _repository.Update(newgroup);
            await _repository.SaveAsync();

            return Ok(new GroupDTO(newgroup));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGroupById(int id)
        {
            var group = await _repository.GetById(id);
            if (group == null)
            {
                return NotFound("Group does not exist");
            }
            _repository.Delete(group);
            await _repository.SaveAsync();

            return NoContent();
        }



    }
}
