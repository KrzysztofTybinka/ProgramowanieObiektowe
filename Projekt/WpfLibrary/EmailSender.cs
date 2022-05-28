using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;
using System.Threading;
using System.Diagnostics;

namespace Projekt
{
    public static class EmailSender
    {
        private static string from = "programowanieobiektowe@o2.pl";
        private static string? to;
        private static string subject = "Test Email";
        private static string body = "Confirm your registration typing given code";
        private static string username = "093cc53135e966";
        private static string password = "f48c5d7871762e";
        private static string host = "smtp.mailtrap.io";
        private static int port = 587;
        private static Stopwatch clock = new Stopwatch();

        public static User? User { get; set; }
        public static Stopwatch Clock { get => clock; }
        public static int Code { get; set; }

        public static void SendEmail(string recipient)
        {
            to = recipient;
            body += Convert.ToString(Code);
            SmtpClient client = new SmtpClient(host, port)
            {
                Credentials = new NetworkCredential(username, password),
                EnableSsl = true
            };
            client.Send(from, to, subject, body);
        }

        /// <summary>
        /// Generates random 4 digit number and assigns
        /// the result to ConfirmationCode.Code property.
        /// </summary>
        /// <returns>Random 4 digit number.</returns>
        public static int GenerateNumberAndCount()
        {
            var r = new Random();
            clock.Start();
            return Code = r.Next(4);
        }

    }
}
