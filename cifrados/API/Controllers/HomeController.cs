using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        public DescriptorAPI getAPIDescriptor()
        {
            DescriptorAPI descriptor = new DescriptorAPI();
            descriptor.Cifrar = new DescriptorRuta()
            {
                Ruta = "/api/cipher/{method}",
                Descripcion = "En esta ruta se puede mandar como parametro el nombre del metodo a cifrar, un archivo de texto que se desea cifrar. La Key en postman para mandar el archivo desde form-data es {file}, key.word, key.levels, key.rows, key.columns",
                Metodo = "POST"
            };
            descriptor.Descifrar = new DescriptorRuta()
            {
                Ruta = "/api/decipher",
                Descripcion = "En esta ruta se puede mandar, el archivo de texto que se desea descifrar. La Key en postman para mandar el archivo desde form-data es {file}, key.word, key.levels, key.rows, key.columns",
                Metodo = "POST"
            };


            return descriptor;

        
    }
}
}
