# About this project
### Project short description
This is an educational program for learning 7th grade math to high school students. It contains 3 chapters (Order of operations, Natural numbers and Inequalities).<br>
### Project implementation
This software was written in C#, and utilizes Winforms and .NET 4.7.6<br>
### Project dependencies
Custom range-slider control is used, that is created by Bharath K.A., it can be found [here](https://www.codeproject.com/Articles/28717/A-custom-range-selector-control-in-C-with-a-little#:~:text=The%20range%20selector%20control%20exposes,range%20selector%20control%20accepts%20bitmaps.) <br>
To include the .dll of the above custom control, NuGet package Fody-Costura was also used. <br>
*Both of these dependencies are already included in the project folder, so you dont have to download/install anything.*<br>
### System requirements to run the application
The user must have a machine with Windows 7 or newer, and .NET 4.7.6 or newer installed. .NET 4.8 comes pre-installed on recent versions of Windows 10 and 11.
# Project description
This educational software, contains 3 chapters. Users start by creating an account, and then study each chapter in order (meaning they have to study chapter 1 before advancing to chapter 2.). At the end of each chapter, the user will have to take a timed test, and the performance of each test is recorded to the user's statistics. There is also a final test, with questions from all chapters.
# User login/register
For a user to use the software, they must first register and create and account. 
<br>All accounts are kept locally at the file C:/E-Learning/Users.data, which consists of 2 lines for each user entry.<br>
The first line, contains the user's username.<br>
The second line, contains the user's password hashed using SHA-256.<br>
# User statistics
All user statistics are kept locally, at the file C:/E-Learning/StatisticsDatabase.xml .<br>
This is an XML file that statistics are written for each user, using the DataSet class of C# and its methods ReadXML() and WriteXML() .<br>
Statistics of each user contain, their grade for each chapter's test, the grade of their final test and time spent on each chapter.
# Educational material
All the educational material is from [SplashLearn](splashlearn.com), specifically :
- [Order of operations](https://www.splashlearn.com/math-vocabulary/algebra/order-of-operations)
- [Natural numbers](https://www.splashlearn.com/math-vocabulary/natural-numbers)
- [Inequalities](https://www.splashlearn.com/math-vocabulary/counting-and-comparison/inequality)

# Compiling this project
To compile this project, you must have Visual studio 2019 or newer installed. You must also have C# packages installed and .NET 4.7.6 or newer. <br>
After you install the IDE and all the necessary components, simply clone this repository and open "E-Learning.sln" found in "VS Project" folder, which will open the project itself in Visual studio. 
<br>From there, you can hit Ctrl+Shift+B to start the build process. The executable produced will be located in E-Learning/bin/E-Learning.exe .

# False positives from Antiviruses
Many security products flag this software as a trojan (which is clearly false), the reason is probably the use of Fody-Costura for embedding the custom control DLL into the application.
