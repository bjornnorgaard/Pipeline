using Calculator.Add.Interface;
using Calculator.Multiply.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Calculator.Controllers
{
    [Route("api/[controller]")]
    public class CalculatorController : Controller
    {
        private readonly IAddService _addService;
        private readonly IMultiplyService _multiplyService;

        public CalculatorController(IAddService addService, IMultiplyService multiplyService)
        {
            _addService = addService;
            _multiplyService = multiplyService;
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

        [HttpGet("Multiply/{a}/{b}")]
        public int Multiply(int a, int b)
        {
            return _multiplyService.Multiply(a, b);
        }
    }
}
