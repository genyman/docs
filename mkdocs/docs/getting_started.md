# Getting started

Now that you have installed `genyman` it is time to create your first generator. All generators are in fact .NET Core Tools but `genyman` provides you an easy way to build and execute the generators. In fact, `genyman` itself contains a code generator, more specific, to create a new generator.

## NEW command

To create a new code generator, create an empty folder, and then execute:

``` bash
genyman new
```

This will produce a `gm-genyman.json` file. This gives you an idea on what `genyman` is; it will use configuration files to generate, or execute code. Take a look at the produced `.json` file:

``` json
{
    "genyman": {
        "packageId": "Genyman",
        "version": "0.0.5",
        "nugetSource": ""
    },
    "configuration": {
        "prefix": "YourPrefix",
        "toolName": "YourToolName"
    }
}
```

All `genyman` configuration files will have two parts; the first structure is `genyman`. This will contain the name of the package that is used to execute this configuration file, together with the `version` used to create the file and a `nugetSource` that is used to resolve the package (leave empty for the default `nuget.org`).

The second structure is `configuration`. Hereunder you will find the specific configuration parameters for the generator. In this case two values are available:

- `prefix`: this is actually the prefix used in the package identifier, mostly the username or organization name of the pacakge.
- `toolName`: the specific name of the code generator you are going to build.

For this tutorial we will enter the following:

``` json
{
    "genyman": {
        "packageId": "Genyman",
        "version": "0.0.5",
        "nugetSource": ""
    },
    "configuration": {
        "prefix": "Tutorial",
        "toolName": "FirstGenerator"
    }
}
```

## Create a new generator solution

As said, the `new` command from the genyman cli itself is a generator. The way you can execute the generator is just running

``` bash
genyman gm-genyman.json
```

This will create a `src` folder which contains a template solution for you to create a new code generator.

## Configuration

If you take a look at the solution, you will find an `Implementation` folder with a `Configuration.cs` file. This is a placeholder class for your configuration parameters. Just like the configuration parameters we had to fill in for our new template. Basically you just add public properties to this class. Later these properties will be translated to parameters in you configuration file.

For this tutorial we are going to keep it simple - for a better sample just check the code in the genyman-cli repository.

``` csharp
public class Configuration
{
	public string Value1 { get; set; }
	public string Value2 { get; set; }
}
```

## Template

You saw that running the `new` command produced a pre-filled configuration file. In order to get the same behavior you set properties for a `Configuration` instance that is created in the `NewTemplate.cs` class:

``` csharp
public class NewTemplate : Configuration
{
	public NewTemplate()
	{
		Value1 = "FirstSampleValue";
		Value2 = "SecondSampleValue";
	}
}
```

This will later produce a configuration file with these values pre-filled.

## Generator

Finally, the `Generator.cs` is the location where the real work has to be done. Following skeleton is your starting point:

``` csharp
public class Generator : GenymanGenerator<Configuration>
{
	public override void Execute()
	{
		ProcessHandlebarTemplates();
	}
}
```

In this `Execute` you write the necessary code for your code generator. This method is called by `genyman` and the `Configuration` property of the class is a pre-filled `Configuration` instance, having the values of the given configuration file (if not changed by the user, it will contain the default property values defined in the `NewTemplate.cs` class).

You can use whatever technique you want to generate code, but the easiest way to do is using [Handlebars](https://handlebarsjs.com/) templates. These templates need to be added in the `Templates` folder in your solution.



## Templates

In the `Templates` folders you can add any file you want to be included for your generator. The `csproj` is configured to exclude these files for compilation, but to include these as content files later in your package. These files can contain any of the basic Handlebars identifiers, helpers, and even more, the file itself can have these identifiers. For a good example, check the `genyman` cli repository.

For this tutorial we will add a simple csharp file.

``` csharp
namespace OurGenyman.Tutorial;
{
	public class Sample
	{
		public string FirstValue = "{{ Value1 }}";
		public string SecondValue = "{{ Value2 }}";
	}
}
```

Just name this file `MyClass.cs`.

## Test your generator

That's it! We are now ready to test our generator. As said, the created solution is just a plain .NET Core console application, packed as a tool. That means you can just run/debug the console application; in your favourite IDE you can start the application with the argument `new`.

!!! note
    To test your generator, a good practice is to use a new folder outside your solution, and put this as the working directory when you run your program.


This will produce a `.json` file that contains your template values. Change these values at will. Next run/debug your application again, but this time provide the `json` file as the argument of your application.

You will see that the output is a MyClass.cs file with the `Value1` and `Value2` values replaced.

You can put breakpoints in the `Execute` method of your generator.

## Next

This is a quick overview on how you can create a new generator. Of course there is much more you can do; `genyman` has some more nice features you can use. You will find out about these feature in the various sections of this documentation.
