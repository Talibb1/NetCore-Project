using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using BaseLayer.Model;
using Service.Helper.Abstract;

namespace Service.Helper.Concrete
{
    public class SendEmailHelper : ISendEmailHelper
    {
        private readonly GmailInfoModel _gmailInfo;

        public SendEmailHelper(IOptions<GmailInfoModel> gmailInfo)
        {
            _gmailInfo = gmailInfo.Value;
        }

        public async Task SendEmail(string resetLink, string userEmail)
        {

            var smtp = new SmtpClient();
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential(_gmailInfo.Email, _gmailInfo.Password);
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.EnableSsl = true;
            smtp.Port = 587;
            smtp.Host = _gmailInfo.Host;

            var message = new MailMessage();
            message.From = new MailAddress(_gmailInfo.Email);
            message.To.Add(userEmail);
            message.IsBodyHtml = true;
            message.Subject = "SignUp | NetCore(SoftWare House) ";
            message.Body = $"<p><b>Click Link for apply to login cradiential<b></p><a href='{resetLink}'>Click Here</a> ";

            await smtp.SendMailAsync(message);

        }
    }
}
