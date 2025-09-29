using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services.AddControllers();

var app = builder.Build();

// Map controllers
app.MapControllers();
app.Run();

// Controller must be outside Program.cs in the same project or defined below
[ApiController]
[Route("lcm/abcnizamd_gmail_com")]
public class LCMController : ControllerBase
{
    [HttpGet]
    public IActionResult GetLCM([FromQuery] int x, [FromQuery] int y)
    {
        if (x <= 0 || y <= 0)
        {
            return Content("NaN", "text/plain");
        }

        int lcm = LCM(x, y);
        return Content(lcm.ToString(), "text/plain");
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
