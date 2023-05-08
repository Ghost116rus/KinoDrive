using KinoDrive.Aplication.Interfaces;
using System;
using System.Collections.Generic;
using System.Globalization;
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
        private string GetFilmId(string urlForFilmOnKinopoisk)
        {
            var arr = urlForFilmOnKinopoisk.Split('/');

            return arr[arr.Length-2];
        }


        public Dictionary<string, float?>? GetRatings(string urlForFilm)
        {
            var filmId = GetFilmId(urlForFilm);

            Dictionary<string, float?>? result = null;

            try
            {
                WebClient client = new WebClient();
                var text = client.DownloadString($"https://rating.kinopoisk.ru/{filmId}.xml.");

                XmlDocument xDoc = new XmlDocument();
                xDoc.LoadXml(text);

                // получим корневой элемент
                XmlElement? xRoot = xDoc.DocumentElement;
                if (xRoot != null)
                {
                    result = new Dictionary<string, float?>();

                    // обход всех узлов в корневом элементе
                    foreach (XmlElement xnode in xRoot)
                    {
                        // Стоит отметить, что мы также можем получить и количество голосов
                        //XmlNode? attr = xnode.Attributes.GetNamedItem("num_vote");
                        //Console.WriteLine($"{attr.Name}" + attr?.Value);

                        var number = xnode.InnerText;
                        float? rating = float.Parse(number, CultureInfo.InvariantCulture.NumberFormat);

                        if (rating == 0)
                        {
                            continue;
                        }

                        result.Add(xnode.Name, rating);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return result;
        }

    }
}
