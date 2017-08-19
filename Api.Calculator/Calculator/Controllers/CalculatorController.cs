using Calculator.Add.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Calculator.Controllers
{
    [Route("api/[controller]")]
    public class CalculatorController : Controller
    {
        private readonly IAddService _addService;

        public CalculatorController(IAddService addService)
        {
            _addService = addService;
        }

        [HttpGet]
        public string Default()
        {
            return "Controller is still working!";
        }

        [HttpGet("Add/{a}/{b}")]
        public int Add(int a, int b)
        {
            return _addService.Add(a, b);
        }
    }
}
