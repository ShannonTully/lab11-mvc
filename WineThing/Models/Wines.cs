using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WineThing.Models
{
    public class Wines
    {
        public string ID { get; set; }
        public string Country { get; set; }
        public string Description { get; set; }
        public string Designation { get; set; }
        public int Points { get; set; }
        public decimal Price { get; set; }
        public string Region_1 { get; set; }
        public string Region_2 { get; set; }
        public string Variety { get; set; }
        public string Winery { get; set; }

        public static List<Wines> GetWineList()
        {
            List<Wines> wineList = new List<Wines>();
            using (var reader = new StreamReader("../wine.csv"))
            {
                string line = reader.ReadLine();
                while (!reader.EndOfStream)
                {
                    Wines newWine = new Wines();
                    line = reader.ReadLine();
                    string[] values = Regex.Split(line, ",(?=(?:[^\"]*\"[^\"]*\")*[^\"]*$)");

                    if (values.Length > 9)
                    {
                        newWine.ID = values[0];
                        newWine.Country = values[1];
                        newWine.Description = values[2];
                        newWine.Designation = values[3];
                        newWine.Points = (values[4] == "") ? 0 : Convert.ToInt32(values[4]);
                        newWine.Price = (values[5] == "") ? 0 : Convert.ToDecimal(values[5]);
                        newWine.Region_1 = values[6];
                        newWine.Region_2 = values[7];
                        newWine.Variety = values[8];
                        newWine.Winery = values[9];

                        wineList.Add(newWine);
                    }
                }

                return wineList;
            }
        }
    }
}
