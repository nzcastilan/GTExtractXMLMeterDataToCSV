using NUnit.Framework;
using GTExtractXMLMeterDatatoCSV.Utilities;
using System.Collections.Generic;
using System.IO;

namespace GentractTechnicalUnitTest
{
    public class HelperTest
    {
        [Test]
        public void GetIndices_HasResults()
        {
            Helpers helper = new Helpers();
            string[] searchData = new string[] { "100", "50", "200", "100", "200" };
            string searchText = "200";
            List<int> indices = helper.GetIndicesOfString(searchData,searchText);
            Assert.IsTrue(indices.Count == 2);

        }
        [Test]
        public void GetIndices_HasNoResults()
        {
            Helpers helper = new Helpers();
            string[] searchData = new string[] { "100", "50", "200", "100", "200" };
            string searchText = "222";
            List<int> indices = helper.GetIndicesOfString(searchData, searchText);
            Assert.IsTrue(indices.Count == 0);

        }

        [Test]
        public void Upload_ValidFilePath()
        {
            Helpers helper = new Helpers();
            string filePath = Path.Combine(System.IO.Path.GetFullPath(@"..\..\..\"), @"Resources\CleanTestFile.xml");
            string xml =  helper.uploadXML(filePath);
            Assert.IsTrue(!string.IsNullOrEmpty(xml));

        }
        [Test]
        public void Upload_InValidFilePath()
        {
            Helpers helper = new Helpers();
            string filePath = Path.Combine(System.IO.Path.GetFullPath(@"..\..\..\"), @"Resources\InvalidFile.xml");
            string xml = helper.uploadXML(filePath);
            Assert.IsTrue(string.IsNullOrEmpty(xml));

        }

    }

}