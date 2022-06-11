using Microsoft.AspNetCore.Mvc;
using Split_IT.Repositories.ExpenseRepository;
using Split_IT.Repositories.GroupRepository;
using Split_IT.Repositories.UserRepository;

namespace Split_IT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpenseController : Controller
    {
        private readonly IExpenseRepository _repository;
        private readonly IUserRepository _userRepository;
        private readonly IGroupRepository _groupRepository;

        public ExpenseController(IExpenseRepository repository, IUserRepository userRepository, IGroupRepository groupRepository)
        {
            _repository = repository;
            _userRepository = userRepository;
            _groupRepository = groupRepository;
        }


    }
}
