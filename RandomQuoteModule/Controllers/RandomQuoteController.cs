using Microsoft.AspNetCore.Mvc;

namespace RandomQuoteModule.Controllers;

[ApiController]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/randomquote")]
public class RandomQuoteV1Controller : Controller
{
    [HttpGet]
    public ActionResult<string> Index()
    {
        return new ActionResult<string>("Hello World - V1");
    }
}

[ApiController]
[ApiVersion("2.0")]
[Route("api/v{version:apiVersion}/randomquote")]
public class RandomQuoteV2Controller : Controller
{
    [HttpGet]
    public ActionResult<string> Index()
    {
        return new ActionResult<string>("Hello World - V2");
    }
}