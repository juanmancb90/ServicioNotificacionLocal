/*
 * Nombre de la Clase: Program
 * Descripcion: Clase de ejecucion del servicio windows
 * Autor: Equipo Makross - Grupo de Desarrollo
 * Fecha: 03/01/2016
 */

/*
 * Listado de Metodos:
 * >> Service()
 * >> void OnStart(string[] args)
 * >> void TimerTick(object sender, ElapsedEventArgs e)
 * >> void OnStop()
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using Entidades;
using BL;

namespace ServicioNotificacion
{
    public partial class Service : ServiceBase
    {
        private Timer timer1 = null;
        private string startSendEmail = "17:00";
        private string endSendEmail = "17:30";
        private string cs = ConfigurationManager.ConnectionStrings[0].ConnectionString;

        /* 
         * Metodo
         * Descripcion: Metodo inicializador
         * Entrada: void
         * Salida: void
         */
        public Service()
        {
            InitializeComponent();
        }

        /* 
         * Metodo
         * Descripcion: Metodo que comienza la ejecucion del servicio windows
         * Entrada: string[] args
         * Salida: void
         */
        protected override void OnStart(string[] args)
        {
            try
            {
                timer1 = new Timer();
                this.timer1.AutoReset = true;
                this.timer1.Interval = 600000;
                this.timer1.Elapsed += new ElapsedEventHandler(this.TimerTick);
                timer1.Enabled = true;
                Library.EventErrorHandler("Service Windows Started");
            }
            catch (Exception ex)
            {
                Library.EventErrorHandler(ex.ToString());
            }
           
        }

        /* 
         * Metodo
         * Descripcion: Metodo que ejecuta los ciclos de ejecucion del timer
         * Entrada: object sender, ElapsedEventArgs e
         * Salida: void
         */
        private void TimerTick(object sender, ElapsedEventArgs e)
        {
            string horaActual = DateTime.Now.ToShortTimeString();

            if (horaActual == startSendEmail || horaActual == endSendEmail)
            {
                try
                {
                    var fechaActual = DateTime.Today.ToString("yyyy-MM-dd");
                    PedidosBL context = new PedidosBL();
                    LoginAuditoriaBL contexto = new LoginAuditoriaBL();
                    bool rst = context.ObtenerEstadoPedidos(cs, fechaActual);
                    Library.EventErrorHandler(rst.ToString());
                    if (rst == false)
                    {
                        Library.EventErrorHandler("Send Email to User");
                        string user = contexto.ObtenerEmailUsuario(cs, fechaActual);
                        Library.EventErrorHandler(user);
                        string Msg = "Buena Tarde" + '\n' + "No ha sincronizado los pedidos del día con el sistema central, por favor realizarlas";
                        Library.SendEmail(user, "Notificación de Sincronización no realizada " + DateTime.Now.ToString(), Msg);
                    }
                }
                catch (Exception ex)
                {
                    Library.EventErrorHandler(ex.ToString());
                }
            }
           // Library.EventErrorHandler("Timer ticked and some job has been done successfully");
        }

        /* 
         * Metodo
         * Descripcion: Metodo que detiene el servicio windows
         * Entrada: void
         * Salida: void
         */
        protected override void OnStop()
        {
            timer1.Enabled = false;
            Library.EventErrorHandler("Service stoped");
        }
    }
}
