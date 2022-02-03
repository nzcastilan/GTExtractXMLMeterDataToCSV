using System.Linq;
using System.Collections.Generic;


namespace GTExtractXMLMeterDatatoCSV.Utilities
{
    public class Helpers
    {

        //This will extract the indices of all oocurence of the string provided
        public List<int> GetIndicesOfString(string[] searchData, string searchString)
        {
            return Enumerable.Range(0, searchData.Length).Where(i => searchData[i].Split(',')[0].Equals(searchString)).ToList();
        }


    }
}
