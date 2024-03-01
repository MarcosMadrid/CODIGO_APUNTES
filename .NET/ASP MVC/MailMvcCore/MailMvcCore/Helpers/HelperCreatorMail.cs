using MailMvcCore.Helpers.Path;
using System.Net.Mail;

namespace MailMvcCore.Helpers
{
    public class HelperCreatorMail
    {
        internal MailMessage mail;

        public HelperPathProvider helperPathProvider { get; set; }
        private IConfiguration configuration;

        public HelperCreatorMail(IConfiguration configuration, HelperPathProvider helperPath)
        {
            mail = new MailMessage();
            this.configuration = configuration;
            this.helperPathProvider = helperPath;
        }

        public MailMessage CreateMail(string para, string asunto, string mensaje)
        {
            this.mail = new MailMessage();
            string user = this.configuration.GetValue<string>("MailSettings:Credentials:User");
            mail.From = new MailAddress(user);
            mail.To.Add(para);
            mail.Subject = asunto;
            mail.Body = mensaje;
            mail.IsBodyHtml = true;
            mail.Priority = MailPriority.Normal;

            return mail;
        }


        public async Task<MailMessage> AddImgMailAsync(IFormFile file)
        {
            if (file != null)
            {
                string fileName = file.FileName;
                string path = this.helperPathProvider.MapPath(fileName);
                using (Stream stream = new FileStream(path, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
                Attachment attachment = new Attachment(path);
                this.mail.Attachments.Add(attachment);
            }
            return this.mail;
        }
    }
}
