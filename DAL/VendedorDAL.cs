/*
 * Nombre de la Clase: VendedorDAL
 * Descripcion: Clase de administracion de operaciones sobre la base de datos
 * Autor: Equipo Makross - Grupo de Desarrollo
 * Fecha: 03/01/2016
 */

/*
 * Listado de Metodos:
 * >> VendedorDAL(string cs)
 * >> Vendedores ObtenerUsuarioEmail(string cs, string p)
 * >> Vendedores MapearVendedor(ConsultarVendedor_Result item)
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace DAL
{
    public class VendedorDAL
    {
        private string cn;

        /* 
         * Metodo
         * Descripcion: Metodo constructor que recibe un string de conexion
         * Entrada: string cs
         * Salida: void
         */
        public VendedorDAL(string cs)
        {
            this.cn = cs;
        }

        /* 
         * Metodo
         * Descripcion: Permite ibtener el email del usuario logeado
         * Entrada: string cs, string p
         * Salida: Vendedores
         */
        public Vendedores ObtenerUsuarioEmail(string cs, string p)
        {
            Vendedores vendedor = new Vendedores();
            using(DB_AcmeEntities contexto = new DB_AcmeEntities())
            {
                var SQLVendedor = contexto.ConsultarVendedor(p);
                foreach (var item in SQLVendedor)
                {
                    vendedor = MapearVendedor(item);
                }
            }
            return vendedor;
        }

        /* 
         * Metodo
         * Descripcion: Mapea la entidad Vendedores
         * Entrada: ConsularVendedor_Result item
         * Salida: Vendedores
         */
        private Vendedores MapearVendedor(ConsultarVendedor_Result item)
        {
            Vendedores vendedor = new Vendedores();
            vendedor.ID_Vendedor = item.ID_Vendedor;
            vendedor.NombreCompleto = item.NombreCompleto;
            vendedor.NumeroDocumento = item.NumeroDocumento;
            vendedor.NombreUsuario = item.NombreUsuario;
            vendedor.Contrasenia = item.Contrasenia;
            vendedor.Email = item.Email;

            return vendedor;
        }
    }
}
