using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SubidaEliminarImg.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SubidaEliminarImg.Controllers
{
    public class EjemploController : Controller
    {
        UploadFile files;
        DeleteFile delete;
        PathProvider path;

        public EjemploController(UploadFile files,DeleteFile delete, PathProvider path)
        {
            this.files = files;
            this.delete = delete;
            this.path = path;
        }

        public IActionResult Formulario1()
        {
            return View();
        }

       [HttpPost]
        public async Task<IActionResult> Formulario1(IFormFile imagen)
        {
            await this.files.SubirFichero(imagen);

            return View();
        }


        public IActionResult EliminarImagen()
        {
            string directorio = this.path.MapPath(Folders.Ejemplo1);
            DirectoryInfo di = new DirectoryInfo(directorio);
            List<String> ficheros = new List<string>();
           foreach(var variable in di.GetFiles())
            {
                ficheros.Add(variable.Name);
            }

          
            return View(ficheros);
        }

        [HttpPost]
        public IActionResult EliminarImagen(String filename)
        {
            string directorio = this.path.MapPath(Folders.Ejemplo1);
            DirectoryInfo di = new DirectoryInfo(directorio);
            List<String> ficheros = new List<string>();
            foreach (var variable in di.GetFiles())
            {
                ficheros.Add(variable.Name);
            }

             this.delete.EliminarFichero(filename,Folders.Ejemplo1);

            ViewData["Info"] = "Se ha elimnado "+filename;
            return View(ficheros);
        }
    }
}
