using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Realstate.Data.Negocio
{
    // Agregamos un nuevo Using a la clase.
    using System.Net.Mail;
    // El código de la clase es:
  public  class Correos
    {
        /*
         * Cliente SMTP
         * Gmail:  smtp.gmail.com  puerto:587
         * Hotmail: smtp.liva.com  puerto:25
         */
        SmtpClient server = new SmtpClient("smtp.gmail.com", 587);

        public Correos()
        {
            /*
             * Autenticacion en el Servidor
             * Utilizaremos nuestra cuenta de correo
             *
             * Direccion de Correo (Gmail o Hotmail)
             * y Contrasena correspondiente
             */
            server.Credentials = new System.Net.NetworkCredential("mardisresearch.engine@gmail.com", "M@rdis2018");
            server.EnableSsl = true;
        }

        public void MandarCorreo(MailMessage mensaje)
        {
            server.Send(mensaje);
        }
        public void enviar(string _subject, string _to, string _body,String adjunto) {

            try
            {
                Correos Cr = new Correos();
                MailMessage mnsj = new MailMessage();

                mnsj.Subject = _subject;

                mnsj.To.Add(new MailAddress(_to));

                mnsj.From = new MailAddress("mardisresearch.engine@gmail.com", "Mardis Research");

                /* Si deseamos Adjuntar algún archivo*/
                mnsj.Attachments.Add(new Attachment(adjunto));

                mnsj.Body = _body;

                /* Enviar */
                Cr.MandarCorreo(mnsj);
              //  Enviado = true;

              
            }
            catch (Exception ex)
            {
           
            }

        }
    }
}
