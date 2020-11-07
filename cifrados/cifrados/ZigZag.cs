using System;
using System.Collections.Generic;
using System.Text;

namespace cifrados
{
    public class ZigZag
    {
        int tOla;
        int cresta;
        int cola;
        int nOlas;
        int tBloque;
        int nBloques;
        int salto;
        int lvls;
        string TextArchivo;
        string extensionA = "";

        public string textoCifrado = "";
        public string textoDescifrado = "";
        public string NombreArchivoNuevo = "";
        public string NombreOriginalArchivo = "";
        public string outPut = "";
        public string NombreArchivo = "";
        public string ubicacionArchivo = "";
        public List<char> charList;

        public ZigZag(string text, int levels) {
            TextArchivo = text;
            lvls = levels;
            tOla = (levels - 1) * 2;
        }


        public void cifrar() {

            string cifrado = "";
            int salto;

            char[] noCifrado = TextArchivo.ToCharArray();

            charList = new List<char>();

            for (int j = 0; j < noCifrado.Length; j++)
            {
                charList.Add(noCifrado[j]);
            }

            int extras = lvls - (noCifrado.Length % lvls);

            int indice = tOla;

            for (int i = 0; i < extras; i++)
            {
                charList.Add('|');
            }

            nOlas = charList.Count / tOla;

            for (int z = 0; z < lvls; z++)
            {
                salto = tOla - (2 * z);

                if (z == 0 || z == lvls - 1)
                {
                    for (int x = 0; x < nOlas; x++)
                    {
                        salto = tOla;
                        cifrado = cifrado + charList[(z + (x * salto))];
                    }
                }
                else {
                    
                    for (int s = 0; s < nOlas; s++)
                    {
                        cifrado = cifrado + charList[(s * tOla) + z] + charList[z + (s * tOla) + salto];
                    }
                    
                }


            }
            textoCifrado = cifrado;
            

        }

        public void Descifrar(string cifrado, int levels) {

            char[] aCifrado = cifrado.ToCharArray();
            string output = "";
            lvls = levels;
            tOla = (levels - 1) * 2;

            nOlas = aCifrado.Length / tOla;
            tBloque = nOlas * 2;

            cresta = cola = nOlas;

            nBloques = (aCifrado.Length - cresta - cresta) / tBloque;

            char[] aCresta = new char[cresta];
            char[] aCola = new char[cola];

            int indice = 0;

            List<char> aBloque = new List<char>();

            for (int i = 0; i < aCifrado.Length; i++)
            {
                if (i < cresta)
                {
                    aCresta[i] = aCifrado[i];
                }
                else if (i >= cresta && i < (aCifrado.Length - cola))
                {
                    aBloque.Add(aCifrado[i]);
                }
                else {
                    aCola[indice] = aCifrado[i];
                    indice++;
                }
            }

            for (int j = 0; j < cresta; j++)
            {
                output = output + aCresta[j];

                for (int z = 0; z < nBloques; z++)
                {
                    output = output + aBloque[(z * tBloque) + (j * 2)];
                }

                output = output + aCola[j];

                for (int z = nBloques-1; z >= 0; z--)
                {
                    output = output + aBloque[(z * tBloque) + (j * 2) + 1];
                }
                 
            }

            aCresta = output.ToCharArray();
            int indice2 = 0;

            while (aCresta[indice2] != '|')
            {
                extensionA = extensionA + aCresta[indice2];
                indice2++;
            }

            output = extensionA;
            textoDescifrado = output;


        }

    }
}
