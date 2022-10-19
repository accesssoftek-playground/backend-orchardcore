# backend-orchardcore
Orchard Core based backend solution for the Admin Tool prototype

# Getting started with Docker
Run the following command to start the backend:
```
docker build -f Dockerfile -t ast.orchardcoreheadless:latest . && docker run -p 5002:80 --env OrchardCore__OrchardCore_AutoSetup__Tenants__0__AdminEmail=REPLACE_ME --env OrchardCore__OrchardCore_AutoSetup__Tenants__0__AdminPassword=REPLACE_ME --env OrchardCore__OrchardCore_AutoSetup__Tenants__0__AdminUsername=admin --env OrchardCore__OrchardCoreHeadlessBackend__EnabledModules=RandomQuoteModule;SqlitePersistenceModule --name OrchardCoreHeadless ast.orchardcoreheadless:latest 
```

# Getting started with IDE
Configure the launchSettings.json file to set the environment variables:
```
{
  "profiles": {
    "OrchardCoreHeadless": {
      "commandName": "Project",
      "environmentVariables": {
        "OrchardCore__OrchardCoreHeadlessBackend__EnabledModules": "RandomQuoteModule;SqlitePersistenceModule",
        "OrchardCore__OrchardCore_AutoSetup__Tenants__0__AdminUsername": "admin",
        "OrchardCore__OrchardCore_AutoSetup__Tenants__0__AdminEmail": "REPLACE_ME",
        "OrchardCore__OrchardCore_AutoSetup__Tenants__0__AdminPassword": "REPLACE_ME"
      }
    }
  }
}
```