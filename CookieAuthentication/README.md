Cookie Authentication
=====================

This is a demonstration of how to implement cookie authentication with ASP.NET
Identity.

ASP.NET Identity does most of the heavy lifting here.


Request Flow
------------

### Sign In

    Client                OWIN             ASP.NET MVC          Identity          CookieProvider
    -------              -------           -----------          ---------         --------------
       | Request            |                   |                   |                   |
       | POST /SignIn       |                   |                   |                   |
       |------------------->|                   |                   |                   |
       |                    | OWIN environment  |                   |                   |
       |                    |------------------>|                   |                   |
       |                    |                   |                   |                   |
       |                    |            Read POSTed data           |                   |
       |                    |                   |                   |                   |
       |                    |                   | Look up user      |                   |
       |                    |                   |------------------>|                   |
       |                    |                   |<------------------|                   |
       |                    |                   |                   |                   |
       |                    |                   | Validate password |                   |
       |                    |                   |------------------>|                   |
       |                    |                   |<------------------|                   |
       |                    |                   |                   |                   |
       |                    |                   | Create IIdentity  |                   |
       |                    |                   |------------------>|                   |
       |                    |                   |<------------------|                   |
       |                    |                   |                   |                   |
       |                    | ctx.Auth.SignIn() |                   |                   |
       |                    |<------------------|                   |                   |
       |                    |                   |                   |                   |
       |                    | AuthenticationManager calls AddUserIdentity(IIdentity)    |
       |                    |---------------------------------------------------------->|
       |                    |                   |                   |                   |
       |                    |                   |                   |          Add a cookie to the
       |                    |                   |                   |            response object
       |                    |                   |                   |                   |
       |                    |                   |                   | Save the identity |
       |                    |                   |                   | to Request.User   |
       |                    |                   |                   |<------------------|
       |                    |                   |                   |------------------>|
       |                    |                   |                   |                   |
       |                    |                   |               Return control          |
       |                    |<----------------------------------------------------------|
       |                    |------------------>|                   |                   |
       |                    |                   |                   |                   |
       |                    |           Request continues           |                   |
       |                    |                   |                   |                   |
       |                    |          Save the principal           |                   |
       |                    |          to HttpContext.User          |                   |
       |                    |                   |                   |                   |
       |                    |                   | Call next OWIN handler                |
       |                    |                   |-------------------------------------->|
       |                    |                   |                   |                   |
       |                    |       The Authorize attribute         |                   |
       |                    |        instructs Web API to           |                   |
       |                    |       inspect HttpContext.User        |                   |
       |                    |        for authentication and         |                   |
       |                    |          role membership              |                   |
       |                    |                   |                   |                   |
    -------              -------             -------             -------             -------


### Requests after signing in

    Client                OWIN             ASP.NET MVC          Identity          CookieProvider
    -------              -------           -----------          ---------         --------------
       | Request            |                   |                   |                   |
       | GET /Foobar        |                   |                   |                   |
       |------------------->|                   |                   |                   |
       |                    | OWIN environment  |                   |                   |
       |                    |-------------------------------------->|                   |
       |                    |                   |                   | Calls             |
       |                    |                   |                   | authentication    |
       |                    |                   |                   | providers         |
       |                    |                   |                   |------------------>|
       |                    |                   |                   |                   |
       |                    |                   |                   |          Finds the cookie in the
       |                    |                   |                   |         request headers, verifies
       |                    |                   |                   |          it hasn't been tampered
       |                    |                   |                   |        with, and sets Request.User
       |                    |                   |                   |                   |
       |                    |                   |                   |<------------------|
       |                    |<--------------------------------------|                   |
       |                    |                   |                   |                   |
       |                    | OWIN environment  |                   |                   |
       |                    |------------------>|                   |                   |
       |                    |                   |                   |                   |
       |                    |       The Authorize attribute         |                   |
       |                    |       instructs ASP.NET MVC to        |                   |
       |                    |       inspect HttpContext.User        |                   |
       |                    |        for authentication and         |                   |
       |                    |          role membership              |                   |
       |                    |                   |                   |                   |
    -------              -------             -------             -------             -------
