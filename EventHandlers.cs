using System;
using System.Collections.Generic;
using System.Text;
using static ThreadTest.MessageProcessingDemo;

namespace ThreadTest
{
   public class EventHandlers
    {

        public void Handler_Count(string messagecount)
        {
            Console.WriteLine(messagecount);
          

        }

        public void Handler_Time(string time)

        {
           
         Console.WriteLine(time);
        }
    }
}
