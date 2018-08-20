# Troubleshooting

## zsh

When using https://ohmyz.sh/ there is currently an issue with using Global Tools in .net core 2.1 and MacOS. For the global tools to work you need to edit the `.zshrc` file and add:

``` bash
export PATH=$HOME/.dotnet/tools:$PATH
```

The normal `~/.dotnet/tools` is not recognized by `zsh`.
