using System;

namespace GTExtractXMLMeterDatatoCSV
{
    class Program
    {
        static void Main(string[] args)
        {
            Utilities.CSVMeterData cSVMeterData = new Utilities.CSVMeterData();
            string csvOutputFilepath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\CSVFiles\\";
            string[] csvData = cSVMeterData.ExtractCSVMeterData(Resource.CleanTestFile);

            //always validate if the xml file is valid
            if(csvData != null) { 

                if (cSVMeterData.IsCSVMeterDataXMLValid(csvData))
                {
                    cSVMeterData.ProcessCSVMeterData(csvData, csvOutputFilepath);
                }
                else
                {
                    Console.WriteLine("Invalid XML Data");
                }
            }


        }
    }
}
