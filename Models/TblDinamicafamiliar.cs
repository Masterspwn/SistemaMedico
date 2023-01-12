using System;
using System.Collections.Generic;

namespace CentePreNat.Models
{
    public partial class TblDinamicafamiliar
    {
        public int DimHistorialClinico { get; set; }
        public int DimIdTipoFamilia { get; set; }
        public string? DimTipoFamilia { get; set; }

        public virtual TblPaciente DimHistorialClinicoNavigation { get; set; } = null!;
    }
}
