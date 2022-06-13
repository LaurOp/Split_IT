using Microsoft.AspNetCore.Mvc;
using Split_IT.Repositories.ExpenseRepository;
using Split_IT.Repositories.GroupRepository;
using Split_IT.Repositories.UserRepository;

namespace Split_IT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpenseController : ControllerBase
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

<<<<<<< Updated upstream
=======
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

        public class ExpenseModel
        {
            public float totalAmount { get; set; }
            public int GroupId { get; set; }
        }

        [HttpPut]   //sets amount to 0
        public async Task<IActionResult> UpdateExpense([FromBody] ExpenseModel expense)
        {
            var newexpense = await _repository.GetByGroupIdAndByAmount(expense.GroupId, expense.totalAmount);
            newexpense.totalAmount = 0;
            newexpense.GroupId = expense.GroupId;

            _repository.Update(newexpense);
            await _repository.SaveAsync();

            return Ok(new ExpenseDTO(newexpense));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateExpenseById([FromBody] ExpenseModel expense, int id)
        {
            var newexpense = await _repository.GetById(id);
            newexpense.totalAmount = expense.totalAmount;
            newexpense.GroupId = expense.GroupId;

            _repository.Update(newexpense);
            await _repository.SaveAsync();

            return Ok(new ExpenseDTO(newexpense));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteExpenseById(int id)
        {
            var expense = await _repository.GetById(id);
            if (expense == null)
            {
                return NotFound("Expense does not exist");
            }
            _repository.Delete(expense);
            await _repository.SaveAsync();

            return NoContent();
        }



>>>>>>> Stashed changes

    }
}
