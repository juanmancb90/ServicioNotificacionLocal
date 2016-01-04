/*
 * Nombre de la Clase: Program
 * Descripcion: Clase de ejecucion del servicio windows
 * Autor: Equipo Makross - Grupo de Desarrollo
 * Fecha: 03/01/2016
 */

/*
 * Listado de Metodos:
 * >> void Main()
 * >>
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace ServicioNotificacion
{
    static class Program
    {
        /* 
         * Metodo
         * Descripcion: Metodo principal de ejecucion
         * Entrada: void
         * Salida: void
         */
        static void Main()
        {
            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[] 
            { 
                new Service() 
            };
            ServiceBase.Run(ServicesToRun);
        }
    }
}
