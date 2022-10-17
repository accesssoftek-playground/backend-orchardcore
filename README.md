# backend-orchardcore
Orchard Core based backend solution for the Admin Tool prototype

# Getting started with Docker
Run the following command to start the backend:
```
docker build -f Dockerfile -t latest . && docker run -p 5001:80 --env OrchardCore__OrchardCoreHeadlessBackend__EnabledModules=RandomQuoteModule --env OrchardCore__OrchardCore_AutoSetup__Tenants__0__AdminUsername=admin --env OrchardCore__OrchardCore_AutoSetup__Tenants__0__AdminEmail=REPLACE_ME --env OrchardCore__OrchardCore_AutoSetup__Tenants__0__AdminPassword=REPLACE_ME --name OrchardCoreHeadless latest 
```

# Getting started with IDE
Configure the launchSettings.json file to set the environment variables:
```
{
  "profiles": {
    "OrchardCoreHeadless": {
      "commandName": "Project",
      "environmentVariables": {
        "OrchardCore__OrchardCoreHeadlessBackend__EnabledModules": "RandomQuoteModule",
        "OrchardCore__OrchardCore_AutoSetup__Tenants__0__AdminUsername": "admin",
        "OrchardCore__OrchardCore_AutoSetup__Tenants__0__AdminEmail": "REPLACE_ME",
        "OrchardCore__OrchardCore_AutoSetup__Tenants__0__AdminPassword": "REPLACE_ME"
      }
    }
  }
}
```