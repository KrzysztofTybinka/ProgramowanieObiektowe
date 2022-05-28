using System;
using System.Diagnostics;
using MailKit.Net.Smtp;
using MailKit;
using MimeKit;
using System.Windows;

namespace Projekt
{
    public static class EmailSender
    {

        private static Stopwatch clock = new Stopwatch();

        public static User? User { get; set; }
        public static Stopwatch Clock { get => clock; }
        public static int Code { get; set; }

        public static void SendEmail(User user)
        {
            User = user;
            MimeMessage message = new MimeMessage();
            int code = GenerateNumberAndCount();

            message.From.Add(new MailboxAddress("Kod weryfikacyjny", "programowanieobiektoweprojekt@gmail.com"));
            message.To.Add(MailboxAddress.Parse(User.Email));
            message.Subject = "Obiekt sportowy";

            message.Body = new TextPart("plain")
            {
                Text = $"Witaj {User.Name},\n" +
                $"aby aktywować konto wpisz podany kod: {code}."
            };

            string emailAddress = "programowanieobiektoweprojekt@gmail.com";
            string password = "Zaq12wsx!";

            SmtpClient client = new SmtpClient();

            try
            {
                client.Connect("smtp.gmail.com", 465, true);
                client.Authenticate(emailAddress, password);
                client.Send(message);
            }
            catch (Exception)
            {
                MessageBox.Show("Coś poszło nie tak");
                Application.Current.Shutdown();
            }
            finally
            {
                client.Disconnect(true);
                client.Dispose();
            }

        }


        private static int GenerateNumberAndCount()
        {
            var r = new Random();
            clock.Start();
            return Code = r.Next(4);
        }

    }
}
