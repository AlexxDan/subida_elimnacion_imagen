using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SubidaEliminarImg.Helpers
{
    public class DeleteFile
    {
        PathProvider path;

        public DeleteFile(PathProvider path)
        {
            this.path = path;
        }

        public void EliminarFichero(String fotosnombre, Folders folder)
        {
            String ruta = this.path.MapPath(fotosnombre, folder);
            if (File.Exists(ruta))
            {
                File.Delete(ruta);
            }
        }
    }
}
