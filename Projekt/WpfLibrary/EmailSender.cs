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

        public static Guests? Guest { get; set; }
        public static Stopwatch Clock { get => clock; }
        public static int Code { get; set; }


        /// <summary>
        /// Sends email message with new random
        /// 4 digit number into given email address.
        /// </summary>
        public static void SendAgainEmail()
        {
            if (Guest != null)
                SendRegisterEmail(Guest);
        }

        /// <summary>
        /// Sends email message with random 4 digit  
        /// code into a given email address.
        /// </summary>
        /// <param name="user"></param>
        public static void SendRegisterEmail(Guests guest)
        {
            Guest = guest;
            int code = GenerateNumberAndCount();
            MimeMessage message = new MimeMessage();
            message.Body = new TextPart("plain")
            {
                Text = $"Witaj {Guest.Name},\n" +
                $"aby aktywować konto wpisz podany kod: {code}."
            };
            SendEmail(Guest, message);
        }

        /// <summary>
        /// Sends email message with random 4 digit  
        /// code into a given email address. 
        /// </summary>
        /// <param name="email"></param>
        /// <returns>True if email has been sent succesfully, otherwise false.</returns>
        public static bool SendRecoverPasswordCode(string email)
        {
            var g = DatabaseConnector.GuestByEmailOrLogin(email);
            if (g == null)
                return false;

            Guest = new Guests
            {
                Name = g.Name,
                Surname = g.Surname,
                Login = g.Login,
                Password = g.Password,
                Email = g.Email,
            }; 

            int code = GenerateNumberAndCount();
            MimeMessage message = new MimeMessage();
            message.Body = new TextPart("plain")
            {         
                Text = $"Witaj {Guest.Name},\n" +
                $"aby zresetować hasło wpisz podany kod: {code}."
            };
            SendEmail(Guest, message);
            return true;
        }

        private static void SendEmail(Guests guest, MimeMessage message)
        {
            message.From.Add(new MailboxAddress("Kod weryfikacyjny", "programowanieobiektoweprojekt@gmail.com"));
            message.To.Add(MailboxAddress.Parse(guest.Email));
            message.Subject = "Obiekt sportowy";

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
            return Code = r.Next(1000, 9999);
        }

    }
}
