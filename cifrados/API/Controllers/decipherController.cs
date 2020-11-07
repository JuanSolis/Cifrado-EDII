using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using cifrados;
using Microsoft.AspNetCore.Http;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class decipherController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> PostDecompress([FromForm] Key Key, [FromForm] IFormFile file)
        {
            string method = "."+file.FileName.Split(".")[1];
            string ext = ".txt";
            string archivoADescomprimir = "";
            string archivoDecodificado = "";

            string textoDecodificado = "";
            string workingDirectory = Environment.CurrentDirectory;
            string pathFolderActual = Directory.GetParent(workingDirectory).FullName;
            string pathDirectorioDescompresiones = pathFolderActual + "\\DescifradosEstructuras\\";

            if (Directory.Exists(pathDirectorioDescompresiones))
            {
                Directory.Delete(pathDirectorioDescompresiones, true);
            }

            Directory.CreateDirectory(pathDirectorioDescompresiones);

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
                archivoADescomprimir = pathDirectorioArchivosSubidos + file.FileName;
                string text = System.IO.File.ReadAllText(archivoADescomprimir, System.Text.Encoding.Default);

                switch (method)
                {
                    case ".csr":
                        {
                            Cesar cifradoCesar = new Cesar();
                            cifradoCesar.Descifrar(Key.Word.ToUpper(), text.ToUpper());

                            archivoDecodificado = pathDirectorioDescompresiones + file.FileName.Split(".")[0] + ext;
                            textoDecodificado = cifradoCesar.mensajeDescifrado;

                        }
                        break;
                        case ".zz":
                            {
                                ZigZag cifradoZigZag = new ZigZag(text, Key.Levels);
                                cifradoZigZag.Descifrar(text, Key.Levels);

                                archivoDecodificado = pathDirectorioDescompresiones + file.FileName.Split(".")[0] + ext;
                                textoDecodificado = cifradoZigZag.textoDescifrado;

                            }
                        break;
                }

                System.IO.File.WriteAllBytes(archivoDecodificado, System.Text.Encoding.Default.GetBytes(textoDecodificado));

                var streamCompress = System.IO.File.OpenRead(archivoDecodificado);

                return new FileStreamResult(streamCompress, "application/txt")
                {
                    FileDownloadName = file.FileName.Split(".")[0] + ext
                };

            }
            catch
            {
                return BadRequest();
            }


        }
    }
}
