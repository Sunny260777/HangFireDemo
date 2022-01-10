using Hangfire;
using HangFireDemo.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace HangFireDemo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HangFireController : ControllerBase
    {
        [HttpPost]
        [Route("[action]")]
        public IActionResult Login(login model) {
            if (model.username=="sunny" && model.password=="123")
            {
                //BackgroundJob.Enqueue(() => SendThankYouMail("Thank You email"));
                //BackgroundJob.Schedule(() => SendWelcomeMail("Welcome Email"),TimeSpan.FromSeconds(30));
                RecurringJob.AddOrUpdate(() => recurringMethod("Trail Minute Remaining",100), Cron.Minutely);
                return Ok("Success");
            }
            else
            {
                return null;
            }     
        }

        public void SendThankYouMail(string text) 
        {
            Console.WriteLine(text);
        }

        public void SendWelcomeMail(string text)
        {
            Console.WriteLine(text);
        }

        public void recurringMethod(string text,int num)
        {
            Console.WriteLine(text + " :- " + num);
            num--;
        }

    }
}
