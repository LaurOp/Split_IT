using Microsoft.AspNetCore.Mvc;
using Split_IT.Entities;
using Split_IT.Entities.DTOs;
using Split_IT.Entities.Models;
using Split_IT.Repositories.ExpenseRepository;
using Split_IT.Repositories.FriendshipManager;
using Split_IT.Repositories.GroupRepository;
using Split_IT.Repositories.UserGroupRepository;
using Split_IT.Repositories.UserRepository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Split_IT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _repository;
        private readonly IGroupRepository _groupRepository;
        private readonly IExpenseRepository _expenseRepository;
        private readonly IFriendshipRepository _friendshipRepository;
        private readonly IUserGroupRepository _userGroupRepository;

        public UserController(IUserRepository repository, IGroupRepository groupRepository, IExpenseRepository expenseRepository, IFriendshipRepository friendshipRepository, IUserGroupRepository userGroupRepository)
        {
            _repository = repository;
            _groupRepository = groupRepository;
            _expenseRepository = expenseRepository;
            _friendshipRepository = friendshipRepository;
            _userGroupRepository = userGroupRepository;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _repository.GetAllUsers();
            var usersToReturn = new List<UserDTO>();

            foreach (var user in users)
            {
                usersToReturn.Add(new UserDTO(user));
            }

            return Ok(usersToReturn);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserById(int id)
        {
            var user = await _repository.GetById(id);
            if (user == null)
            {
                return NotFound("User does not exist");
            }
            _repository.Delete(user);
            await _repository.SaveAsync();

            return NoContent();
        }

        // get all users of certain group
        [HttpGet("group={id}")]
        public async Task<IActionResult> GetUsersByGroupId(int id)
        {
            var group = await _groupRepository.GetById(id);
            var usersToReturn = new List<UserDTO>();

            if (group.Users != null)

                foreach(var userGroup in group.Users)
                {
                     usersToReturn.Add(new UserDTO(userGroup.User));                
                }

            return Ok(usersToReturn);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(CreateUserDTO dto)
        {
            User newuser = new User();
            newuser.Username = dto.Username;
            newuser.Password = dto.Password;
            newuser.WalletFunds = dto.WalletFunds;

            _repository.Create(newuser);

            await _repository.SaveAsync();

            return Ok(new UserDTO(newuser));

        }

        // get all groups of a user id parameter
        [HttpGet("GroupsOfuser={user}")]
        public async Task<IActionResult> GetAllGroupsByUserId(int user)
        {
            var allGroups = await _groupRepository.GetAllGroups();
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

        // get all friends of user id parameter
        [HttpGet("friendsOfuser={id}")]
        public async Task<IActionResult> GetAllFriendsOf(int id)
        {
            User user = await _repository.GetById(id);
            if (user == null)
            {
                return NotFound("User does not exist");
            }

            var allFriends = new List<UserDTO>();

            foreach(var friend in user.FriendWith)
            {
                allFriends.Add(new UserDTO(friend.UserTo));
            }

            return Ok(allFriends);
        }

        [HttpPut("deleteFriend={friendId}fromUser={id}")]
        public async Task<IActionResult> DeleteFriendFrom(int friendId, int id)
        {
            var user = await _repository.GetById(id);
            var actualFriends = user.FriendWith;

            var newFriendlist = new List<Friendship>();
            if (actualFriends != null)
                foreach(var friend in actualFriends)
                {
                    if(friend.ToId != friendId)
                    {
                        newFriendlist.Add(friend);
                    }
                }

            user.FriendWith = newFriendlist;

            _repository.Update(user);
            await _repository.SaveAsync();

            return Ok(new UserDTO(user));

        }


        // get all expenses of user
        [HttpGet("expensesOfuser={user}")]
        public async Task<IActionResult> GetAllExpensesByUserId(int user)
        {
            var allExpenses = await _expenseRepository.GetAllExpenses();
            var expensesToReturn = new List<ExpenseDTO>();

            foreach (var exp in allExpenses)
            {
                var itsUsers = exp.AmountsOwed;
                if (itsUsers != null)
                    foreach (var itsUser in itsUsers)
                    {
                        if (itsUser.UserId == user)
                        {
                            expensesToReturn.Add(new ExpenseDTO(exp));
                            break;
                        }
                    }

            }

            return Ok(expensesToReturn);
        }

        [HttpPost("{id1}-friendWith-{id2}")]
        public async Task<IActionResult> NowAreFriends(int id1, int id2)
        {
            User user1 = await _repository.GetById(id1);
            if (user1 == null)
            {
                return NotFound("User1 does not exist");
            }

            User user2 = await _repository.GetById(id2);
            if (user2 == null)
            {
                return NotFound("User2 does not exist");
            }

            Friendship newFriends = new Friendship(id1, id2, user1, user2);
            _friendshipRepository.Create(newFriends);
            await _friendshipRepository.SaveAsync();

            user1.FriendWith.Add(newFriends);
            user1.FriendOf.Add(newFriends);

            user2.FriendOf.Add(newFriends);
            user2.FriendWith.Add(newFriends);

            _repository.Update(user1);
            _repository.Update(user2);

            await _repository.SaveAsync();


            return Ok(user1);
        }

        public class UserModel
        {
            public string Username { get; set; }
        }

        [HttpPost("newfriendForID={id}")]
        public async Task<IActionResult> AddNewFriend([FromBody]UserModel friend, int id)
        {
            User user = await _repository.GetById(id);
            if (user == null)
            {
                return NotFound("User does not exist");
            }

            User newFriend = new User();
            newFriend.Username = friend.Username;


            Friendship newFriends = new Friendship(id, newFriend.Id, user, newFriend);
           _friendshipRepository.Create(newFriends);
            await _friendshipRepository.SaveAsync();


            user.FriendWith.Add(newFriends);
            user.FriendOf.Add(newFriends);

            newFriend.FriendOf.Add(newFriends);
            newFriend.FriendWith.Add(newFriends);

            _repository.Update(user);
            //_repository.Create(newFriend);
            await _repository.SaveAsync();

            return Ok(newFriends);
        }

        [HttpGet("{id}-joinsGroup={groupid}")]
        public async Task<IActionResult> JoinGroup(int id, int groupid)
        {
            User user = await _repository.GetById(id);
            if (user == null)
            {
                return NotFound("User does not exist");
            }

            Group group = await _groupRepository.GetById(groupid);
            if (group == null)
            {
                return NotFound("Group failed");
            }

            UserGroup newUserGroup = new UserGroup(id, user, groupid, group);
            _userGroupRepository.Create(newUserGroup);
            await _userGroupRepository.SaveAsync();

            user.Groups.Add(newUserGroup);
            group.Users.Add(newUserGroup);

            _repository.Update(user);
            _groupRepository.Update(group);

            return Ok(newUserGroup);
        }

    }
}
