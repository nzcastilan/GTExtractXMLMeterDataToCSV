using System.Linq;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System;

namespace GTExtractXMLMeterDatatoCSV.Utilities
{
    public class Helpers
    {

        //This will extract the indices of all oocurence of the string provided
        public List<int> GetIndicesOfString(string[] searchData, string searchString)
        {
            return Enumerable.Range(0, searchData.Length).Where(i => searchData[i].Split(',')[0].Equals(searchString)).ToList();
        }

        public string uploadXML(string path_name = "")
        {
            string contents = "";
            try
            {
                using (StreamReader streamReader = new StreamReader(path_name, Encoding.UTF8))
                {
                    contents = streamReader.ReadToEnd();
                }
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return contents;
        }
    }
}
