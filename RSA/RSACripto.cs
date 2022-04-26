using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.IO;
using System;
using System.Configuration;

namespace RSACripto
{


    public class RSACriptoGrafia
    {
        private string TamanioLlave = string.Empty;

        private string ArmarLlavePrivada = string.Empty;
        private string ArmarLlavePublica = string.Empty;
        public enum TamanioLlaves
        {

            TAMANIO512 = 512,
            TAMANIO1024 = 1024,
            TAMANIO2048 = 2048,
            TAMANIO952 = 952,
            TAMANIO1369 = 1369
        };
        public string Llave
        {
            get { return TamanioLlave; }
            set { TamanioLlave = value; }
        }

        public RSACriptoGrafia()
        {
            ArmarLlavePrivada = "C:\\"+ "privateKey.xml";
            ArmarLlavePublica = "C:\\" +"publicKey.xml";
            
        }

        public void Iniciar() {
            string mensaje = "PERRO";

            byte [] encript=EncriptarRSA(ArmarLlavePrivada, Encoding.UTF8.GetBytes(mensaje));
            byte[] Dencript = DescencriptarRSA(ArmarLlavePublica, encript);
            CrearLLaves(ArmarLlavePublica, ArmarLlavePrivada);
        }
        public void CrearLLaves(string ArchivoLlavePublica, string ArchivoLlavePrivada)
        {
            //Usamos RSACng y le asignamos el tamaño de las llaves
            //
            //
             
            RSACng ObjetoRSA = new RSACng((int)TamanioLlaves.TAMANIO2048);

            TamanioLlave = ObjetoRSA.KeySize.ToString();
            
            string LlavePublica = ObjetoRSA.ToXmlString(false);
            File.WriteAllText(ArchivoLlavePublica,LlavePublica);

            string LlavePrivada = ObjetoRSA.ToXmlString(true);
            File.WriteAllText(ArchivoLlavePrivada, LlavePrivada);

        }

        public static byte[] EncriptarRSA(string ArchivoLlavePrivada, byte[] DatoAEncriptar)
        {
            byte[] Encriptar;

            RSACng ObjetoRSA = new RSACng((int)TamanioLlaves.TAMANIO2048);

            string P = File.ReadAllText(ArchivoLlavePrivada);
            ObjetoRSA.FromXmlString(P);
            Encriptar = ObjetoRSA.Decrypt(DatoAEncriptar, RSAEncryptionPadding.OaepSHA1);
            return Encriptar;
        }

        public static byte[] DescencriptarRSA(string ArchivoLlavePublica, byte[] DatoEncriptado)
        {
            byte[] Descencriptar;

            RSACng ObjetoRSA = new RSACng((int)TamanioLlaves.TAMANIO2048);

            string P = File.ReadAllText(ArchivoLlavePublica);
            ObjetoRSA.FromXmlString(P);
            Descencriptar = ObjetoRSA.Decrypt(DatoEncriptado, RSAEncryptionPadding.OaepSHA1);
            return Descencriptar;
        }
    }
}
