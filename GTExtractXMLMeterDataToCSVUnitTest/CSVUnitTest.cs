using NUnit.Framework;
using GTExtractXMLMeterDatatoCSV.Utilities;
using GTExtractXMLMeterDatatoCSVUnitTest;
using System;
using System.Linq;
using System.IO;

namespace GentractTechnicalUnitTest
{
    public class CsvMeterDataTest
    {

        [Test]
        public void CSV_Write_With_Valid_XMLData()
        {
            CSVMeterData CSVMeter = new CSVMeterData();
            string csvOutputFilepath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\CSVUnitTestFiles\\";
            string[] csvMeterData = CSVMeter.ExtractCSVMeterData(Resource.CleanTestFile);

            CSVMeter.ProcessCSVMeterData(csvMeterData, csvOutputFilepath);
            DirectoryAssert.Exists(csvOutputFilepath);
            //delete the file if the csv file is successfully created
            if (Directory.Exists(csvOutputFilepath))
            {
                DirectoryInfo di = new DirectoryInfo(csvOutputFilepath);
                foreach (FileInfo file in di.GetFiles())
                {
                    file.Delete();
                }
                Directory.Delete(csvOutputFilepath);

            }

        }
        [Test]
        public void CSV_Write_With_Invalid_XMLData()
        {
            CSVMeterData cSVMeterData= new CSVMeterData();
            string [] rawCsvMeterData = Resource.InvalidElement999.Split("\n", StringSplitOptions.RemoveEmptyEntries).Select(p => p.Trim()).ToArray();
            Assert.Throws<InvalidOperationException>(() => cSVMeterData.ProcessCSVMeterData(rawCsvMeterData, ""));

        }
    
    }

}