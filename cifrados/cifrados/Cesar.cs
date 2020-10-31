using System;
using System.Collections.Generic;
using System.Linq;

namespace cifrados
{
    public class Cesar
    {
        public string clave;
        public List<string> lista = new List<string>();
        public List<string> listaConClave = new List<string>();
        public Dictionary<string,string> diccionarioCifrado = new Dictionary<string,string>();

        public string mensajeCifrado;
        public Cesar() {
            for (int i = 65; i < 91; i++)
            {
                lista.Add(((char)i).ToString());   
            }
        }


        public void Cifrar(string clave, string mensaje) {

            crearDiccionario(clave);

            string msgCifrado = "";
            foreach (char caracter in mensaje)
            {
                if (diccionarioCifrado.ContainsKey(caracter.ToString()))
                {
                    msgCifrado += diccionarioCifrado[caracter.ToString()];

                }
                else {
                    msgCifrado += caracter.ToString();
                }
            }

            mensajeCifrado = msgCifrado;

        }

        void crearDiccionario(string clave) {
            agregarClave(clave);
            agregarRestoDeDiccionario();

            int i = 0;
            foreach (string item in lista)
            {
                diccionarioCifrado.Add(item, listaConClave.ElementAt(i).ToString());
                i++;
            }
        }

        void agregarRestoDeDiccionario() {
            foreach (string item in lista)
            {
                if (!listaConClave.Contains(item))
                {
                    listaConClave.Add(item);
                }
            }

        }
        void agregarClave(string clave) {

            foreach (char item in clave)
            {
                listaConClave.Add(item.ToString());
            }
        }

        public void generarClave() {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            var random = new Random();
            var stringChars = new char[random.Next(chars.Length)];

            char caracter;
            bool contains = true;
            for (int i = 0; i < stringChars.Length; i++) {

                while (contains)
                {
                    caracter = chars[random.Next(chars.Length)];

                    if (!stringChars.Contains(caracter))
                    {
                        stringChars[i] = caracter;
                        contains = false;
                    }
                    else {
                        contains = true;
                    }
                }
                
            }

            var finalString = new string(stringChars);
            clave = finalString;
        }

    }
}
