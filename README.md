# autoinstall
![autoinstall](https://github.com/user-attachments/assets/8529d47b-1875-491c-8742-7430b1716b65)

### An alternative of Ninite, save time installing apps!


### [Download](https://github.com/keithudev/autoinstall/releases)


## Want to contribute?
Contribute by adding more apps, since it is very difficult to add them one by one.

To add an app go to the `Apps.cs` file, all the apps will be there.

### How does it work?
```js
{
  'Development': { // This is where the category will be called, within that category are the apps.
      'vscode': { // ID of the app
          'name': 'Visual Studio Code', // Name of the app
          'icon': 'vscode.png', // Icon
          'downloadUrl': 'https://code.visualstudio.com/sha/download?build=stable&os=win32-x64-user', // Download URL
          'type': 'exe', // Type of executable (exe or msi)
          'params': '/silent', // Parameters to add to the executable
          'afterParams': 'taskkill /f /im Code.exe' // Post-install command
      }
  }
}
```

### How to add an icon?
1. Add the icon image to the "icons" folder (it must be in low quality, to save space).
2. Add `<None Remove="icons\icon.png" />` in the `<ItemGroup>` in `autoinstall.csproj`
3. Add `<Resource Include="icons\icon.png" />` in the second `<ItemGroup>` in `autoinstall.csproj`
