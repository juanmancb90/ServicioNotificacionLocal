//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class TB_Auditoria
    {
        public int ID_Auditoria { get; set; }
        public System.DateTime TiempoEvento { get; set; }
        public string NombreUsuario { get; set; }
        public string NombreBaseDatos { get; set; }
        public string NombreObjeto { get; set; }
        public string TipoObjeto { get; set; }
        public string ComandoDML { get; set; }
    }
}