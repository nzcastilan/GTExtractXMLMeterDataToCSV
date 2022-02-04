using System;

namespace GTExtractXMLMeterDatatoCSV
{
    class Program
    {
        static void Main(string[] args)
        {
            Utilities.CSVMeterData cSVMeterData = new Utilities.CSVMeterData();
            Utilities.Helpers helper = new Utilities.Helpers();

            //the csv output file path is currently hardcoded to be saved at the users Desktop under CSVFiles Folder
            string csvOutputFilepath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\CSVFiles\\";
            //If the file is coming from the desktop make sure that the file XMLFiles\testfile.xml exists from the desktop
            string xmlInputFilepath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\\XMLFiles\testfile.xml";
            
            //Only allow user to enter 1,2 or 3
            string[] validInput = new[] { "1", "2" ,"3"};
            string input = "";
            string xmlFile = "";
            string[] csvData = null;
            bool isExit = false;

            while (!isExit)
            {
                xmlFile = "";
                input = "";
                csvData = null;

                while (!Array.Exists(validInput, inp => inp.Contains(input)) || String.IsNullOrEmpty(input))
                {
                    if (!String.IsNullOrEmpty(input))
                        Console.Write("Invalid Input, ");
                    Console.WriteLine("Please choose From the following options:");
                    Console.WriteLine("1 - From the projects resource file Resources/CleanTestFile.xml \n");
                    Console.WriteLine(String.Format("2 - From Desktop {0}", xmlInputFilepath));
                    Console.WriteLine("\t Please make sure the above file path exists to avoid any errors \n");
                    Console.WriteLine("3 - Exit");

                    input = Console.ReadLine();
                }

                switch (input)
                {
                    case "1":
                        xmlFile = Resource.CleanTestFile;
                        break;
                    case "2":
                        xmlFile = helper.uploadXML(xmlInputFilepath);
                        break;
                    default:
                        isExit = true;
                        Environment.Exit(0);
                        break;

                }
           
                if (!String.IsNullOrEmpty(xmlFile))
                    csvData = cSVMeterData.ExtractCSVMeterData(xmlFile);
                //always validate if the xml file is valid
                if (csvData != null)
                {

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
}
