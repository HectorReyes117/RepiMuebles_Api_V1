using System.Net;
using System.Net.Mail;

namespace MuebleriaRepiAPI.Perfiles
{
    public class EnviarCorreo
    {
        private readonly IConfiguration configuration;

        public EnviarCorreo(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public void Enviar(string nombre, string cedula,string producto, string apellido)
        {
            string emailOrigin = "RepiMueblesOnline@gmail.com";
            string pass = "contraseña del correo aqui";
            string emailDestino = "RepiMueblesOnline@gmail.com";

            MailMessage oMailMessage = new MailMessage(emailOrigin, emailDestino, "Compra", $@"<p><strong>{nombre} {apellido}</strong> cedula: <strong> {cedula}</strong>, ha realizado una solicitud de compra con el siguiente producto: <strong> {producto}</strong> .</p><p>Por favor revise la solicitud.</p>");

            oMailMessage.IsBodyHtml = true;

            SmtpClient osmtpClient = new SmtpClient("smtp.gmail.com");
            osmtpClient.EnableSsl = true;
            osmtpClient.UseDefaultCredentials = false;

            osmtpClient.Port = 587;
            osmtpClient.Credentials = new NetworkCredential(emailOrigin, pass);
            osmtpClient.Send(oMailMessage);
            osmtpClient.Dispose();
        }

        public void EnviarUsuario(string producto, string email)
        {
            string emailOrigin = "RepiMueblesOnline@gmail.com";
            string pass = "contraseña del correo aqui";
            string emailDestino = email;

            MailMessage oMailMessage = new MailMessage(emailOrigin, emailDestino, "Compra", $@"Ha realizado una solicitud de compra del siguiente producto: <strong>{producto}</strong>");

            oMailMessage.IsBodyHtml = true;

            SmtpClient osmtpClient = new SmtpClient("smtp.gmail.com");
            osmtpClient.EnableSsl = true;
            osmtpClient.UseDefaultCredentials = false;

            osmtpClient.Port = 587;
            osmtpClient.Credentials = new NetworkCredential(emailOrigin, pass);
            osmtpClient.Send(oMailMessage);
            osmtpClient.Dispose();
        }
    }
}
