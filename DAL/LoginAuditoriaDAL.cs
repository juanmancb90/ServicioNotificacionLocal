/*
 * Nombre de la Clase: Program
 * Descripcion: Clase de ejecucion del servicio windows
 * Autor: Equipo Makross - Grupo de Desarrollo
 * Fecha: 03/01/2016
 */

/*
 * Listado de Metodos:
 * >> LoginAuditoriaDAL(string cs) 
 * >> List<LoginAuditoria> ObtenerUsuarioLogeado(string fechaActual)
 * >> LoginAuditoria MapearPedido(ConsultarUsuarioLogin_Result item)
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace DAL
{
    public class LoginAuditoriaDAL
    {
        private string cn;

        /* 
         * Metodo
         * Descripcion: Metodo constructor que recibe un string de conexion
         * Entrada: string cs
         * Salida: void
         */
        public LoginAuditoriaDAL(string cs) 
        {
            this.cn = cs;
        }

        /* 
         * Metodo
         * Descripcion: Permite retornar una lista de usuarios logeados en la apliacion
         * Entrada: string cs
         * Salida: void
         */
        public List<LoginAuditoria> ObtenerUsuarioLogeado(string fechaActual)
        {
            List<LoginAuditoria> usuario = new List<LoginAuditoria>();

            using (DB_AcmeEntities contexto = new DB_AcmeEntities())
            {
                var SQLUsuario = contexto.ConsultarUsuarioLogin(fechaActual);

                foreach (var item in SQLUsuario)
                {
                    LoginAuditoria pedidoActual = MapearPedido(item);
                    usuario.Add(pedidoActual);
                }
            }

            return usuario;
        }

        /* 
         * Metodo
         * Descripcion: Mapear un entidad
         * Entrada: ConsultarUsuarioLogin_Result item
         * Salida: LoginAuditoria
         */
        private LoginAuditoria MapearPedido(ConsultarUsuarioLogin_Result item)
        {
            LoginAuditoria usuario = new LoginAuditoria();
            usuario.ID_Login = item.ID_Login;
            usuario.NombreUsuario = item.NombreUsuario;
            usuario.FechaIngreso = item.FechaIngreso;
           
            return usuario;
        }
    }
}
