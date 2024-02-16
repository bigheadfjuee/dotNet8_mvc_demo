using System.Diagnostics;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using mvc8.Models;

namespace mvc8.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IConfiguration _configuration;

    public HomeController(ILogger<HomeController> logger, IConfiguration configuration)
    {
        _logger = logger;
        _configuration = configuration;
    }

    public IActionResult Index()
    {
        var key_value = _configuration.GetSection("Key_Value").Get<Dictionary<string, string>>();
        var games = _configuration.GetSection("Games").Get<List<string>>();

        ViewBag.Key_Value = key_value;
        ViewBag.Games = games;

        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(
            new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier }
        );
    }

    [HttpPost]
    public IActionResult AjaxPostForm([FromForm] HomeModel model)
    {
        Console.WriteLine(model.ToString());

        Console.WriteLine(model.JsonArr);
        // FormData 要傳 array 只能先轉成 JSON 字串，接收端再處理轉回 array
        return Ok(Json("ok"));
    }

    [HttpPost]
    public ActionResult AjaxPostJson([FromBody] HomeModelJ model)
    {
       // 直接使用 FromBody 接收 JSON 格式的資料
        Console.WriteLine(model.ToString());
        return Ok(Json("ok"));
    }
}
