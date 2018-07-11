# Genyman

Code Generator tools for .net core CLI

- Core Package
- CLI

### Work in progress

Documentation will be added soon!


### Some notes to remember

#### zsh

When using https://ohmyz.sh/ there is currently an issue with using Global Tools in .net core 2.1 and MacOS.
For the global tools to work you need to edit the `.zshrc` file and add:

```
path+=('/Users/YOUR_USER_NAME/.dotnet/tools')
export PATH
```

The normal `~/.dotnet/tools` is not recognized by `zsh`.