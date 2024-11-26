using FirstEmployeeApi.Data;
using FirstEmployeeApi.Model.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc; 


namespace FirstEmployeeApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;

        public EmployeeController(ApplicationDbContext dbContext)
        {
           
            this.dbContext = dbContext;
        }

        [HttpGet]

        public IActionResult Get()
        {
            var AllEmployees = dbContext.Employee_data.ToList();

            return Ok(AllEmployees);
        }



        [HttpGet]
        [Route("{id:guid}")]
        public IActionResult GetEmployeeById(Guid id)
        {
            var Employees=dbContext.Employee_data.Find(id);
            if(Employees == null)
            {
                return NotFound();
            }
            return Ok(Employees);
        }

        [HttpPost("Add_Employee")]

        public IActionResult EmployeeAdd(AddEmployeeDTO addEmployeeDTO)
        {
            var EmployeeEntity = new Employee_data()
            {
                EmpName = addEmployeeDTO.EmpName,
                MobileNo = addEmployeeDTO.MobileNo,
                Gender = addEmployeeDTO.Gender
            };

                dbContext.Employee_data.Add(EmployeeEntity);
            dbContext.SaveChanges();
                   return Ok(EmployeeEntity);
        }

        [HttpPut]
        [Route("{id:guid}")]
        public IActionResult EmployeeEdit(Guid id,UpdateEmp updateEmp) 
        {
            var EmployeeData = dbContext.Employee_data.Find(id);
            
            if(EmployeeData == null)
            {
                return NotFound();

            }
            EmployeeData.EmpName = updateEmp.EmpName;   
            EmployeeData.MobileNo = updateEmp.MobileNo; 
            EmployeeData.Gender = updateEmp.Gender;

            dbContext.SaveChanges();
            return Ok(EmployeeData);
        }


        [HttpDelete]
        [Route("{id:guid}")]

        public IActionResult EmployeeDelete(Guid id)
        {
            var empId=dbContext.Employee_data.Find(id);
            if(empId == null)
            {
                return NotFound();

            }
            dbContext.Employee_data.Remove(empId);
            dbContext.SaveChanges();
            return Ok(empId);
        }

    }
}
