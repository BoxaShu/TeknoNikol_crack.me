using System;
using System.Text;
using System.Security.Cryptography;
using System.IO;
using System.Xml.Linq;
using System.Xml;

namespace TeknoNikol_crack.me
{
    class Program
    {
        static void Main(string[] args)
        {
            DESCryptoServiceProvider returnVal = new DESCryptoServiceProvider();
            returnVal.Key = Encoding.UTF8.GetBytes("mscorlib");
            returnVal.IV = new byte[(returnVal.BlockSize / 8)];

            ICryptoTransform desdecrypt = returnVal.CreateDecryptor();
            byte[] files = File.ReadAllBytes(@"filters.exm");

            byte[] x = desdecrypt.TransformFinalBlock(files, 0, files.Length);
           string xmltxt =Encoding.UTF8.GetString(x);
           XDocument xml = XDocument.Parse(xmltxt);
            using (var w = XmlWriter.Create(@"filters.xml", new XmlWriterSettings
            {
                NewLineChars = "\r\n",
            }))
            xml.Save(w);
        }
    }
}