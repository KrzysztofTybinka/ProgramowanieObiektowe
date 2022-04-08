using System;
using System.Text;
using System.IO;


namespace Lab03
{
    public class ConsoleLogger : WriterLogger
    {
        public ConsoleLogger() 
        {
            writer = Console.Out;
        }
            
        public override void Dispose()
        {
            // nothing here ...
        }
    }
}
