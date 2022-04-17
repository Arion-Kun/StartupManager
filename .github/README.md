# StartupManager

#### ⚙️Requirements:
- [Windows 10](https://www.microsoft.com/en-us/software-download/windows10) or higher
- [Windows PowerShell](https://en.wikipedia.org/wiki/PowerShell) minimum execution policy set to `Unrestricted` or `Bypass` to allow the script to run ([Tutorial here](https://www.sqlshack.com/choosing-and-setting-a-powershell-execution-policy/)) (Most developers already have this enabled so if you develop dotnet apps regularly you can likely skip this step)
- [Git](https://git-scm.com/downloads)

### 👀 Preview

[Previews found here](https://github.com/Arion-Kun/StartupManager/tree/main/Previews/Index.md)

### 📝 Build
```
git clone https://github.com/Arion-Kun/StartupManager
cd .\StartupManager\src
.\Make.ps1
```
The output folder for `Make.ps1` is set to `...\src\StartupManager\bin\Release`

### 📝 Note
The project makes use of the code-behind pattern as other patterns such as MVVM are more complimented by WPF applications rather than WinForms.