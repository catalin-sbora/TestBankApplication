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
            if (!System.Net.IPAddress.TryParse(ip, out _))
            {
                // Alternatively, allow specific hostnames by whitelisting, but here only IPs are allowed.
                throw new ArgumentException("Invalid IP address format.", nameof(ip));
            }
            // Use platform-appropriate ping command
            ProcessStartInfo processStartInfo = new ProcessStartInfo("ping")
            {
                RedirectStandardOutput = true,
                UseShellExecute = false
            };
            processStartInfo.ArgumentList.Add(ip);
            Process? process = Process.Start(processStartInfo);
            process?.WaitForExit();
            return "value";
        }

    
    }
}
