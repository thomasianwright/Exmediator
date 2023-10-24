# Exmediator - A simple and more barebones alternative to other popular mediator libraries

## Information

The goal for this implementation is to be fast and easy for people to fork.
Since it is easy to create new mediator events and handlers.
Possibly making it easier to use service buses' etc...
While also keeping a bare bones approach to the implementation.

By removing a lot of the magic associated with reflection and other things. Removing pipelines, build in error handling
as a must, etc...
This keeps the focus on the code and what it is doing. Rather than just throwing up the callstack. So retries, logging
and other things can be added as needed.

## Credits
Thomas Wright - [GitHub](https://github.com/thomasianwright)