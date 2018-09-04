Web Development API Task

The purpose is to create an API to manage a user persistence layer.

This solution exposes a user model and it's reasonable to expect that an individual user would have the following attributes:

id - a unique user id
email - a user's email address
givenName - in the UK this is the user's first name
familyName - in the UK this is the user's last name
created - the date and time the user was added

It has the ability to persist user information for at least the lifetime of the test.
And this API exposes functionality to create, read, update and delete (CRUD) models.
