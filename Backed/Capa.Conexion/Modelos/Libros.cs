using System;
using System.Collections.Generic;

namespace Capa.Conexion.Modelos
{
    public partial class Libros
    {
        public int Id { get; set; }
        public int Ideditoriales { get; set; }
        public string Titulo { get; set; }
        public string Sinopsis { get; set; }
        public string NPaginas { get; set; }

        public virtual Editoriales IdeditorialesNavigation { get; set; }
    }
}
