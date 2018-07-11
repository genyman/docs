# Welcome to Genyman

Genyman is a .NET Core Global tool, a new .NET Core feature since the release of version 2.1. You can find more in the [official document](https://docs.microsoft.com/en-us/dotnet/core/tools/global-tools).

With Genyman it is possible to easily build code generation tools that uses a configuration file as input. This way you can use these files inside your dev environment and generate code over and over again with the same settings.

## How to install

To install `genyman` you need to execute the following command in your console / command prompt:

``` bash
dotnet tool install -g genyman
```

After installation you will be prompted:

```bash
You can invoke the tool using the following command: genyman
Tool 'genyman' (version 'x.x.x') was successfully installed.
```

!!! note "Getting help"  
    When you execute `genyman` or `genyman --help` you will get info about all available options.

## How to update

To update the tool to the latest version:

``` bash
dotnet tool update -g genyman
```

!!! note "Update"
    We will add an indication when running `genyman` if you are not running the latest version in a future release.

## How to uninstall

To remove `genyman` from your system:

``` bash
dotnet tool uninstall -g genyman
```