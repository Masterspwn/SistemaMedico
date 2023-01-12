using System;
using System.Collections.Generic;

namespace CentePreNat.Models
{
    public partial class TblFamiliare
    {
        public int FamHistorialClinico { get; set; }
        public int FamIdFamiliar { get; set; }
        public string? FamParentesco { get; set; }
        public string? FamNombre { get; set; }
        public int? FamEdad { get; set; }
        public string? FamProfesion { get; set; }
        public string? FamObservacion { get; set; }

        public virtual TblPaciente FamHistorialClinicoNavigation { get; set; } = null!;
    }
}
