# Final Identity Grading Criteria.
Everyone that turned in the daily assignments and made any progress will be getting the 5 points for each. The final submission will be graded strictly by the below criteria.  I will be grading final submissions tomorrow.  Resubmissions will be permitted as per usual.
Paste the below list in your README and for each of the below items, add the requested information.

## ~~3 points - Create 2 different types of users~~

Where can I find these roles?
* These roles are listed at the bottom of the startup class.

## ~~4 points - Create a different registration page for the Admin page~~
How do I access this page and create an admin?
* Go to the url ~/Admin/Register and paste in the password "IAmAnAbsolutelySafeAndSecureHardCodedPassword"

## 4 points - Attach at least 4 claims (including their Role) to the registration process.
Where can I find this?

## ~~4 points - Redirect the user, dependant on their role, to a specific page, upon login~~
Where and how can I test this?
* The home page redirects you to the admin page if you are an admin.

## ~~4 points (1 point for each CRUD operation) - Create a standard CRUD controller to manipulate data within your site.~~
How do I use your sites CRUD functionality?
* You can create Server pages, see any server page, edit your server and delete your server. Comments coming soon!

## ~~4 points - Restrict your CRUD controller to specific access.~~
Where this is implemented?
* Creating a Server page is limited to signed-in users. Editing and Deleting them is reserved to Admin role or to owners of the resource.

## ~~3 points - Update your application to include at least 2 roles.~~
Where are they declared, where are they used?
* This entry is on the list twice.

## ~~3 points - Add at least one role based policy and one custom Authorization Handler policy to your application.~~
Where are they?
* The Admin page is only accessable to Admins, there's also a mostly complete policy that limits access to owners of a resource or admins. See the Authorization folder for related files.

## ~~3 points - Implement both of these policies in your site.~~
How are they used?
* The admin page is only accessable to admins, and the custom policy is applied to the edit and delete actions in the MCServersController.

## ~~3 points - Update your application to include a View Component.~~
I can find this :)
* It's attached to the home page and admin landing page and it's the index for the MCServer model.
DON’T FORGET TESTS!!!!
* Not yet!
