Before running, check the connectionString for EF. Currently pointing to :(data source=(localdb)\ProjectsV12;initial catalog=OrderViewer.Database)

This application is a sample SPA application which displays data from OrderViewer database and displays in UI. It uses 
WebAPI2, Asp.net MVC, AngularJS, EF to do this job.

There is lot to be done, if we want to take this application to next level as an Enterprise level system:

-> Authentication: Authentication mechanism shoudl be added to only allow valid users to access the application.
We should be implementing OWIN based authentication using Asp.NetIdentity with OAuth2 specification. We can use
token based Authentication, where one service can authenticate the initial request and provide a token which can be passed
as Bearer header in subsequent requests. Token will have the user identity and claims related data. This 
can help in having a uniform auth-interface with support for features like Single Sign on.

-> Address security concerns. There are lot of things that needs to be taken in consideration to provide better
security of data, like to use HTTPS, disable x-FrameOptions for unknown domains, prevent CSRF attacks, 
SQL injections, denial of service attacks, etc

-> Authorization: Depending on business need, we should create Authorization roles to restrict the access.

-> Use Dependency Injector framework like unity to support IOC.

-> Make UI responsive to accommodate different screen sizes.

-> Right now WebAPI just returns the EF model class. This is not ideal in an Enterprise application. Instead we should
write custom model for Resources which meets the business needs.

-> Currently, WebAPI is hosted within the same project as with our application. Ideally, we should take WebAPI
out and host it in separate project, so that it can be hosted separately. We will also need to enable CORS.
Doing this will provide lot of flexibility during deployment in load balancing and scaling the application.

-> There is no logging at present. Any application deployed in Production environment, must have good 
logging to readily troubleshoot issues. 

-> Another nice to have is a WebAPI documentation. We can use tools like Swagger to develop interactive and intuitive documentation.

-> WebAPI is pretty basic at this stage. We would like to support features like optional grouping of Resources, pagination, filtering
PATCH, version support, Cache, (or even OData if there is a business requirement)

-> Client should not be guessing urls of child item (eg. orderitems within an order), instead url of resource should be returned by the API.
-> Tests: An enterprise application must have unit and integration tests.

-> Set up continuous builds for the application.

-> Client side and API side caching can be introduced to improve response time and performance under load.


