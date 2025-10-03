using Microsoft.AspNetCore.Mvc;
using System.Numerics;

var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services.AddControllers();

var app = builder.Build();

// Map controllers
app.MapControllers();
app.Run();

[ApiController]
[Route("lcm/abcnizamd_gmail_com")]
public class LCMController : ControllerBase
{
    [HttpGet]
    public IActionResult GetLCM([FromQuery] string x = "", [FromQuery] string y = "")
    {
        if (!IsNaturalNumber(x, out double xVal) || !IsNaturalNumber(y, out double yVal))
        {
            return Content("NaN", "text/plain");
        }

        double lcm = LCM(xVal, yVal);
        return Content(lcm.ToString(), "text/plain");
    }

    private static bool IsNaturalNumber(string input, out double value)
    {
        if (double.TryParse(input, out value) && value > 0)
        {
            return true;
        }
        value = -1;
        return false;
    }

    private double LCM(double a, double b) => ((a * b) / GCD(a, b));

    private double GCD(double a, double b)
    {
        while (b != 0)
        {
            double temp = b;
            b = a % b;
            a = temp;
        }
        return (double)a;
    }
}
