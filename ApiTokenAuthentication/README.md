API Token Authentication
========================

This is a demonstration of how to implement token authentication with ASP.NET
Identity and Web API 2.

The request includes an authentication token (a "bearer token") in the HTTP
headers:

    POST /foo HTTP/1.1
    Authentication: Bearer 8847BE83203D4F97AC2377B542BC0B40

    {"data":"some request object"}

ASP.NET Identity finds this token in the header, associates it with a user, and
adds the user principal into the OWIN environment and (for IIS) into the
HttpContext.


Request Flow
------------

    Client                OWIN             Middleware           Identity            Web API
    -------              -------           ----------           ---------           -------
       | Request with       |                   |                   |                   |
       | Authorization      |                   |                   |                   |
       | header             |                   |                   |                   |
       |------------------->|                   |                   |                   |
       |                    | OWIN environment  |                   |                   |
       |                    |------------------>|                   |                   |
       |                    |                   |                   |                   |
       |                    |             Validate token            |                   |
       |                    |              in the header            |                   |
       |                    |                   |                   |                   |
       |                    |                   | Look up user      |                   |
       |                    |                   | (optional, could  |                   |
       |                    |                   | do this without   |                   |
       |                    |                   | Identity)         |                   |
       |                    |                   |------------------>|                   |
       |                    |                   |<------------------|                   |
       |                    |                   |                   |                   |
       |                    |          Save the principal           |                   |
       |                    |          to HttpContext.User          |                   |
       |                    |                   |                   |                   |
       |                    |                   | Call next OWIN handler                |
       |                    |                   |-------------------------------------->|
       |                    |                   |                   |                   |
       |                    |                   |                   |         The Authorize attribute
       |                    |                   |                   |          instructs Web API to
       |                    |                   |                   |         inspect HttpContext.User
       |                    |                   |                   |          for authentication and
       |                    |                   |                   |            role membership
       |                    |                   |                   |                   |
    -------              -------           ----------           ---------           -------
