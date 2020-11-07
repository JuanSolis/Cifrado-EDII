using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using cifrados;

namespace API.Controllers
{
    
    [ApiController]
    [Route("api/[controller]")]
    public class cipherController : ControllerBase
    {
        [HttpPost("{method}")]
        public async Task<IActionResult> PostCompress(string method,[FromForm] Key Key, [FromForm] IFormFile file) 
        {
            string ext = "";
            string archivoAcomprimir = "";
            string archivocodificado = "";

            string textocodificado = "";
            string workingDirectory = Environment.CurrentDirectory;
            string pathFolderActual = Directory.GetParent(workingDirectory).FullName;
            string pathDirectorioCompresiones = pathFolderActual + "\\CifradosEstructuras\\";

            if (Directory.Exists(pathDirectorioCompresiones))
            {
                Directory.Delete(pathDirectorioCompresiones, true);
            }

            Directory.CreateDirectory(pathDirectorioCompresiones);

            string pathDirectorioArchivosSubidos = pathFolderActual + "\\Uploads\\";

            if (Directory.Exists(pathDirectorioArchivosSubidos))
            {
                Directory.Delete(pathDirectorioArchivosSubidos, true);
            }

            Directory.CreateDirectory(pathDirectorioArchivosSubidos);

            using (var fileStream = new FileStream((pathDirectorioArchivosSubidos + file.FileName), FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }

            try
            {
                archivoAcomprimir = pathDirectorioArchivosSubidos + file.FileName;
                string text = System.IO.File.ReadAllText(archivoAcomprimir, System.Text.Encoding.Default);
              
                switch (method)
                {
                    case "Cesar": {
                            Cesar cifradoCesar = new Cesar();
                            cifradoCesar.Cifrar(Key.Word.ToUpper(), text.ToUpper());
                            ext = ".csr";
                            archivocodificado = pathDirectorioCompresiones + file.FileName.Split(".")[0] + ext;
                            textocodificado = cifradoCesar.mensajeCifrado;
                            
                        }
                    break;
                }

                System.IO.File.WriteAllBytes(archivocodificado, System.Text.Encoding.Default.GetBytes(textocodificado));

                var streamCompress = System.IO.File.OpenRead(archivocodificado);

                return new FileStreamResult(streamCompress, "application/" + ext.Replace(".", ""))
                {
                    FileDownloadName = file.FileName.Split(".")[0] + ext
                };

            }
            catch {
                return BadRequest();
            }

            
        }
    }
}
