# RetailAdvertisingTool

This is an **ASP.NET MVC** Project created to learn more about **ASP.NET MVC**. 

This application is designed to help with the retail advertising process that retail buying offices do. The tool integrates two APIs. It uses the **Salesforce API** and the **Google Calendar API**. 

This applicaiton also uses **CSS/Bootstrap**, **HTML/CSHTML**, **Javascript/Jquery**, and **C#/Razor Syntax**


###Project Screenshots

######Home Page
![Screen Shot](https://github.com/mfcastro/RetailAdvertisingTool/blob/master/Screenshots/index%20page.PNG)
This page allows users to select access the advertising calendar, create an offer, manage existing offers, and check current samples.
</br>

######Advertising Calendar
![Screen Shot](https://github.com/mfcastro/RetailAdvertisingTool/blob/master/Screenshots/calendar%20page.PNG)
This calendar uses Google Calendar API to get the information for a google calendar. I used [FullCalender](http://fullcalendar.io/) to display a calender where I put my google caleder events on. 
</br>

######Create offer page
![Screen Shot](https://github.com/mfcastro/RetailAdvertisingTool/blob/master/Screenshots/create%20offer%20page.PNG)
Pulls in product information from a Salesforce database using the Salesforce REST API. For example the TY Product description is a pulldown that has all the available samples.
<br>
######Created offers page
![Screen Shot](https://github.com/mfcastro/RetailAdvertisingTool/blob/master/Screenshots/offer%20list%20page.PNG)
This page lists all the offers and their details that were created in the **Create offer Page**


######Sample Management Inventory List Page
![Screen Shot](https://github.com/mfcastro/RetailAdvertisingTool/blob/master/Screenshots/inventory%20list%20page.PNG)
This page shows all the available inventory that the user has access to.


######Sample Management Inventory List Page (Picture View)
![Screen Shot](https://github.com/mfcastro/RetailAdvertisingTool/blob/master/Screenshots/inventory%20list%20picture%20view%20page.PNG)
This is the same information as the Inventory List Page, it just displays image thumbnails. 


######Sample Mangement Item Description Page
![Screen Shot](https://github.com/mfcastro/RetailAdvertisingTool/blob/master/Screenshots/inventory%20item%20page%20view.PNG)
This shows the image description along with a picture of the image. This information is pulled from Salesforce. An optional **Order** pops up when the sample is not in house and needs to be ordered. The **Order** button redirects the user to the *Vendor Email Form*. 

###### Sample Managment Vendor Email Form
![Screen Shot](https://github.com/mfcastro/RetailAdvertisingTool/blob/master/Screenshots/Email%20contact%20form.PNG)
This form pulls in Vendor Emails from Salesforce. It then sends a HTML email to vendor with the item information that was selected from the dropdown. The items that are shown in the dropdown are all the items that the user does not have in house. 

######Example of Vendor Email Message
![Screen Shot](https://github.com/mfcastro/RetailAdvertisingTool/blob/master/Screenshots/sample%20email.PNG)
This a the sample eamil that is sent the the Vendor email that is pulled from Salesforce. The email shows who sent the message and their email address to reach them. I shows in bold what item was requested. It also shows the additional comments that the user wrote.

