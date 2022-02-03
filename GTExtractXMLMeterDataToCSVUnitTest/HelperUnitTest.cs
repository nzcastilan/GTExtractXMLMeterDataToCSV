using NUnit.Framework;
using GTExtractXMLMeterDatatoCSV.Utilities;
using System.Collections.Generic;

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

    }

}