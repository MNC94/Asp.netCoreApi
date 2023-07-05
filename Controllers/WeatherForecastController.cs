using Asp.netCoreApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace Asp.netCoreApi.Controllers
{
    [ApiController]
    //[Route("[WeatherForecast]")]
    public class EmployeeController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<EmployeeController> _logger;

        public EmployeeController(ILogger<EmployeeController> logger)
        {
            _logger = logger;
        }



        //[HttpGet]
        //[Route("WeatherForecast/Index")]
        //public IEnumerable<string> Index()
        //{
        //     return new string[] { "value1", "value2" };
        //}


        [HttpGet]
        [Route("WeatherForecast")]
        [Route("Home")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }


        EmployeeDataAccessLayer objemployee = new EmployeeDataAccessLayer();
        // GET: api/<EmployeeController>

        [HttpGet]
        [Route("api/Employee/Index")]
        public IEnumerable<TblEmployee> Index()
        {
            return objemployee.GetAllEmployees();
        }

        [HttpPost]
        [Route("api/Employee/Create")]
        public int Create([FromBody] TblEmployee employee)
        {
            return objemployee.AddEmployee(employee);
        }

        [HttpGet]
        [Route("api/Employee/Details/{id}")]
        public TblEmployee Details(int id)
        {
            return objemployee.GetEmployeeData(id);
        }
        [HttpPut]
        [Route("api/Employee/Edit")]
        public int Edit([FromBody] TblEmployee employee)
        {
            return objemployee.UpdateEmployee(employee);
        }

        [HttpDelete]
        [Route("api/Employee/Delete/{id}")]
        public int Delete(int id)
        {
            return objemployee.DeleteEmployee(id);
        }

        // GET api/<EmployeeController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST api/<EmployeeController>
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT api/<EmployeeController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        // DELETE api/<EmployeeController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}

        [HttpGet]
        [Route("api/Employee/GetCityList")]
        public IEnumerable<TblCity> Details()
        {
            return objemployee.GetCities();
        }


    }
}