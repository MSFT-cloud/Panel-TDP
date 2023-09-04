﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Windows;
using System.Windows.Input;

namespace Power_Control_Panel.PowerControlPanel.Classes.TaskScheduler
{
    public class TaskScheduler
    {
        public static SecretNest.TaskSchedulers.SequentialScheduler scheduler;
        public static Thread taskScheduler;
        public static TaskFactory taskFactory = new TaskFactory(scheduler);


        public static void startScheduler()
        {
            scheduler = new SecretNest.TaskSchedulers.SequentialScheduler(true);

            taskScheduler = new Thread(ThreadHandler);
            taskScheduler.Start();
        }

        public static void ThreadHandler()
        {


            scheduler.Run(); //This will block this thread until the scheduler disposed.
        }
        public static void runTask(Action action)
        {
            //Debug.WriteLine("Task started " + DateTime.Now.ToString() + " Task Name " + action.Method.ToString());
            var result = taskFactory.StartNew(action);

        }

        public static void closeScheduler()
        {
            scheduler.Dispose();

        }


    

       
    }
}
