using Microsoft.AspNetCore.Mvc;

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
        if (!IsNaturalNumber(x, out long xVal) || !IsNaturalNumber(y, out long yVal))
        {
            return Content("NaN", "text/plain");
        }

        ulong lcm = (ulong)LCM((ulong)xVal, (ulong)yVal);
        return Content(lcm.ToString(), "text/plain");
    }

    private static bool IsNaturalNumber(string input, out long value)
    {
        if (long.TryParse(input, out value) && value > 0)
        {
            return true;
        }
        value = -1;
        return false;
    }

    private ulong LCM(ulong a, ulong b) => ((a * b) / GCD(a, b));

    private ulong GCD(ulong a, ulong b)
    {
        while (b != 0)
        {
            ulong temp = b;
            b = a % b;
            a = temp;
        }
        return (ulong)a;
    }
}
