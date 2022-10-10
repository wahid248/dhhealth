using Core.Abstruct.Base;
using Core.Entities;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using Web.ViewModels;

namespace Web.Services
{
    public class EmailService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IConfiguration config;

        public EmailService(IUnitOfWork unitOfWork, IConfiguration config)
        {
            this.unitOfWork = unitOfWork;
            this.config = config;
        }

        public async Task SendEmail(EmailViewModel model)
        {
            var server = config.GetValue<string>("AWS:SES:Server");
            var port = config.GetValue<int>("AWS:SES:Port");
            var userName = config.GetValue<string>("AWS:SES:UserName");
            var password = config.GetValue<string>("AWS:SES:Password");

            var message = new MailMessage
            {
                IsBodyHtml = true,
                From = new MailAddress(model.Form),
                Subject = model.Subject,
                Body = model.Message,
                Priority = MailPriority.High
            };
            if (model.Attachment != null)
            {
                message.Attachments.Add(new Attachment(model.Attachment.OpenReadStream(), model.Attachment.FileName));
            }
            message.To.Add(new MailAddress(model.To));


            using var client = new System.Net.Mail.SmtpClient(server, port)
            {
                Credentials = new NetworkCredential(userName, password),
                EnableSsl = true
            };

            try
            {
                client.Send(message);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            var emailLog = new EmailLog()
            {

                Name = model.Name,
                PhoneNo = model.PhoneNo,
                Email = model.Email,
                To = model.To,
                Form = model.Form,
                Subject = model.Subject,
                EmailTemplateName = model.EmailTemplateName

            };

            await unitOfWork.EmailLoggingRepository.AddAsync(emailLog);
            await unitOfWork.SaveChangesAsync();
        }
    }
}
