using Microsoft.AspNetCore.Mvc;
using Split_IT.Entities;
using Split_IT.Entities.DTOs;
using Split_IT.Repositories.ExpenseRepository;
using Split_IT.Repositories.GroupRepository;
using Split_IT.Repositories.UserRepository;
using System.Collections.Generic;
using System.Threading.Tasks;

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

        [HttpGet]
        public async Task<IActionResult> GetAllExpenses()
        {
            var expenses = await _repository.GetAllExpenses();
            var expToReturn = new List<ExpenseDTO>();

            foreach (var ex in expenses)
            {
                expToReturn.Add(new ExpenseDTO(ex));
            }

            return Ok(expToReturn);
        }

        [HttpGet("user={user}")]
        public async Task<IActionResult> GetAllExpensesByUserId(int user)
        {
            var allExp = await _repository.GetAllExpenses();
            var expToReturn = new List<ExpenseDTO>();

            foreach (var exp in allExp)
            {
                var itsUsers = exp.AmountsOwed;
                foreach (var itsUser in itsUsers)
                {
                    if (itsUser.UserId == user)
                    {
                        expToReturn.Add(new ExpenseDTO(exp));
                        break;
                    }
                }

            }

            return Ok(expToReturn);
        }

        [HttpPost]
        public async Task<IActionResult> CreateExpense(CreateExpenseDTO dto)
        {
            Expense newexpense = new Expense();
            newexpense.totalAmount = dto.totalAmount;
            newexpense.Group = dto.Group;
            newexpense.GroupId = dto.GroupId;

            _repository.Create(newexpense);

            await _repository.SaveAsync();

            return Ok(new ExpenseDTO(newexpense));

        }




    }
}
