using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Quartz;
using Quartz.Impl;
using System.Net;
using System.Net.Mail;

namespace DeadlineManagmentSystem.Scheduler
{
    public class EmailJob:IJob
    {

        public void Execute(IJobExecutionContext context)
        {

            var yourJobName = context.JobDetail.Key.Name;

            using (var message = new MailMessage("ghazeefafatimacs@gmail.com", "user@live.co.uk"))
            {
                message.Subject = "Test";
                message.Body = "Test at " + DateTime.Now;
                using (SmtpClient client = new SmtpClient
                {
                    EnableSsl = true,
                    Host = "smtp.gmail.com",
                    Port = 587,
                    Credentials = new NetworkCredential("user@gmail.com", "password")
                })
                {
                    //client.Send(message);
                }
            }
        }

    }
}