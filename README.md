# XeroTestProject

There are three tests:
- Two Basic flows : Login success and Add bank account
- one exception Flow : Invaid Login

Assumption: 
- Add bank account is for a pre existing customer.

How to run: 
- Tests located path: XeroTestProject\Tests. 
- Tests will be appeared in the Test Explorere and just select the test and hit the run button. 
- If you want to use a different user account make sure to change the credentials and Security questions and answers in the "AddBankAcountTest".

Future Improvements:
- Data parcing via test Data table insted hard code in the project.
- Add a headless browser profile/run script
- create page classes for each different pages, unlike "AddBankAccountPage" in my solution. 
- Add more exceptional and altanative Test cases for Add acount Scenario. 
- Move all the config Data (Eg: User credentials, Security Questions) into a seperate configuration file.
