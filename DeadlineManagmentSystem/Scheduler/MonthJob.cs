using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Quartz;
using Quartz.Impl;
using System.Net;
using System.Net.Mail;
using DeadlineManagementDB.Helper;
using DeadlineManagementDB;
namespace DeadlineManagmentSystem.Scheduler
{
    public class MonthJob:IJob
    {

        CommonHelper h = new CommonHelper();
        FileUploadedHelper fh = new FileUploadedHelper();
        public void Execute(IJobExecutionContext context)
        {

            // Send  Data
            //List<Vw_PendingFiles> p = h.GetPendingFiles(3);
            DateTime date = new DateTime();
            string deptName = "";
            string fileName = "";
            string message = "";
            for (int i = 0; i < p.Count; i++)
            {

                date = Convert.ToDateTime(p[i].datetoupload);
                deptName = p[i].UnitName;
                fileName = p[i].FileName;

                message = message + "Branch Name:" + deptName + " " + "File Name:" + fileName + " " + "Date:" + date + "@\n";

            }

            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("192.168.0.112");

                mail.From = new MailAddress("it@ckl.com.pk");
                mail.To.Add("it@ckl.com.pk");
                MailAddress copy = new MailAddress("it@ckl.com.pk");
                mail.CC.Add(copy);
                MailAddress copy6 = new MailAddress("asher@ckl.com.pk");
                mail.CC.Add(copy6);
                MailAddress copy1 = new MailAddress("asher@ckl.com.pk");
                mail.CC.Add(copy1);
                //MailAddress copy2 = new MailAddress("Farooq@ckl.com.pk");
                //mail.CC.Add(copy2);
                //MailAddress copy3 = new MailAddress("arshadaliyousafzai@ckl.com.pk");
                //mail.CC.Add(copy3);
                //MailAddress copy4 = new MailAddress("rqs@ckl.com.pk");
                //mail.CC.Add(copy4);
                //MailAddress copy5 = new MailAddress("usmansajjad@ckl.com.pk");
                //mail.CC.Add(copy5);
                mail.Subject = "Pending Report in Compliance";
                //mail.Body = "User" + " " + o.Hours + " " + "has overtime more then 2 hours";
                string message1 = "Following Details for pending reports" + "@\n";
                mail.Body = message1 + message;
                SmtpServer.Port = 25;
                SmtpServer.Credentials = new System.Net.NetworkCredential("it@ckl.com.pk", "Ask_From_H3k");
                SmtpServer.EnableSsl = false;

                SmtpServer.Send(mail);
                //MessageBox.Show("mail Send");
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.ToString());
            }
            List<Vw_PendingFiles> a = h.GetPendingFiles(3);
            for (int i = 0; i < a.Count; i++)
            {
                tblToUpload f = new tblToUpload();
                f.department_Id = a[i].DepartmentId;
                f.filetype_Id = a[i].FileType_Id;
                f.datetoupload = Convert.ToDateTime(a[i].datetoupload).AddDays(1);
                fh.AddFileToUpload(f);
            }

        }
    }
        
}