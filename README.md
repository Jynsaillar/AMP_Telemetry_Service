# AMP_Telemetry_Service
Azure Media Player (AMP) microservice. Receives telemetry data from an AMP plugin, returns processed analytics. 

## TL;DR:
* Install [Visual Studio with ASP.NET](https://docs.microsoft.com/en-us/aspnet/core/tutorials/first-mvc-app/start-mvc?view=aspnetcore-6.0&tabs=visual-studio#prerequisites)
* Clone the repository:
```
$> git clone git@github.com:Jynsaillar/AMP_Telemetry_Service.git
```
* Open the AMP_Telemetry_Service folder in any file explorer and open AMP_Telemetry_Service.sln with Visual Studio
* Switch to the devel branch:
* Via terminal:
```
$> git checkout devel
```
* Via Visual Studio UI -> click on the branch label (main/devel) on the bottom source control bar
* Run debug: Hit F5 (default debug profile should be AMP_Telemetry_Service)

By default, the browser should open automatically and navigate to the Swagger UI (for REST API debugging), the GET endpoint can (on default values) 
be accessed on 
```
https://localhost:7140/telemetry
```
