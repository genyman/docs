# CSharp Project Helpers

Within the Genyman Core Library there are severall helper functions to manipulate csproj (CSharp) files.

## Methods

### Add resource

- AddXamarinIosResource
- AddXamarinAndroidResource
- AddXamarinUWPResource

Extension methods for the given (full path) csproj folder (**NOT!** the csproj file itself).

```
platformProjectFolder.AddXamarinIosResource(destinationFile);
```

This will add the resource file to the csproj file if it doesn't exists already.


