/*
 * Nombre de la Clase: Pedidos
 * Descripcion: Clase que mapea la TB_Pedidos
 * Autor: Equipo Makross - Grupo de Desarrollo
 * Fecha: 03/01/2016
 */

/*
 * Listado de Metodos:
 * >>
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Pedidos
    {
        public int ID_Pedido { get; set; }
        public int ID_Cliente { get; set; }
        public System.DateTime FechaRegistro { get; set; }
        public decimal TotalBruto { get; set; }
        public decimal Impuesto { get; set; }
        public decimal ValorNeto { get; set; }
        public bool Estado { get; set; }
    }
}
