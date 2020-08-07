using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;

namespace ThreadTest
{
    class Program
    {
        static void Main(string[] args)
        {
            MessageProcessingDemo demo = new MessageProcessingDemo();

            demo.GenerateMessage();
            var a = demo.ProcessOneMessage();
            Console.WriteLine(a);

            Thread genMessage = new Thread(() =>
            {
                while (true)
                {
                    demo.GenerateMessage();
                }
            });
            Thread procMessage = new Thread(() =>
            {
                while (true)
                {
                    Stopwatch stopWatch = new Stopwatch();
                    List<string> resultMessages = new List<string>();
                    var messageCount = demo.messageQueue.Count;
                    //Console.WriteLine(messageCount);
                    if (messageCount > 50)
                    {
                        stopWatch.Start();
                        var resultMessage = demo.ProcessMultipleMessages(30).Result;
                        stopWatch.Stop();
                        TimeSpan ts = stopWatch.Elapsed;
                        string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
            ts.Hours, ts.Minutes, ts.Seconds,
            ts.Milliseconds);
                        Console.WriteLine("RunTime " + elapsedTime);
                    }
                    //else
                    //{
                    //    var resultMessage = demo.ProcessOneMessage();
                    //}
                    //foreach(var result in resultMessages)
                    //{
                    //    Console.WriteLine(resultMessages);
                    //}
                    //Console.WriteLine(resultMessage);
                }
            });

            genMessage.Start();
            procMessage.Start();
            //Thread.Sleep(1000);
            ////var resultMessage = demo.ProcessMessage();
            //Console.WriteLine(demo.messageQueue.Count);
        }
    }
}
