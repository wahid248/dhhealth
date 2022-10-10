using Core.Entities;
using Data.Base;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Configuration
{
    public class EmailTemplateConfig : EntityConfigurationBase<EmailTemplate, int>
    {
        public override void Configure(EntityTypeBuilder<EmailTemplate> builder)
        {
            // write configs here
            Seed(builder);
            base.Configure(builder);
        }

        public void Seed(EntityTypeBuilder<EmailTemplate> builder)
        {
            var createdOn = DateTime.UtcNow;

            builder.HasData(
                new EmailTemplate() { Id = 1, TemplateType = Core.Enums.EmailTemplate.EmailTemplates.UserConfirmation, TemplateName = "User Confirmation", Body = "<html><head><link href='https://fonts.googleapis.com/css?family=Roboto' rel='stylesheet'><style>body{font-family: 'Roboto';font-size: 1rem;background-color: #fff;}.content{Margin: 0 auto; max-width: 580px; padding: 10px;}.wrapper{width: 100%;border-radius: 3px;padding: 30px;}.wrapper img{height:150px; width:100px; display: block;margin-left: auto;margin-right: auto;width: 50%;}.footer{Margin-top: 10px; text-align: center; width: 100%;color: #999999;font-size:0.8rem;}.visit-dh-health{color: #2F8F9C;text-decoration: none;}</style></head><body> <div class=\"content\"> <div class=\"wrapper\"><b id=\"userName\"></b> <p>This is to inform you that your query has been received. Our team will contact you soon.</p><br><p>Thank you!.</p><p>Dh Health Team</p><p>Visit our Website <a class=\"visit-dh-health\" href=\"https://www.dh.health/ \">Dh.Health<a></p>. </div><div class=\"footer\"> <p>Proshanti 3rd & 4th Floor, House: 257 <br>Road: 1, Block: B, Bashundhara R/A,Dhaka 1229.</p><p>Powered by <a class=\"visit-dh-health\" href=\"https://www.dh.health/ \">Dh.Health<a></p>.</div></div></body></html>", CreatedBy = "SYSTEM", CreatedOn = createdOn },

             new EmailTemplate() { Id = 2, TemplateType = Core.Enums.EmailTemplate.EmailTemplates.UserQueryToAdmin, TemplateName = "User Query To Admin", Body = "<html><head><link href='https://fonts.googleapis.com/css?family=Roboto' rel='stylesheet'><style>body{font-family: 'Roboto';font-size: 1rem;background-color: #fff;}.content{Margin: 0 auto; max-width: 580px; padding: 10px;}.wrapper{width: 100%; border-radius: 3px;padding: 30px;}.wrapper img{height:150px; width:100px; display: block;margin-left: auto;margin-right: auto;width: 50%;}.footer{Margin-top: 10px; text-align: center; width: 100%;color: #999999;font-size:0.8rem;}.visit-dh-health{color: #2F8F9C;text-decoration: none;}</style></head><body> <div class=\"content\"> <div class=\"wrapper\"><b id=\"UserName\"></b> <p id=\"Contact\"></p> <p id=\"Email\"></p><p id=\"message\"></p></div><div class=\"footer\"> <p>Proshanti 3rd & 4th Floor, House: 257 <br>Road: 1, Block: B, Bashundhara R/A,Dhaka 1229.</p><p>Powered by <a class=\"visit-dh-health\" href=\"https://www.dh.health/ \">Dh.Health<a></p>.</div></div></body></html>", CreatedBy = "SYSTEM", CreatedOn = createdOn },

            new EmailTemplate() { Id = 3, TemplateType = Core.Enums.EmailTemplate.EmailTemplates.JobApplyConfirmation, TemplateName = "Job Apply Confirmation", Body = "<html><head><link href='https://fonts.googleapis.com/css?family=Roboto' rel='stylesheet'><style>body{font-family: 'Roboto';font-size: 1rem;background-color: #fff;}.content{Margin: 0 auto; max-width: 580px; padding: 10px;}.wrapper{width: 100%; border-radius: 3px;padding: 30px;}.wrapper img{height:150px; width:100px; display: block;margin-left: auto;margin-right: auto;width: 50%;}.footer{Margin-top: 10px; text-align: center; width: 100%;color: #999999;font-size:0.8rem;}.visit-dh-health{color: #2F8F9C;text-decoration: none;}</style></head><body> <div class=\"content\"> <div class=\"wrapper\"><b id=\"userName\"></b><p>Thank you for your application and interest in Digital Healthcare Solutions (DH) as your Employer of Choice.</p><br> <p>At this stage, your patience is appreciated while our Talent Acquisition Team reviews your application. If you are shortlisted for further steps, you will be contacted by one of our professionals regarding further steps in the selection process.</p><br><br><p>Best Regards,</p><p>Digital Healthcare Solutions (DH)</p></div></div></body></html>", CreatedBy = "SYSTEM", CreatedOn = createdOn },

             new EmailTemplate() { Id = 4, TemplateType = Core.Enums.EmailTemplate.EmailTemplates.AppliedJobToAdmin, TemplateName = "Applied Job To Admin", Body = "<html><head><link href='https://fonts.googleapis.com/css?family=Roboto' rel='stylesheet'><style>body{font-family: 'Roboto';font-size: 1rem;background-color: #fff;}.content{Margin: 0 auto; max-width: 580px; padding: 10px;}.wrapper{width: 100%; border-radius: 3px;padding: 30px;}.wrapper img{height:150px; width:100px; display: block;margin-left: auto;margin-right: auto;width: 50%;}.footer{Margin-top: 10px; text-align: center; width: 100%;color: #999999;font-size:0.8rem;}.visit-dh-health{color: #2F8F9C;text-decoration: none;}</style></head><body> <div class=\"content\"> <div class=\"wrapper\"><b id=\"applicantName\"></b> <p id=\"applicantContact\"></p><p id=\"applicantEmail\"></p></div><div class=\"footer\"> <p>Proshanti 3rd & 4th Floor, House: 257 <br>Road: 1, Block: B, Bashundhara R/A,Dhaka 1229.</p><p>Powered by <a class=\"visit-dh-health\" href=\"https://www.dh.health/ \">Dh.Health<a></p>.</div></div></body></html>", CreatedBy = "SYSTEM", CreatedOn = createdOn },
             
             new EmailTemplate() { Id = 5, TemplateType = Core.Enums.EmailTemplate.EmailTemplates.NewsSubscription, TemplateName = "News Subscription", Body = "<html><head><link href='https://fonts.googleapis.com/css?family=Roboto' rel='stylesheet'><style>body{font-family: 'Roboto';font-size: 1rem;background-color: #fff;}.content{Margin: 0 auto; max-width: 580px; padding: 10px;}.wrapper{width: 100%; border-radius: 3px;padding: 30px;}.wrapper img{height:150px; width:100px; display: block;margin-left: auto;margin-right: auto;width: 50%;}.footer{Margin-top: 10px; text-align: center; width: 100%;color: #999999;font-size:0.8rem;}.visit-dh-health{color: #2F8F9C;text-decoration: none;}</style></head><body> <div class=\"content\"> <div class=\"wrapper\"><b>Dear User, </b> <p>Thank you for your Subscribe.</p><p id=\"userEmail\"></p><p>Dh Health Team</p><p>Visit our Website <a class=\"visit-dh-health\" href=\"https://www.dh.health/ \">Dh.Health<a></p>. </div><div class=\"footer\"> <p>Proshanti 3rd & 4th Floor, House: 257 <br>Road: 1, Block: B, Bashundhara R/A,Dhaka 1229.</p><p>Powered by <a class=\"visit-dh-health\" href=\"https://www.dh.health/ \">Dh.Health<a></p>.</div></div></body></html>", CreatedBy = "SYSTEM", CreatedOn = createdOn });
        }
    }
}

