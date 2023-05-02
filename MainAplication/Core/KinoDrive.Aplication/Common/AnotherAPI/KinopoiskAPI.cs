using KinoDrive.Aplication.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace KinoDrive.Aplication.Common.AnotherAPI
{
    public class KinopoiskAPI : IKinopoiskAPI
    {
        public Dictionary<string, float>? GetRatings(string urlForFilm)
        {

            Dictionary<string, float>? result = null;

            WebClient client = new WebClient();
            var text = client.DownloadString(urlForFilm);

            XmlDocument xDoc = new XmlDocument();
            xDoc.LoadXml(text);

            // получим корневой элемент
            XmlElement? xRoot = xDoc.DocumentElement;
            if (xRoot != null)
            {
                result = new Dictionary<string, float>();

                // обход всех узлов в корневом элементе
                foreach (XmlElement xnode in xRoot)
                {
                    // Стоит отметить, что мы также можем получить и количество голосов
                    XmlNode? attr = xnode.Attributes.GetNamedItem("num_vote");
                    Console.WriteLine($"{attr.Name}" + attr?.Value);

                    var rating = float.Parse(xnode.InnerText);

                    result.Add(xnode.Name, rating);
                }
            }

            return result;
        }

    }
}
