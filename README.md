# JobSurfer Project Sem 6

Online Job Portal called : JobSurfer , a project submitted to YCMOU for the fulfillment of the requirements of Bachelor of Computer Apllication Graduation Degree .

<!--Demo Video : <a target="_blank" href="https://youtu.be/TmliZHj7ivc">Link</a>-->

## Documentation

Synopsis  : <a target="_blank" href="https://github.com/abhi-2911/JobSurfer-Project-Sem-6/blob/master/Synopsis/Synopsis.pdf">Link</a>

Presentation  : <a target="_blank" href="https://github.com/abhi-2911/JobSurfer-Project-Sem-6/blob/master/Presentation/Presentation_JobSurfer.pdf">Link</a>

Project Report Book : <a target="_blank" href="https://github.com/abhi-2911/JobSurfer-Project-Sem-6/blob/master/Project%20Report%20Book/JobSurfer%20Project%20Report.pdf">Link</a>

## Points To Know
1) IDE used , Visual Studio 2015
2) DataBase used , Microsoft SQL Server 2014
3) Web_Browser , Microsoft Edge Only

## Structure of Code in Visual Studio
<h5>1) Four Main Elements :</h5>
  <ul><li> Website</li>
  <li> User</li>
  <li> Employer</li>
  <li> Admin</li></ul>

<h5>2) All four elements have :</h5>
  <ul><li> There own folder , for storing aspx (pages)</li>
  <li> Folder for , storing Webform User Control ascx (pages)</li>
  <li> Folder for , storing Images required in the website</li>
  <li> Folder for , storing CSS files</li></ul>

<h5>3) Way of Coding</h5>
  <ul><li> First a Master Page is Created , for either Website , User , Employer or Admin</li>
  <li> Second an aspx (page) is created , as and when needed for Homepage , ContactUs page or Login Page</li>
  <li> The aspx (page) is linked with respective Master Page</li>
  <li> An (ascx) User Control WebForm Page is created of the respective aspx (page)</li>
  <li> CSS file for this (ascx) User Control WebForm Page is created</li>
  <li> CSS file is Linked to (ascx) User Control WebForm Page</li>
  <li> (ascx) User Control WebForm Page is Linked to respective aspx (page)</li>
  <li> ASP.Net Controls are dragged and droped in  the (ascx) User Control WebForm Page</li>
  <li> C# Code is wrriten in the (ascx.cs) User Control WebForm Page.C#</li></ul>

<h5>4) To Run the Project Properly </h5>
  <ul><li> Restore the Database in Microsoft SQL Server 2014</li>
  <li> In the C# Code change the connection_object.ConnectString (SqlConnection) </li>
  <li> You will have your own ConnectString , check C# code for format or search Online</li>
  <li> Only Microsoft Edge , Web_Browser</li></ul>
  
<h5>5) What Knowledge is Required before</h5>
  <ul><li> C#</li>
  <li> ASP.Net Controls</li>
  <li> HTML</li>
  <li> CSS</li>
  <li> SQL (Structured Query Language)</li>
  <li> Stored Procedure : Creation and It's Usage in C# Code </li>
  <li> Master Page</li>
  <li> WebForm User Control</li></ul>

## ScreenShots

<img src="ScreenShots/Website/Screenshot (70).png" height="400" width="600">

<img src="ScreenShots/JobSeeker/Screenshot (103).png" height="400" width="600">

<img src="ScreenShots/Website/Screenshot (78).png" height="400" width="600">

<img src="ScreenShots/Employer/Screenshot (139).png" height="400" width="600">

<img src="ScreenShots/Admin/Screenshot (176).png" height="400" width="600">
