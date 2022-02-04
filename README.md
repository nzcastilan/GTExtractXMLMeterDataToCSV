# GTExtractXMLMeterDataToCSV
Console Application to Extract Interval Meter Data from XML to CSV

**Important**

Please make sure there's a folder named "XMLFiles" and a file name "testfile.xml" inside it on your desktop if you are selecting option 2 from the console application.

## Table of Contents

[What was done](#what-was-done)  
[What wasn't done](#what-was-not-done)  
[What would be done with more time](#what-would-be-done-with-more-time)

## What was done?

Created a console application where the user can upload an xml file using two different methods
1. From the Resource Folder (CleanTestFile.xml) (I added the xml file to this folder to make sure that its easy for the user to check that the application is working)
2. From the Desktop (XMLFiles\testfile.xml) (As I recall when we generate the XML file from Velocity we save it to a default folder)

Getting from the desktop file is an assumption that the XML File will be picked up from a constant folder, for this case I set it as a folder in the Desktop

**Application Flow**

1. The applicaiton reads the xml file based on the user's selection(from Desktop or From the Resource Folder)
2. Once the xml file is loaded the application extracts the data from the "CSVIntervalData" xml node
3. The application removes extra characters(\n,\t,\r) and spaces from the xml node
4. After that the application checks the xml's validity based on the following:
   a. the application checks that the "100" and "900" rows exists once in the xml file
   b. the application checks that the "200" and "300" rows exists at least once in the xml file
   b. the application checks that the "200" row is followed by at least one "300" row
   c. the application checks tht the "100" row is before the "200","300" and "900" row
   d. the application checks that there are no "300" row exists before the first "200" row
   d. the application checks that the "200" and "300" row are between the "100" and "900" row   
5. If the xml file returns a valid response , the applciation will start to process the CSV File
6. As of the Current version the CSV Files are generated to the users desktop inside the "CSVFILES" Folder

**Unit Test**

There are a total of 15 test cases that was created for this application

**CSVMeterData Unit Testing**
1. Generate the CSV File with a valid XML Data
2. Return an error with an invalid XML Data

**Helper Unit Testing**
1. Get the indices with no results
2. Get the indices with results
3. Upload a file using an existing file path
4. Return an error when an invalid file path was loaded

**XML Validity Unit Testing**
The XML files used can be found under the Resources folder of the Unit Test Project

1. Return False if the XML is uploaded with data Outside the 100 and 900 row
2. Return False if the XML is uploaded with Invalid elements (e.g. 999 row)
3. Return False if the XML is uploaded with missing "CSVIntervalData" xml node
4. Return False if the XML is uploaded with no 100 row
5. Return False if the XML is uploaded with no 200 row
6. Return False if the XML is uploaded with multiple 100 row
7. Return False if the XML is uploaded with multiple 900 row
8. Return False if the XML is uploaded with no 300 row
9. XML with Valid Data 
 
All Test Cases result was passed.

## What was not done?

Based on the requirements, all was included in the console application.

## What would be done with more time

1. An option where the user can select where to get the XML Input File using open file dialog
2. An option where the user can select where to save the CSV File using open file dialog
3. Able to read multiple XML file
4. Able to process the data on background(just in case we get a huge bulk of data, !last priority)
