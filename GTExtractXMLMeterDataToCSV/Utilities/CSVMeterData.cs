using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Text.RegularExpressions;

namespace GTExtractXMLMeterDatatoCSV.Utilities
{
    public class CSVMeterData
    {
        private Helpers helper = new Helpers();
        // This will write the csv file and will save to the specified folder
        public readonly string csvHeader = "100";
        public readonly string csvTrailer = "900";
        public readonly string csvFileData = "300";
        public readonly string csvFileProperty = "200";

        /*This extracts the XML file from the Resources folder of the project 
         As of 02/03/2022 this method is only accepting an XML content instead
         of the XML file path
         */
        public string[] ExtractCSVMeterData(string xmlFile = "")
        {
            string[] rawCsvMeterData = null;
            try
            {
                XElement xmlDoc = XElement.Parse(xmlFile);
                var xmlQuery = from c in xmlDoc.Descendants("CSVIntervalData") select c.Value;


                foreach (string xmlQueryResult in xmlQuery)
                {
                    //remove unwanted characters
                    string cleanXML = Regex.Replace(xmlQueryResult, @"\t|\r", "").Trim();
                    rawCsvMeterData = cleanXML.Split("\n", StringSplitOptions.RemoveEmptyEntries).Select(p => p.Trim()).ToArray();

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return rawCsvMeterData;
        }

        //This validates if the csvintervaldata is xml is valid
        public bool IsCSVMeterDataXMLValid(string[] csvMeterData)
        {

            var filePropertyIndices = helper.GetIndicesOfString(csvMeterData, csvFileProperty);
            var fileDataIndices = helper.GetIndicesOfString(csvMeterData, csvFileData);
            var trailerIndices = helper.GetIndicesOfString(csvMeterData, csvTrailer);
            var headerIndices = helper.GetIndicesOfString(csvMeterData, csvHeader);

            int trailerCount = trailerIndices.Count;
            int headerCount = headerIndices.Count;
            int filePropertyCount = filePropertyIndices.Count;
            int fileDataCount = fileDataIndices.Count;

            bool dataIsOutsideRange = false;
            bool isValid = false;

            //Check that the xml contains at least 1 "200","300","100" and "900" row
            if (trailerCount == 1 && headerCount == 1 && filePropertyCount > 0 && fileDataCount > 0)
            {

                //Check that all "200" is followed by "300" rows               
                bool filePropertyHasData = true;
                foreach (var filePropertyIndex in filePropertyIndices)
                {
                    //if the 200 row is found at the last index of the array that means it has no 300 row
                    if (filePropertyIndex != csvMeterData.Length)
                    {
                        if (!csvMeterData[filePropertyIndex + 1].Split(",")[0].Equals(csvFileData))
                            filePropertyHasData = false;
                    }
                    else
                    {
                        filePropertyHasData = false;
                    }
                }

                //check that the "100" row is before the "900" row
                if (headerIndices.First() < trailerIndices.First())
                {

                    //Check that there are no "300" row before a "200" row
                    dataIsOutsideRange = fileDataIndices.Any(i => i < filePropertyIndices.First());

                    if (!dataIsOutsideRange)
                        //check that the "200" rows are within the "100" and "900" row
                        dataIsOutsideRange = filePropertyIndices.Any(i => i < headerIndices.First() || i > trailerIndices.First());
                    if (!dataIsOutsideRange)
                        //check that the "300" rows are within the "100" and "900" row
                        dataIsOutsideRange = fileDataIndices.Any(i => i < headerIndices.First() || i > trailerIndices.First());


                }

                isValid = filePropertyHasData && !dataIsOutsideRange ? true : false;
            }

            return isValid;
        }

        public void ProcessCSVMeterData(string[] csvMeterData, string path)
        {
            try
            {
                string header = csvMeterData[helper.GetIndicesOfString(csvMeterData, csvHeader).First()];
                string trailer = csvMeterData[helper.GetIndicesOfString(csvMeterData, csvTrailer).First()];
                string filename = null;

                var csv = new StringBuilder();

                for (int i = 0; i < csvMeterData.Length; i++)
                {
                    if (String.IsNullOrWhiteSpace(csvMeterData[i]) && csvMeterData[i].Length < 3)
                        continue;
                    //get the filename and write the header
                    if (csvMeterData[i].Split(",")[0].Equals(csvFileProperty))
                    {
                        filename = csvMeterData[i].Split(",")[1];
                        csv.AppendLine(header);
                    }
                    //write the file data to csv file
                    else if (csvMeterData[i].Split(",")[0].Equals(csvFileData))
                    {
                        csv.AppendLine(csvMeterData[i]);

                    }

                    //save CSV FILE
                    if (!i.Equals(csvMeterData.Length - 1))
                    {

                        if ((csvMeterData[i + 1].Split(",")[0].Equals(csvFileProperty)
                         || csvMeterData[i + 1].Split(",")[0].Equals(csvTrailer))
                         && !csvMeterData[i].Split(",")[0].Equals(csvHeader))
                        {
                            //write the trailer of the file
                            csv.AppendLine(trailer);
                            if (!Directory.Exists(path))
                                Directory.CreateDirectory(path);
                            File.WriteAllText(path + filename + ".csv", csv.ToString());
                            //clear existing data written in the string builder
                            csv.Clear();
                        }
                    }

                }
                Console.WriteLine(String.Format("CSV Files was created at {0})",path));
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new System.InvalidOperationException(ex.Message);
            }


        }
    }
}
