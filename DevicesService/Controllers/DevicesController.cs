using DevicesService.Data;
using DevicesService.Modules;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace DevicesService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DevicesController : ControllerBase
    {
        //private readonly ILogger<DevicesController> _logger;

        //private readonly string WWWROOT = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot");

        //public DevicesController(ILogger<DevicesController> logger)
        //{
        //    _logger = logger;
        //}


        //[HttpPost("Fingerprint/Enrollment")]
        //public async Task<ActionResult> Fingerprint_Enrollment([FromBody] object enrollment)
        //{

        //    var filePath = WWWROOT + @"\fingerprint\enrollment" + @"\data_v1.json";

        //    await FileModule.WriteAllTextAsync(filePath, enrollment.ToString());

        //    return Ok();
        //}

        //[HttpPost("Passport/Scanning")]
        //public async Task<ActionResult> Passport_Scanning([FromBody] PassportScannedResult_V1 scan)
        //{
            
        //    var filePath = WWWROOT + @"\passport\scan";

        //    await scan.SaveAsync(filePath);

        //    return Ok();
        //}

    }
}
