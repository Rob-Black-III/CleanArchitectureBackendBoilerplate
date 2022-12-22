This file is all our API DTO's. It is separated out to a classlib
to be independent of the webapi frontend, should we choose to do something differently.

REQUEST and RESPONSE come from the Presentation (api) layer
RESULT is a service layer response. 
RESPONSE and RESULT will likely be the same, but I wanted a layer of separation