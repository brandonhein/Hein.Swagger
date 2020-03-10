# Hein.Swagger

### NuGet Information
[Hein.Swagger](https://www.nuget.org/packages/Hein.Swagger/)   
![NuGet](https://img.shields.io/nuget/v/Hein.Swagger.svg?style=flat-square&label=nuget)

```xml
<PackageReference Include="Hein.Swagger" Version="1.0.3" />
```

Fun Repo to create an easier 'Swagger Gen' for api documentation

I wanted to create some helper/extensions/add on's to the awesomeness of [SwaggerGen](https://github.com/swagger-api/swagger-codegen).  I found it difficult to add/implement security keys, and other cool documentation to my api's swagger. (because I really didn't read the documentation, but who ever does :wink:).

So, I added some extension methods to add to the `SwaggerGenOptions` to achieve what 'I' think should be called.  I also added some Attributes/tags to add to your controllers, that will include/exclude from your swagger generation.

# Cool Shiz!
* [Adding a GitHub Repo Link](https://github.com/brandonhein/Hein.Swagger#add-github-repository-url)
* [Enforce API Keys](https://github.com/brandonhein/Hein.Swagger#enforce-api-keys)
* [Include/Exclude Controllers](https://github.com/brandonhein/Hein.Swagger#includeexclude-controllers-andor-actions-from-swagger-gen)
* [Group Controllers via Attribute](https://github.com/brandonhein/Hein.Swagger#group-your-controllers-with-an-attribute)
* [Use Description and Summary Attributes](https://github.com/brandonhein/Hein.Swagger/blob/master/README.md#description-and-summary-attributes-so-long-xml-comments)
* [Document Response Headers in Attributes](https://github.com/brandonhein/Hein.Swagger/blob/produces-headers/README.md#document-response-headers-in-your-swagger)
* [API Versioning Documented in Swagger]()

---

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

---

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
![](/.images/enforce-api-key2.PNG)  
***Bonus for AWS API Gateway enforcers***  
Implementation:
```csharp
services.AddSwaggerGen(x =>
{
   x.EnforceAwsApiKey(); //this will enforce 'x-api-key' in the header
}
```

---

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

---

### Group your Controllers with an Attribute!!!
I have an application that did location lookup... Each controller had a 'Route' that started with 'Lookup'... So I wanted to group them all together. I was amazed there's no good way to do this per the documentation.  I saw here [stackoverflow post]( https://stackoverflow.com/questions/34175018/grouping-of-api-methods-in-documentation-is-there-some-custom-attribute), you have to use a an attribute tag on each method... thats stupid.  So I figured out how to make it controller specific

Implementation:
```csharp
services.AddSwaggerGen(x =>
{
   x.EnableControllerTags();
   //OR
   x.EnableAnnotations();
}
```
```csharp
[SwaggerController("LookMom")]
public class SampleController : Controller
{ }
```
![](/.images/controller-grouping-example.PNG)

---

### Description and Summary Attributes (so long xml comments)
When I saw I needed to include xml comments to help with description of my API's, I was appalled. I've already put all these attributes on my Actions... might as well keep it some what clean with more attributes.  Inspired by `Swashbuckle.AspNetCore.Annotations` I did a similar. :stuck_out_tongue:  

Implementation:
```csharp
services.AddSwaggerGen(x =>
{
   x.EnableDescriptionTags();
   x.EnableSummaryTags();
   //OR
   x.EnableAnnotations();
}
```
```csharp
[HttpPost]
[Consumes("application/json")]
[Produces("application/json")]
[ProducesResponseType(typeof(SampleModel), 200)]
[Description("Post Description")]
[Summary("Ope")]
public IActionResult Post([FromBody] SampleModel model)
{
   return Ok(model);
}
```
![](/.images/example-of-description-and-summary.PNG)

---

### Document response headers in your swagger!
I had an endpoint where I was providing some an extension to the response body in the response headers.  I couldn't find anywhere to add a `ProducesHeader` attribute anywhere to show case that this endpoint has a respone header that needs to be highlighted.  You can now uses it in Attribute form like very thing else!   

Implementation:
```csharp
services.AddSwaggerGen(x =>
{
   x.EnableProducesHeaderTags();
   //OR
   x.EnableAnnotations();
}
```
```csharp
[HttpPost]
[Produces("application/json")]
[ProducesHeader("x-collection-count", SwaggerType.Integer, "sample response header")]
[ProducesHeader("x-another-count", "another header attribute")]
[ProducesResponseType(typeof(SampleModel), 200)]
public IActionResult Post([FromBody] SampleModel model)
{
   return Ok(model);
}
```
![](/.images/produces-response-headers.PNG)

---

### API Versioning documented in swagger!
API Versioning allows you to route behavior between clients.  SwaggerUI allows you to display multiple swagger docs.  I'm a Controller Version guy.  IE: A new Version gets all new/same controllers in a 'v{n}' folder, inside the controllers folder.  This works if you create new routes (don't overwrite routes).  While also managing the SwaggerVersion attribute on the controller.

Implementation:  
In the ConfigureServices Method in startup:
```csharp
services.AddSwaggerGen(x =>
{
   x.SwaggerDoc("v1", new Info {});
   x.SwaggerDoc("v2", new Info {});
   
   x.EnableSwaggerVersioning(); //tells Hein.Swagger to look at the SwaggerVersion attribute on controllers
}
```
In the Configure Method in startup:
```csharp
app.UseSwagger();
app.UswSwaggerUI(c => 
{
   c.SwaggerEndpoint("/swagger/v1/swagger.json", "Hein.Swagger.Sample - v1");
   c.SwaggerEndpoint("/swagger/v2/swagger.json", "Hein.Swagger.Sample - v2");
});
```
Controllers:
```csharp
[SwaggerVersion("v1")]
[Route("sample")]
public class SampleController : Controller
{
}

[SwaggerVersion("v2")]
[Route("v2/sample")]
public class SampleV2Controller : Controller
{
}
```

---

