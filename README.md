# Mini-project-Asset-tracking
C# .NET course w37 Asset Tracking


<h1>Solution</h1>
I have solved all parts of the assignment.

I could not get my JSON files to work with nested JSON. I therefore had to do a workaround instead of using class instances within other class instances.

<h1>Assignment</h1>
This project is the start of an Asset Tracking database. It should have input possibilities from a user and print out
functionality of user data.
Asset Tracking is a way to keep track of the company assets, like Laptops, Stationary computers, Phones and so
on...
All assets have an end of life which for simplicity reasons is 3 years.

<h2>Level 1</h2>
Create a console app that have classes and objects. For example like below with computers and phones.
<ul>
<li>Laptop Computers</li>
<ul>
<li>MacBook
<li>Asus
<li>Lenovo
</ul>
<li>Mobile Phones
<ul>
<li>Iphone
<li>Samsung
<li>Nokia
</ul>
</ul>
You will need to create the appropriate properties and constructors for each object, like purchase date, price,
model name etc.

<h2>Level 2</h2>
Create a program to create a list of assets (inputs) where the final result is to write the following to the console:
<ul>
<li>Sorted list with Class as primary (computers first, then phones)
<li>Then sorted by purchase date
<li>Mark any item *RED* if purchase date is less than 3 months away from 3 years.
</ul>
<h2>Level 3</h2>
Add offices to the model:<br>
You should be able to place items in 3 different offices around the world which will use the appropriate currency
for that country. You should be able to input values in dollars and convert them to each currency (based on
todays currency charts)

When you write the list to the console:
<ul>
<li>Sorted first by office
<li>Then Purchase date
<li>Items *RED* if date less than 3 months away from 3 years
<li>Items *Yellow* if date less than 6 months away from 3 years
<li>Each item should have currency according to country</ul>
