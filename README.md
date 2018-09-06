# WebAppStatus
An add-on component to an MVC 4.6 App that allows you to easily add some tests to your Web App

To add a new test, simply add a class that implements `IHealthTest`.

```
public interface IHealthTest
{
   TestResult Run();
}
```

Any class that implements this interface will be instantiated and the method `Run()` will be executed anytime that someone accesses the URL: `/health` on your website.

When any test fails, the health page will prominantly display the message: 

"One or more errors occurred during testing!"

You can easily set a service to monitor the URL `/health` and look for the phrase "One or more errors occurred during testing!". The monitoring service can then alert you when this occurs.
