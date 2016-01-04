/*
 * Nombre de la Clase: PedidosDAL
 * Descripcion: Clase de gestion de operaciones de la base de dato
 * Autor: Equipo Makross - Grupo de Desarrollo
 * Fecha: 03/01/2016
 */

/*
 * Listado de Metodos:
 * >> PedidosDAL(string cs)
 * >> List<Pedidos> ObtenerEstadoPedidos(string fechaActual)
 * >> Pedidos MapearPedido(ConsultarPedidoFecha_Result item)
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace DAL
{
    public class PedidosDAL
    {
        private string cn;

        /* 
         * Metodo
         * Descripcion: Metodo constructor que recibe un string de conexion
         * Entrada: string cs
         * Salida: void
         */
        public PedidosDAL(string cs)
        {
            this.cn = cs;
        }

        /* 
         * Metodo
         * Descripcion: Permite obtener un listados de pedidos de acuerdo a la fecha
         * Entrada: string fechaActual
         * Salida: List<Pedidos>
         */
        public List<Pedidos> ObtenerEstadoPedidos(string fechaActual)
        {
            List<Pedidos> pedidos = new List<Pedidos>();

            using (DB_AcmeEntities contexto = new DB_AcmeEntities())
            {
                var SQLPedido = contexto.ConsultarPedidoFecha(fechaActual);

                foreach (var item in SQLPedido)
                {
                    Pedidos pedidoActual = MapearPedido(item);
                    pedidos.Add(pedidoActual);
                }
            }

            return pedidos;
        }

        /* 
         * Metodo
         * Descripcion: Mapear la entidad Pedidos
         * Entrada: ConsultarPedidoFecha_Result item
         * Salida: Pedidos
         */
        private Pedidos MapearPedido(ConsultarPedidoFecha_Result item)
        {
            Pedidos pedido = new Pedidos();
            pedido.ID_Pedido = item.ID_Pedido;
            pedido.ID_Cliente = item.ID_Cliente;
            pedido.FechaRegistro = item.FechaRegistro;
            pedido.TotalBruto = item.TotalBruto;
            pedido.Impuesto = item.Impuesto;
            pedido.ValorNeto = item.ValorNeto;
            pedido.Estado = item.Estado;

            return pedido;
        }
    }
}
