using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BankApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SecurityTestController : ControllerBase
    {
    

        // GET api/<SecurityTestController>/5
        [HttpGet("{ip}")]
        public string Get(string ip)
        {
            var cmd = "ping -c " + ip;
            ProcessStartInfo processStartInfo = new ProcessStartInfo("cmd", "-c \"" + cmd + "\"");
            processStartInfo.RedirectStandardOutput = true;
            processStartInfo.UseShellExecute = false;
            Process? process = Process.Start(processStartInfo);
            process?.WaitForExit();
            return "value";
        }

    
    }
}
