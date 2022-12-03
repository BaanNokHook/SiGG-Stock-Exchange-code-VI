using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI_NET_6.Controllers.V1
{
    [Route("/employees")]
    [ApiController]
    [ApiVersion("1.0")]
    public class EmployeeController : ControllerBase
    {
        private readonly IAppRepository<Employee> _employeeRepository;

        public EmployeeController(IAppRepository<Employee> employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        [HttpPost]
        public async Task<IActionResult> PostAllEmployeesAsync()
        {
            var emps = (await _employeeRepository.GetAll()).Include(emp => emp.Department);

            return Ok(emps);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllEmployeesAsync()
        {
            var emps = (await _employeeRepository.GetAll()).Include(emp => emp.Department);

            return Ok(emps);
        }

        [HttpPut]
        public async Task<IActionResult> PutAllEmployeesAsync()
        {
            var emps = (await _employeeRepository.GetAll()).Include(emp => emp.Department);

            return Ok(emps);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAllEmployeesAsync()
        {
            var emps = (await _employeeRepository.GetAll()).Include(emp => emp.Department);

            return Ok(emps);
        }
    }
}
