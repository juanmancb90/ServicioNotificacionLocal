/*
 * Nombre de la Clase: LoginAuditoria
 * Descripcion: Clase que mapea la tabla TB_LoginAuditoria
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
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class LoginAuditoria
    {
        public int ID_Login { get; set; }
        public string NombreUsuario { get; set; }
        public System.DateTime FechaIngreso { get; set; }
    }
}
