using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadTest
{
    class MessageProcessingDemo
    {

        public ConcurrentQueue<string> messageQueue = new ConcurrentQueue<string>();


        public void GenerateMessage()
        {
            Thread.Sleep(10);
            messageQueue.Enqueue($"{DateTime.UtcNow} : {Guid.NewGuid()}");

        }

        public string ProcessOneMessage()
        {
            // long running operatione
            Thread.Sleep(20);
            messageQueue.TryDequeue(out string result);
            return result;

        }

        public async Task<IEnumerable<string>> ProcessMultipleMessages(int numOfTasksToRun = 1)
        {
            Console.WriteLine(messageQueue.Count);
            List<Task<string>> listTask = new List<Task<string>>();

            for (int i = 0; i < numOfTasksToRun; i++)
            {
                listTask.Add(Task.Run(ProcessOneMessage));
            }

            var results = await Task.WhenAll(listTask.ToArray());
            return results;

        }


    }
}
