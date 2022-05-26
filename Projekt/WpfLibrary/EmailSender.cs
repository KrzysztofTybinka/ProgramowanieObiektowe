using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;

namespace Projekt
{
    public class EmailSender
    {
        static private string from = "programowanieobiektowe@o2.pl";
        static private string? to;
        static string subject = "Test Email";
        static string body = "Confirm your registration typing given code";
        static string username = "093cc53135e966";
        static string password = "f48c5d7871762e";
        static string host = "smtp.mailtrap.io";
        static int port = 587;

        public static void SendEmail(string recipient, int value)
        {
            to = recipient;
            body += Convert.ToString(value);
            SmtpClient client = new SmtpClient(host, port)
            {
                Credentials = new NetworkCredential(username, password),
                EnableSsl = true
            };
            client.Send(from, to, subject, body);
        }

    }
}
