using Microsoft.AspNetCore.Mvc;
using System.Net;
using WebAPICalculator.Models;

namespace WebAPICalculator.Controllers
{
    [Route("api/[controller]")]
    public class CalculatorController : Controller
    {
        [HttpGet]
        [Route("Addition")]
        public IActionResult Addition(double a, double b)
        {
            try
            {
                double result = a + b;

                return Ok(new APIResponse() { IsSuccess = true, Response = result });
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new APIResponse() { IsSuccess = false, Response = "Something Went Wrong" });
            }
        }

        [HttpGet]
        [Route("Subtraction")]
        public IActionResult Subtraction(double a, double b)
        {
            try
            {
                double result = a - b;

                return Ok(new APIResponse() { IsSuccess = true, Response = result });
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new APIResponse() { IsSuccess = false, Response = "Something Went Wrong" });
            }
        }

        [HttpGet]
        [Route("Multiplication")]
        public IActionResult Multiplication(double a, double b)
        {
            try
            {
                double result = a * b;

                return Ok(new APIResponse() { IsSuccess = true, Response = result });
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new APIResponse() { IsSuccess = false, Response = "Something Went Wrong" });
            }
        }

        [HttpGet]
        [Route("Division")]
        public IActionResult Division(double a, double b)
        {
            try
            {
                if(b == 0)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, new APIResponse() { IsSuccess = false, Response = "Cannot devide from zero" });
                }


                double result = a / b;

                return Ok(new APIResponse() { IsSuccess = true, Response = result });
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new APIResponse() { IsSuccess = false, Response = "Something Went Wrong" });
            }
        }
    }
}
