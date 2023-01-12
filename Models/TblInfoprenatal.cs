using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace CentePreNat.Models
{
    public partial class TblInfoprenatal
    {
        [DisplayName("Historial Clinico")]
        public int PreHistorialClinico { get; set; }
        public int PreIdInfo { get; set; }
        [DisplayName("Numero de Embarazos")]
        public int? PreNumeroEmbarazo { get; set; }
        [DisplayName("Estado Emocional")]
        public string? PreEstadoEmocional { get; set; }
        [DisplayName("Salud Mental")]
        public string? PreSaludMental { get; set; }
        [DisplayName("Complicaciones")]
        public string? PreComplicaciones { get; set; }
        [DisplayName("Planificacion Familiar")]
        public string? PrePlanificacion { get; set; }
        [DisplayName("Aborto")]
        public string? PreAborto { get; set; }
        [DisplayName("Motivo")]
        public string? PreMotivo { get; set; }

        public virtual TblPaciente PreHistorialClinicoNavigation { get; set; } = null!;
    }
}
