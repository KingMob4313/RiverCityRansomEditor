using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiverCityEditor
{
    public static class HexToAsciiTranslator
    {
        public static string GetTranslatedValue(byte hexValue)
        {
            string fileLocation = @"C:\Users\Fred\Documents\ModProjects\RCR\river_city_ransom.tbl";
            const Int32 BufferSize = 128;
            String line = string.Empty;
            string translatedValue = string.Empty;
            using (var fileStream = File.OpenRead(fileLocation))
            using (var streamReader = new StreamReader(fileStream, Encoding.UTF8, true, BufferSize))
            {
                string currentByteValue = hexValue.ToString();
                
                while ((line = streamReader.ReadLine()) != null)
                {
                    string lineIn = line.Substring(0,2);
                    if(lineIn == currentByteValue)
                    {
                        translatedValue = line.Substring(3, 1);
                        break;
                    }

                }
            }
            return translatedValue;
        }
    }
}
