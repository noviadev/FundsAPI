### Info
Project: FundsApi
Author: Joe Green
Date: 18/10/2020
Description: This was a sample excersise for Novia Financial.

### Notes:

- The exposed API endpoints are as follows:
  /funds
  /fund/{marketCode}
  /managerfunds/{manager}

### Background:

This was a sample excercise based on the following task:

--------------------------------------------------------------
The Test
In all cases here you may make any changes to the Fund Controller that you think necessary, or which you consider would make the Controller more maintainable in the future.

Technical Debts
1) Add Unit Tests
Add a Unit Test project to the solution and implement some checks on the functionality of the underlying models and API calls.

2) RESTful API
Refactor the FundsController to expose an API that you would consider "RESTful" for the operations that currently exist:

Retrieve a single Fund identified by its MarketCode.
Retrieve all Funds.
Retrieve all Funds from a given Fund Manager.
You should adhere to SOLID principles throughout the refactoring process.

3) Add Logging
Add some logging to record API call requests. You may use whichever logging mechanism you are comfortable with to provide this functionality.

User Stories
1) Format Fund Data for 3rd Parties
As a Consumer of the API

So that I can use Novia Fund data

I want a the API to respond with the data in a prescribed format.

Acceptance Criteria
The format of the fund file should not change.
The CurrentUnitPrice should be rounded to 2 decimal places.
The Id field should not be exposed via the API.
The MarketCode field should be exposed via the API as Code.

### Time taken

Total coding time on this project was just over 2 hours. Also, I spent around 45 mins
preparing before I did anything - thinking about what packages I would need, how to manage
data transformation etc. Plus another 15 mins writing up this readme :)

### What could be better

Loads, I could have spent more time making this better, but by the time it was done I
was already over the 2 hour period. Notably

- Testing. I set the test project up at the beginning and just put in a few tests
  around the functionality in the controller. Time was already eating away and I
  hadn't even looked at the refactor. I ended up farming all the functionality
  out of the controller anyway, so the tests needed re-doing. I ended up testing the
  calls from the controller, but time was already up by then. I wanted to write more
  tests to actually check the functionality. I hope I've demonstrated that a) I can
  write unit tests and b) acknowledge that this is not by any means a full and 
  comprehensive suite of tests!! 

- Exception Handling. There's a lot of reliance on the source data being correct. If
  the file format changed unexpectedly, we could see breaking changes. Some level of
  error handling would need to pick this up and provide appropriate status return codes.
  This was on my plan to implement, but given as it wasn't part of the task, it was the
  one thing I could live without.   

Those are the issues I would be immediately addressing if I was to spend any 
more time on the project.

### Points of interest

The user story specifies the currentUnitPrice be rounded by 2 dp. As we are dealing
with financial data, I would have raised the question 'round how, exactly?'. In this
excercise I have simply used Math.Round to achieve this, but there would be caveats.

In the original source code, the get-manager-funds route matches on Name == manager
rather than FundManager == manager:

return this.Ok(funds.Where(x => x.Name == manager)

I would assume this is due to different terminology between consumer and vendor, but
would definitely raise the question and confirm this is as expected. I've left it as
per the source code, but seemed strange at the time!