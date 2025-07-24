using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace negocio
{
    public class EmailService
    {
        private MailMessage email;
        private SmtpClient server;

        public EmailService()
        {
            server = new SmtpClient();
            server.Credentials = new NetworkCredential("Menycho112@gmail.com", "twla airc kgqc wkfy");
            server.EnableSsl = true;
            server.Port = 587;
            server.Host = "smtp.gmail.com";
        }

        public void armarCorreo(string emailDestino, string cuerpo, string nombre)
        {
            email = new MailMessage();
            email.From = new MailAddress("noresponder@eCommeny.com");
            email.To.Add(emailDestino);
            email.Subject = "Contacto desde eCommeny";
            email.IsBodyHtml = true;
            email.Body = "Hola " + nombre + "! Recibimos tu solicitud de contacto sobre: <br><br>" + 
                cuerpo + "<br><br>A la brevedad un profesional se estará comunicando con vos";            
        }

        public void enviarEmail()
        {
            try
            {
                server.Send(email);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al enviar el correo: " + ex.Message);
            }
        }
    }
}
