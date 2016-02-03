using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace SmtpMails
{
	class MailSender
	{
		public SmtpClient SmtpServer;
		public MailSender(SmtpClient SmtpServer)
		{
			this.SmtpServer = SmtpServer;
		}

		private MailMessage CreateMail()
		{
			using (StreamReader reader = File.OpenText("~/MailTemplate.html"))
			{
				MailMessage mail = new MailMessage();
				mail.From = new MailAddress("abc@gmail.com");
				mail.To.Add("testsmtp@gmail.com");
				mail.Subject = "Test SMTP Mail";
				mail.IsBodyHtml = true;
				mail.Body = reader.ReadToEnd();
				mail.Body = mail.Body.Replace("{UserName}", "User");
				mail.Body = mail.Body.Replace("{Link}", "Link to Sth");
				return mail;
			}
		}

		public void SendMails()
		{
			MailMessage mail = CreateMail();
			for (int i = 0; i < 1; i++)
			{
				SmtpServer.Send(mail);
				Console.WriteLine("Message Sent " + i);
			}
		}
	}
}
