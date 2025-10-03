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
        if (!IsNaturalNumber(x, out BigInteger xVal) || !IsNaturalNumber(y, out BigInteger yVal))
        {
            return Content("NaN", "text/plain");
        }

        BigInteger lcm = LCM(xVal, yVal);
        return Content((lcm).ToString(), "text/plain");
    }

    private bool IsNaturalNumber(string input, out BigInteger value)
    {
        if (BigInteger.TryParse(input, out value) && value > 0)
        {
            return true;
        }
        value = -1;
        return false;
    }

    private BigInteger LCM(BigInteger a, BigInteger b) => ((a * b) / GCD(a, b));

    private BigInteger GCD(BigInteger a, BigInteger b)
    {
        while (b != 0)
        {
            BigInteger temp = b;
            b = a % b;
            a = temp;
        }
        return (BigInteger)a;
    }
}
