/*
 * Nombre de la Clase: LoginAuditoriaBL
 * Descripcion: Clase de logica de negocios
 * Autor: Equipo Makross - Grupo de Desarrollo
 * Fecha: 03/01/2016
 */

/*
 * Listado de Metodos:
 * >> LoginAuditoriaBL()
 * >> string ObtenerEmailUsuario(string cs, string fechaActual)
 */
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Entidades;

namespace BL
{
    public class LoginAuditoriaBL
    {
        /* 
         * Metodo
         * Descripcion: Metodo constructor
         * Entrada: void
         * Salida: void
         */
        public LoginAuditoriaBL() { }

        /* 
         * Metodo
         * Descripcion: Retorna el email del usuario logeado
         * Entrada: string cs, string fechaActual
         * Salida: string
         */
        public string ObtenerEmailUsuario(string cs, string fechaActual)
        {
            string emailUser = "";
            LoginAuditoriaDAL contexto = new LoginAuditoriaDAL(cs);
            VendedorDAL context = new VendedorDAL(cs);
            List<LoginAuditoria> data = contexto.ObtenerUsuarioLogeado(fechaActual);
            foreach (var item in data)
            {
                Vendedores Vendedor = context.ObtenerUsuarioEmail(cs,item.NombreUsuario );
                if (Vendedor != null)
                {
                    emailUser = Vendedor.Email;
                }   
            }

            return emailUser;
        }
    }
}
