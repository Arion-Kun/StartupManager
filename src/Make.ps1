# Minimum Script Requirement: Set-ExecutionPolicy Bypass

$NUGET_LINK = 'https://dist.nuget.org/win-x86-commandline/latest/nuget.exe'
$DOTNET_LINK = 'https://dot.net/v1/dotnet-install.ps1'
$NET48DEVPACK_LINK = 'https://go.microsoft.com/fwlink/?linkid=2088517'

function EnsureArtifactsFolderExists
{
    if ($(Test-Path -Path "./Artifacts") -eq $false)
    {
        mkdir "Artifacts" > $null
    }
}
function EnsurePackagesFolderExists
{
    if ($(Test-Path -Path "./packages") -eq $false)
    {
        mkdir "packages" > $null
    }
}

EnsureArtifactsFolderExists

Write-Output "The project needs the .Net 4.8 Developer Pack to successfully build"
Write-Output "If you are certain this is installed you should say 'No' to the installation prompt"
Write-Output "Would you like to download and install the '.Net 4.8 Developer Pack' now? y/n"

$downloadNet48 = Read-Host
if ($downloadNet48 -eq "y")
{
    Write-Output "This may take some time (142mb)."
    Invoke-WebRequest $NET48DEVPACK_LINK -O "./Artifacts/ndp48-devpack-enu.exe"
    ./Artifacts/ndp48-devpack-enu.exe /install /passive
    Write-Output "When the Pack is installed press any key to continue."
    Read-Host    
}

# Check if Nuget.exe is in this working directory.
if (!(Test-Path -Path "./Artifacts/Nuget.exe")) 
{
    Write-Output "Downloading Nuget CLI Tool from '$NUGET_LINK'" 
    Invoke-WebRequest $NUGET_LINK -O "./Artifacts/Nuget.exe";
}

Write-Output "Performing Nuget Package Restore"
# Below we redirect the output of the Nuget restore process to nothing since there are some unimportant errors which display.
.\Artifacts\Nuget.exe restore -Verbosity quiet -PackagesDirectory "./packages/" > $null 
function IsDotnetPresent
{
    $ThrowErrorPolicy = $ErrorActionPreference
    $ErrorActionPreference = 'stop'
    try { if (Get-Command dotnet) { return $true } }
    catch { return $false }
    finally { $ErrorActionPreference = $ThrowErrorPolicy }
}
function Remove-If-Present
{
    param([Parameter (Mandatory = $true)] [String]$FileName)
    if (Test-Path $FileName)
    {
        Remove-Item $FileName
    }
}
function Start-Cleanup
{
    #Trailing Artifacts
    Remove-If-Present './Artifacts/dotnet-install.ps1'
    Remove-If-Present './Artifacts/Nuget.exe'
    Remove-If-Present './Artifacts/ndp48-devpack-enu.exe'
}

if (!(IsDotnetPresent))
{
    Write-Output "Downloading the Dotnet SDK from '$DOTNET_LINK'"
    # If the install script is not here, we download it and ask to install, if the script is here, we ask to install.
    if (!(Test-Path -Path dotnet-install.ps1)) 
    {
        Invoke-WebRequest $DOTNET_LINK -O "./Artifacts/dotnet-install.ps1"
        Write-Output "The install file has been downloaded."
    }
    else 
    {
        Write-Output "The install file has been detected."
    }
    
    Write-Output "Installing Please wait..."
    Write-Output "This might take a while!"
    Write-Output "######################"
    ./Artifacts/dotnet-install.ps1 > $null
}
dotnet build -c Release

Write-Output "The Build Output Is in '\src\StartupManager\bin\Release'"
# Start-Cleanup
