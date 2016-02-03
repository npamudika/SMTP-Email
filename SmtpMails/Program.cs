using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Configuration;

namespace SmtpMails
{
	class Program
	{
		static void Main(string[] args)
		{
			try
			{
				SmtpClient SmtpServer = new SmtpClient("Host Name");
				SmtpServer.Port = 25;
				SmtpServer.EnableSsl = false;
				SmtpServer.UseDefaultCredentials = false;
				String userName = ConfigurationManager.AppSettings["UserName"];
				String password = ConfigurationManager.AppSettings["Password"];
				SmtpServer.Credentials = new System.Net.NetworkCredential(userName, password);

				MailSender mailSender = new MailSender(SmtpServer);
				Thread mailThread = new Thread(new ThreadStart(mailSender.SendMails));
				mailThread.Start();
				Console.ReadLine();
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.ToString());
				Console.Read();
			}
		}
	}
}
