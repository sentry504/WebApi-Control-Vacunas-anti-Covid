//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApi_Control_Vacunas_anti_Covid
{
    using System;
    using System.Collections.Generic;
    
    public partial class VacunasCiudadano
    {
        public string Identidad { get; set; }
        public System.DateTime fecha { get; set; }
    
        public virtual Ciudadano Ciudadano { get; set; }
    }
}
