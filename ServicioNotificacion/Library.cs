/*
 * Nombre de la Clase: Program
 * Descripcion: Clase de ejecucion del servicio windows
 * Autor: Equipo Makross - Grupo de Desarrollo
 * Fecha: 03/01/2016
 */

/*
 * Listado de Metodos:
 * >> void EventErrorHandler(string msn)
 * >> void EventErrorHandler(Exception ex)
 * >> void SendEmail(String ToEmail, String Subj, string Message)
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Configuration;
using System.Net.Mail;
using System.Net;

namespace ServicioNotificacion
{
    public static class Library
    {
        /* 
         * Metodo
         * Descripcion: Metodo que lleva registro de evento del servicio
         * Entrada: string msn
         * Salida: void
         */
        public static void EventErrorHandler(string msn)
        {
            StreamWriter sw = null;
            try
            {
                sw = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory+"\\LogFile.txt", true);
                sw.WriteLine(DateTime.Now.ToString() + ":" + msn);
                sw.Flush();
                sw.Close();
            }
            catch
            {
            }
        }

        /* 
         * Metodo
         * Descripcion: Metodo que lleva registro de evento de error del servicio
         * Entrada: Exception ex
         * Salida: void
         */
        public static void EventErrorHandler(Exception ex)
        {
            StreamWriter sw = null;
            try
            {
                sw = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + "\\LogFile.txr", true);
                sw.WriteLine(DateTime.Now.ToString() + ":" + ex.Source.ToString().Trim() + ";" + ex.Message.ToString().Trim());
                sw.Flush();
                sw.Close();
            }
            catch
            {
            }
        }

        /* 
         * Metodo
         * Descripcion: Metodo que envia el correo electronico al usuario logeado
         * Entrada: void
         * Salida: void
         */
        public static void SendEmail(String ToEmail, String Subj, string Message)
        {
            string HostAdd = "smtp-mail.outlook.com";
            string FromEmailId = "user@user.com";
            string Pass = "user123";

            //objeto del tipo mensaje
            MailMessage mailMensaje = new MailMessage();
            mailMensaje.From = new MailAddress(FromEmailId);
            mailMensaje.Subject = Subj;
            mailMensaje.Body = Message;
            mailMensaje.IsBodyHtml = true;

            string[] ToEmailIds = ToEmail.Split(';');
            foreach (var item in ToEmailIds)
            {
                mailMensaje.To.Add(new MailAddress(item));
            }
            //configuracion de conexion
            SmtpClient smtp = new SmtpClient();
            smtp.Host = HostAdd;

            //seguridad
            smtp.EnableSsl = true;
            NetworkCredential NetworkCred = new NetworkCredential();
            NetworkCred.UserName = mailMensaje.From.Address;
            NetworkCred.Password = Pass;
            smtp.UseDefaultCredentials = true;
            smtp.Credentials = NetworkCred;
            smtp.Port = 587;
            smtp.Send(mailMensaje);
        }
    }
}
