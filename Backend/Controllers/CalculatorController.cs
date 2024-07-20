using Microsoft.AspNetCore.Mvc;
using System;

namespace CalculatorApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculatorController : ControllerBase
    {
        [HttpPost]
        public IActionResult Post([FromBody] CalculationRequest request)
        {
            try
            {
                var result = EvaluateExpression(request.Expression);
                return Ok(new { result });
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        private double EvaluateExpression(string expression)
        {
            // Use a library or implement a simple parser to evaluate the expression
            // For simplicity, here we can use DataTable.Compute method
            var table = new System.Data.DataTable();
            return Convert.ToDouble(table.Compute(expression, string.Empty));
        }
    }

    public class CalculationRequest
    {
        public string? Expression { get; set; }
    }
}
