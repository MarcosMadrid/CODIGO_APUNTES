using Microsoft.AspNetCore.Mvc;
using System.Net.Mail;
using MailMvcCore.Helpers;

namespace MailMvcCore.Controllers
{
    public class MailController : Controller
    {
        private HelperCreatorMail mailCreator;
        private HelperCredentials credentialsMail;

        public MailController(HelperCreatorMail createMail, HelperCredentials credentialsMail)
        {
            this.mailCreator = createMail;
            this.credentialsMail = credentialsMail;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SendMail(string para, string asunto, string mensaje, IFormFile file)
        {
            MailMessage mail = mailCreator.CreateMail(para, asunto, mensaje);
            mail = await mailCreator.AddImgMailAsync(file);

            SmtpClient smtp = credentialsMail.GetCredentials();
            smtp = credentialsMail.SetNetworkCredential(smtp);

            await smtp.SendMailAsync(mail);
            ViewData["MENSAJE"] = "Email enviado correctamente";

            return View("Index");
        }

    }
}
