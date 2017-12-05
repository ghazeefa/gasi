using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Quartz;
using Quartz.Impl;

namespace DeadlineManagmentSystem.Scheduler
{
    public class JobScheduler
    {
        public static void Start()
         {
            IScheduler scheduler = StdSchedulerFactory.GetDefaultScheduler();
            scheduler.Start();

            IJobDetail jobDetail = JobBuilder.Create<EmailJob>()
    .WithIdentity("theJob")
    .Build();
            IJobDetail firstJob = JobBuilder.Create<DayJob>()
               .WithIdentity("firstJob")
               .Build();

            ITrigger firstTrigger = TriggerBuilder.Create()
                             .WithIdentity("firstTrigger")
                             .StartNow()
                              .WithCronSchedule("0 0/1 * * * ?")
                             .Build();


            //IJobDetail secondJob = JobBuilder.Create<WeekJob>()
            //               .WithIdentity("secondJob")
            //               .Build();

            //ITrigger secondTrigger = TriggerBuilder.Create()
            //                 .WithIdentity("secondTrigger")
            //                 .StartNow()
            //                  .WithCronSchedule("0/10 * * * * ?")
            //                 .Build();

            scheduler.ScheduleJob(firstJob, firstTrigger);
            //scheduler.ScheduleJob(secondJob, secondTrigger);
            //IJobDetail firstJob = JobBuilder.Create<FirstJob>()
            //   .WithIdentity("firstJob")
            //   .Build();
            //IJobDetail secondJob = JobBuilder.Create<SecondJob>()
            //   .WithIdentity("secondJob")
            //   .Build();


            ITrigger TweentySecondTrigger = TriggerBuilder.Create()
               .WithIdentity("TweentySecondTrigger")
               // fires 
               .WithCronSchedule("0/20 * * * * ?")
               // start immediately
               .StartAt(DateBuilder.DateOf(DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second, DateTime.Now.Day, DateTime.Now.Month, DateTime.Now.Year))
               .Build();
            ITrigger TenSecondTrigger = TriggerBuilder.Create()
           .WithIdentity("TweentySecondTrigger")
           // fires 
           .WithCronSchedule("0/10 * * * * ?")
           // start immediately
           .StartAt(DateBuilder.DateOf(DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second, DateTime.Now.Day, DateTime.Now.Month, DateTime.Now.Year))
           .Build();
            //EveryDay Trigger
            ITrigger everydayTrigger = TriggerBuilder.Create()
                .WithIdentity("everydayTrigger")
                // fires 
                .WithCronSchedule("0 0 9 1/1 * ?")
                // start immediately
                .StartAt(DateBuilder.DateOf(DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second, DateTime.Now.Day, DateTime.Now.Month, DateTime.Now.Year))
                .Build();
            
            //Weekly Trigger
            ITrigger WeeklyTrigger = TriggerBuilder.Create()
          .WithIdentity("WeeklyTrigger")
          // fires on each sunday at 9 o clock 
          .WithCronSchedule("0 0 9 ? * SUN")
          // start immediately
          .StartAt(DateBuilder.DateOf(DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second, DateTime.Now.Day, DateTime.Now.Month, DateTime.Now.Year))
          .Build();
            
            //Triger Monthly
            ITrigger MonthlyTrigger = TriggerBuilder.Create()
              .WithIdentity("MonthlyTrigger")
              // fires  at first date and on 9 o clock at start of each month
              .WithCronSchedule("0 0 9 1 * ?")
              // start immediately
              .StartAt(DateBuilder.DateOf(DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second, DateTime.Now.Day, DateTime.Now.Month, DateTime.Now.Year))
              .Build();

            //Triger Quaterly
            ITrigger QuaterlyTrigger = TriggerBuilder.Create()
              .WithIdentity("QuaterlyTrigger")
              // fires  at 9 o clock at start ofeach month
              .WithCronSchedule("0 0 9 1 1/3 ? *")
              // start immediately
              .StartAt(DateBuilder.DateOf(DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second, DateTime.Now.Day, DateTime.Now.Month, DateTime.Now.Year))
              .Build();
            //Triger After Six Months
            ITrigger BiAnnualTrigger = TriggerBuilder.Create()
              .WithIdentity("BiAnnualTrigger")
              // fires  at 9 o clock at start ofeach month
              .WithCronSchedule("0 0 9 1 1/6 ? *")
              // start immediately
              .StartAt(DateBuilder.DateOf(DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second, DateTime.Now.Day, DateTime.Now.Month, DateTime.Now.Year))
              .Build();
            //Trigger Yearly
            ITrigger yearlyTrigger = TriggerBuilder.Create()
                .WithIdentity("yearlyTrigger")
                // fires 
                .WithCronSchedule("0 0 9 1 1 ? *")
                // start immediately
                .StartAt(DateBuilder.DateOf(DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second, DateTime.Now.Day, DateTime.Now.Month, DateTime.Now.Year))
                .Build();
        


            var dictionary = new Dictionary<IJobDetail, Quartz.Collection.ISet<ITrigger>>();
            dictionary.Add(jobDetail, new Quartz.Collection.HashSet<ITrigger>()
                            {TweentySecondTrigger,
                                everydayTrigger,
                                WeeklyTrigger,
                                MonthlyTrigger,
                                QuaterlyTrigger,
                                BiAnnualTrigger,
                                yearlyTrigger
                            });
            scheduler.ScheduleJobs(dictionary, true);

            ////IJobDetail job = JobBuilder.Create<EmailJob>().Build();

            //////ITrigger trigger = TriggerBuilder.Create()
            //////    .WithDailyTimeIntervalSchedule
            //////      (s =>
            //////         s.WithIntervalInHours(24)
            //////        .OnEveryDay()
            //////        .StartingDailyAt(TimeOfDay.HourAndMinuteOfDay(9, 0)).WithRepeatCount(4)
            //////      )
            //////    .Build();
            ////ITrigger trigger = TriggerBuilder.Create()
            ////    .WithIdentity("trigger1", "group1")
            ////    .StartNow()
            ////    .WithSimpleSchedule(x => x
            ////        .WithIntervalInSeconds(10)
            ////        .RepeatForever())
            ////    .Build();
            ////scheduler.ScheduleJob(job, trigger);
            //////scheduler.ScheduleJob(job, trigger);

            ////// scheduler.DeleteJob(new JobKey("J_Email"));


            //IJobDetail job = JobBuilder.Create<EmailJob>().StoreDurably().WithIdentity("J_Email", "J_Mailing").Build();

            //scheduler.AddJob(job, true /* bool replace */ ); /* Add the given IJob to the Scheduler - with no associated ITrigger.  */


            //ITrigger trigger = TriggerBuilder.Create()
            //                    .WithIdentity("MailTrigger1", "T_Mail1")
            //                    .StartNow()
            //                    .WithSimpleSchedule(x => x.WithMisfireHandlingInstructionIgnoreMisfires()
            //                        .WithIntervalInSeconds(3)
            //                        .RepeatForever())
            //                    .ForJob(job)
            //                    .Build();


            //ITrigger triggernew = TriggerBuilder.Create()
            //                   .WithIdentity("MailTrigger", "T_Mail")
            //                   .StartNow()
            //                   .WithSimpleSchedule(x => x.WithMisfireHandlingInstructionIgnoreMisfires()
            //                       .WithIntervalInSeconds(5)
            //                       .RepeatForever())
            //                   .ForJob(job)
            //                   .Build();


            //scheduler.ScheduleJob(triggernew);
            //scheduler.ScheduleJob(trigger);

            scheduler.Start();
        }
    }
}