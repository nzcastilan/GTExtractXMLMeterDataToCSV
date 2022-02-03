using NUnit.Framework;
using GTExtractXMLMeterDatatoCSVUnitTest;
using GTExtractXMLMeterDatatoCSV.Utilities;


namespace GentractTechnicalUnitTest
{
    public class XMLUnitTest
    {

        [Test]
        public void XML_ValidData()
        {
            CSVMeterData CSVMeter = new CSVMeterData();
            string[] csvMeterData = CSVMeter.ExtractCSVMeterData(Resource.CleanTestFile);
            Assert.IsTrue(csvMeterData != null);

        }
        [Test]
        public void XML_WithNoRow300()
        {
           
            CSVMeterData CSVMeter = new CSVMeterData();
            string[] csvMeterData = CSVMeter.ExtractCSVMeterData(Resource._200RowHasNo300Row);
            Assert.IsTrue(CSVMeter.IsCSVMeterDataXMLValid(csvMeterData).Equals(false));

        }

        [Test]
        public void XML_DataOutsideHeaderAndTrailer()
        {
            CSVMeterData CSVMeter = new CSVMeterData();
            string[] csvMeterData = CSVMeter.ExtractCSVMeterData(Resource.DataOutsideHeaderAndTrailer);
            Assert.IsTrue(CSVMeter.IsCSVMeterDataXMLValid(csvMeterData).Equals(false));

        }
        [Test]
        public void XML_InvalidCSVElement999()
        {
           
            CSVMeterData CSVMeter =  new CSVMeterData();
            string[] csvMeterData = CSVMeter.ExtractCSVMeterData(Resource.InvalidElement999);
            Assert.IsTrue(CSVMeter.IsCSVMeterDataXMLValid(csvMeterData).Equals(false));

        }
        [Test]
        public void XML_MissingRow100()
        {
           
            CSVMeterData CSVMeter =  new CSVMeterData();
            string[] csvMeterData = CSVMeter.ExtractCSVMeterData(Resource.Missing100);
            Assert.IsTrue(CSVMeter.IsCSVMeterDataXMLValid(csvMeterData).Equals(false));

        }
        [Test]
        public void XML_MissingRow200()
        {
           
            CSVMeterData CSVMeter =  new CSVMeterData();
            string[] csvMeterData = CSVMeter.ExtractCSVMeterData(Resource.Missing200);
            Assert.IsTrue(CSVMeter.IsCSVMeterDataXMLValid(csvMeterData).Equals(false));

        }
        [Test]
        public void XML_MissingCSVIntervalDataNode()
        {
           
            CSVMeterData CSVMeter =  new CSVMeterData();
            string[] csvMeterData = CSVMeter.ExtractCSVMeterData(Resource.MissingCSVIntervalDataNode);
            Assert.IsTrue(csvMeterData == null);

        }
        [Test]
        public void XML_MultipleHeader()
        {
           
            CSVMeterData CSVMeter =  new CSVMeterData();
            string[] csvMeterData = CSVMeter.ExtractCSVMeterData(Resource.MultipleHeader);
            Assert.IsTrue(CSVMeter.IsCSVMeterDataXMLValid(csvMeterData).Equals(false));

        }
        [Test]
        public void XML_MultipleTrailer()
        {
           
            CSVMeterData CSVMeter =  new CSVMeterData();
            string[] csvMeterData = CSVMeter.ExtractCSVMeterData(Resource.MultipleTrailer);
            Assert.IsTrue(CSVMeter.IsCSVMeterDataXMLValid(csvMeterData).Equals(false));

        }
    }

}