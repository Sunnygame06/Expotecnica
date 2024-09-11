using Login_Farmacia.Modelo.DTO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Login_Farmacia.Clase
{
    internal class XMLDocument
    {
        public void LeerArchivoXMLConexion()
        {
            string path = Path.Combine(Directory.GetCurrentDirectory().ToString(), "config_server.xml");
            if (File.Exists(path))
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(path);

                XmlNode root = doc.DocumentElement;
                XmlNode servernode = root.SelectSingleNode("Server/text()");
                XmlNode databaseNode = root.SelectSingleNode("Database/text()");
                XmlNode sqlAuthNode = root.SelectSingleNode("SqlAuth/text()");
                XmlNode sqlPassNode = root.SelectSingleNode("SqlPass/text()");

                string serverCode = servernode.Value;
                string databaseCode = databaseNode.Value;
                string userCode = sqlAuthNode.Value;
                string passwordCode = sqlPassNode.Value;

                DTOdbContext.Server = DescifrarCadena(serverCode);
                DTOdbContext.Database = DescifrarCadena(databaseCode);
                DTOdbContext.User = DescifrarCadena(userCode);
                DTOdbContext.Password = DescifrarCadena(passwordCode);
            }
            else
            {
                
            }
        }

        public string DescifrarCadena(string cadenaCode)
        {
            try
            {
                byte[] decodedBytes = Convert.FromBase64String(cadenaCode);
                // Convertir los bytes a una cadena
                string decodedString = Encoding.UTF8.GetString(decodedBytes);
                return decodedString.ToString();
            }
            catch (Exception ex)
            {
                return $"Error al descifrar: {ex.Message}";
            }
        }
    }
}
