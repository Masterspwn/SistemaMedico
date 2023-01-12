using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CentePreNat.Models
{
    public partial class TblPaciente
    {
        public TblPaciente()
        {
            TblDinamicafamiliars = new HashSet<TblDinamicafamiliar>();
            TblFamiliares = new HashSet<TblFamiliare>();
            TblInfoprenatals = new HashSet<TblInfoprenatal>();
        }

        public int PacHistorialClinico { get; set; }
        public string? PacApellidos { get; set; }
        public string? PacGenero { get; set; }
      
        public int? PacEdad { get; set; }
        [DisplayName("Fecha Nacimiento")]
        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime? PacFnacimiento { get; set; }  
        public string? PacDireccion { get; set; }
        public string? PacTelefono { get; set; }
        public string? PacInstruccion { get; set; }
        public string? PacInstitucion { get; set; }
        public DateTime? PacFinformacion { get; set; }
        public string? PacEmail { get; set; }
        public DateTime? PacFentregainforme { get; set; }

        public virtual ICollection<TblDinamicafamiliar> TblDinamicafamiliars { get; set; }
        public virtual ICollection<TblFamiliare> TblFamiliares { get; set; }
        public virtual ICollection<TblInfoprenatal> TblInfoprenatals { get; set; }
     
    }
}
