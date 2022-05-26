using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Projekt
{
    public static class ConfirmationCode
    {
        public static int Code { get; set; }
        public static async Task<int> GenerateNumberAndCount()
        {
            var r = new Random();
            Code = r.Next(4);
            Task clock = Task.Run(() => Clock());
            return Code;
        }
            
        static async Task Clock()
        {
            Thread.Sleep(900000);
            Code = 0;
        }

    }
}
