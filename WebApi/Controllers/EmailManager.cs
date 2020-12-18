using Entities_POJO;
using Newtonsoft.Json.Linq;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.Controllers
{
    public class EmailManager
    {
        public void SendEmail(Reservation res)
        {
            //data
            var Name = res.Fullname;
            var LastName = res.DateTime;
            var Email = res.Email;

            var apiKey = "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";
            var cliente = new SendGridClient(apiKey);
            var from = new EmailAddress("grupo_tm3@outlook.com", "Reserva cancha");
            var to = new EmailAddress(Email);
            var Data = new JObject();
            Data.Add("Name", Name);
            Data.Add("LastName", LastName);
            Data.Add("Email", Email);
            var msg = MailHelper.CreateSingleTemplateEmail(from, to, "d-0648945d0f184f38a78ff7d832f575cd", Data);
            var response = cliente.SendEmailAsync(msg);
        }
    }
}