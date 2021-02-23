using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using static SubidaEliminarImg.Helpers.PathProvider;

namespace SubidaEliminarImg.Helpers
{
    public class UploadFile
    {
        PathProvider path;
        FileSanity sanity;

        public UploadFile(PathProvider path, FileSanity sanity)
        {
            this.path = path;
            this.sanity = sanity;
        }


        public async Task SubirFichero(IFormFile imagen)
        {

            String filename = "";
            String ruta = "";
            if (imagen != null)
            {
                filename = imagen.FileName;

                ruta = this.path.MapPath(filename, Folders.Ejemplo1);

                using (var stream = new FileStream(ruta, FileMode.Create))
                {
                    await imagen.CopyToAsync(stream);
                }
            }

        }

        public async Task SubirFichero(String nombre, IFormFile imagen)
        {
          
            String filename = "";
            String ruta = "";
            if (imagen != null)
            {
                filename = this.sanity.RemoveSpecialCharacters(nombre, imagen.FileName);

                ruta = this.path.MapPath(filename, Folders.Ejemplo1);

                using (var stream = new FileStream(ruta, FileMode.Create))
                {
                    await imagen.CopyToAsync(stream);
                }
            }

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
