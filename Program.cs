using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services.AddControllers();

var app = builder.Build();

// Map controllers
app.MapControllers();
app.Run();

<<<<<<< HEAD
=======
// Controllers
>>>>>>> de70d3c4f63adb95232bca80fd58b6e7cf1bd33c
[ApiController]
[Route("lcm/abcnizamd_gmail_com")]
public class LCMController : ControllerBase
{
    [HttpGet]
    public IActionResult GetLCM([FromQuery] string x, [FromQuery] string y)
    {
        if (!IsNaturalNumber(x, out int xVal) || !IsNaturalNumber(y, out int yVal))
        {
            return Content("NaN");
        }

        int lcm = LCM(xVal, yVal);
        return Content(lcm.ToString());
    }

    private bool IsNaturalNumber(string input, out int value)
    {
        if (int.TryParse(input, out value) && value > 0)
        {
            return true;
        }
        value = -1;
        return false;
    }

    private int LCM(int a, int b) => (a * b) / GCD(a, b);

    private int GCD(int a, int b)
    {
        while (b != 0)
        {
            int temp = b;
            b = a % b;
            a = temp;
        }
        return a;
    }
}
