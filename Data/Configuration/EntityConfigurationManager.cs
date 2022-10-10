using Microsoft.EntityFrameworkCore;

namespace Data.Configuration
{
    public class EntityConfigurationManager
    {
        public static void Configure(ModelBuilder builder)
        {

            builder.ApplyConfiguration(new ImageConfig())
                .ApplyConfiguration(new SectionConfig())
                .ApplyConfiguration(new PageConfig())
                .ApplyConfiguration(new PageSectionsConfig())
                .ApplyConfiguration(new ContactUsConfig())
                .ApplyConfiguration(new CustomerConfig())
                .ApplyConfiguration(new EmailTemplateConfig())
                .ApplyConfiguration(new EmailLogConfig())
                .ApplyConfiguration(new JobPostConfig())
                .ApplyConfiguration(new NewsConfig());
        }
    }
}
