using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Usuario
    {
        public int IdUsuario { get; set; }
        public string CURP { get; set; }
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string EmailEmpresarial { get; set; }
        public char Sexo { get; set; }
        public string Telefono { get; set; }
        public string Celular { get; set; }
        public string FechaNacimeinto { get; set; }
        public string FechaRegistro { get; set; }
        public byte[] Foto { get; set; }

        public int IdUsuarioModificacion { get; set; }

        public ML.Area Area { get; set; }

        public List<Object> Usuarios { get; set; }  
    }
}
