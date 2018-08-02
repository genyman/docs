# FluentMSBuild

Within the Genyman Core Library there are severall helper functions to manipulate csproj (CSharp) files. There is a fluent helper to do some basic stuff.

## Samples

Adding (if it not exists) of a file into a project (or shared project).

```
FluentMSBuild.Use(destinationFile).WithBuildAction(BuildAction.ImageAsset).AddToProject();
```

This will add the destinationFile into the underlying project (destinationFile is for example a cs file or image). The method will look for a csproj (or shared project) in the directory tree above. Next it can be set a BuildAction (like Content, Compile, etc). Finish with the AddToProject method.

The builder is self explaining. If not, drop a question.



