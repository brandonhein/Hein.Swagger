# Hein.Swagger
Fun Repo to create an easier 'Swagger Gen' for api documentation

I wanted to create some helper/extensions/add on's to the awesomeness of [SwaggerGen](https://github.com/swagger-api/swagger-codegen).  I found it difficult to add/implement security keys, and other cool documentation to my api's swagger. (because I really didn't read the documentation, but who ever does :wink:).

So, I added some extension methods to add to the `SwaggerGenOptions` to achieve what 'I' think should be called.  I also added some Attributes/tags to add to your controllers, that will include/exclude from your swagger generation.

# Cool Shiz!
* [Adding a GitHub Repo Link](https://github.com/brandonhein/Hein.Swagger#add-github-repository-url)
* [Enforce API Keys](https://github.com/brandonhein/Hein.Swagger#enforce-api-keys)
* [Include/Exclude Controllers](https://github.com/brandonhein/Hein.Swagger#includeexclude-controllers-andor-actions-from-swagger-gen)
* [Group Controllers via Attribute](https://github.com/brandonhein/Hein.Swagger#group-your-controllers-with-an-attribute)

### Add Github Repository Url
There are times you want to marry up your github repository/code base with your live working app.  So that developers can see your masterpiece.  This extension will create an 'externalDocs' section in your swagger json, and will create a link in your UI.

![](/.images/github-url-on-swagger.PNG)

Implementation:
```csharp
services.AddSwaggerGen(x =>
{
   x.AddGithubRepository("https://github.com/brandonhein/Hein.Swagger");
}
```

### Enforce API Keys
There are times you want to expose your Swagger documentation in a public fashion... but you also want to protect your API endpoints from the outside world.  API keys work great for this!  Swagger comes with some auto authorization setup, but it's tricky to leverage.  This repository makes it easy with an extension to help you out!

Implementation:
```csharp
services.AddSwaggerGen(x =>
{
   x.EnforceHeaderKey("apiKey", "Your Header Access Key");
   x.EnforceQueryKey("queryKey", "Your Query Access Key");
   x.EnforceCookieKey("cookieKey", "Your Cookie Access Key");
}
```
***Bonus for AWS API Gateway enforcers***  
Implementation:
```csharp
services.AddSwaggerGen(x =>
{
   x.EnforceAwsApiKey(); //this will enforce 'x-api-key' in the header
}
```

### Include/Exclude Controllers and/or Actions from Swagger Gen
I recently deployed an application that served as both a UI and API... I wanted to document the API piece for the app, without having swagger generate documentation of the UI controllers and action.  I honestly thought there was something more 'swagger' for an attribute to use other than `ApiExplorerSettingsAttribute` and setting the `IgnoreApi` boolean.  So I added these attributes to 'swagger-ize' your code base up a bit more. Enjoy :smile:

To tell Swagger Gen this controller can be swaggerized:
```csharp
[Swagger]
public class SampleController : Controller
{ }
```
To tell Swagger Gen this controller should be excluded from being swaggerized:
```csharp
[ExcludeFromSwagger]
public class ExcludeController : Controller
{ }
```

### Group your Controllers with an Attribute!!!
I have an application that did location lookup... Each controller had a 'Route' that started with 'Lookup'... So I wanted to group them all together. I was amazed there's no good way to do this per the documentation.  I saw here [stackoverflow post]( https://stackoverflow.com/questions/34175018/grouping-of-api-methods-in-documentation-is-there-some-custom-attribute), you have to use a an attribute tag on each method... thats stupid.  So I figured out how to make it controller specific

Implementation:
```csharp
services.AddSwaggerGen(x =>
{
   x.EnableControllerTags();
}
```
```csharp
[SwaggerController("LookMom")]
public class SampleController : Controller
{ }
```
![](/.images/controller-grouping-example.PNG)
