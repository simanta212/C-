Steps that I had done.
1. created a databse with tables. (set id as primary key and enable auto increment)
2. From model added edo.net entity data model.(select all 3 from the table). 
   For example view image
---------- After this firstly run your project,check if the server is running or not------
3. From controller add controller with MVC 5 with views,using Entity Frmwrk.
   Then add controller name to create CRUD pages.
4. At _layout.cshtml add <li>@Html.ActionLink("BOOKMASTER", "Index","BOOKMASTERs")</li  
   so that you can view your newly created webpage on navbar.
5. From your main project select properties, from web give direct path to your 
   desired page as an index to load it as an index page.

Reference - https://www.youtube.com/watch?v=OLBmtRFFwcQ

create table Author(
Author_ID int,
Created_Date date,
Updated_Date date,
Is_Discontinued BIT default 'false',
Author_Name varchar(50),
);