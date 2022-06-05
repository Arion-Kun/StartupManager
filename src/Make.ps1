# Minimum Script Requirement: Set-ExecutionPolicy Bypass

$NUGET_LINK = 'https://dist.nuget.org/win-x86-commandline/latest/nuget.exe'
$DOTNET_LINK = 'https://dot.net/v1/dotnet-install.ps1'
$NET48DEVPACK_LINK = 'https://go.microsoft.com/fwlink/?linkid=2088517'

Write-Output "The project needs the .Net 4.8 Developer Pack to successfully build"
Write-Output "If you are certain this is installed you should say 'No' to the installation prompt"
Write-Output "Would you like to download and install the '.Net 4.8 Developer Pack' now? y/n"

$downloadNet48 = Read-Host
if ($downloadNet48 -eq "y")
{
    Write-Output "This may take some time (142mb)."
    Invoke-WebRequest $NET48DEVPACK_LINK -O ndp48-devpack-enu.exe
    ./ndp48-devpack-enu.exe /install /passive
    Write-Output "Would you like to continue?"
    Read-Host    
}

# Check if Nuget.exe is in this working directory.
if (!(Test-Path -Path Nuget.exe)) 
{
    Write-Output "Downloading Nuget CLI Tool from '$NUGET_LINK'" 
    Invoke-WebRequest $NUGET_LINK -O Nuget.exe;
}
./Nuget.exe restore
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
    Remove-If-Present 'dotnet-install.ps1'
    Remove-If-Present 'Nuget.exe'
    Remove-If-Present 'ndp48-devpack-enu.exe'
}

if (!(IsDotnetPresent))
{
    Write-Output "Downloading the Dotnet SDK from '$DOTNET_LINK'"
    # If the install script is not here, we download it and ask to install, if the script is here, we ask to install.
    if (!(Test-Path -Path dotnet-install.ps1)) 
    {
        Invoke-WebRequest $DOTNET_LINK -O dotnet-install.ps1
        Write-Output "The install file has been downloaded."
    }
    else 
    {
        Write-Output "The install file has been detected."
    }
    
    Write-Output "Installing Please wait..."
    Write-Output "This might take a while!"
    Write-Output "#########################"
    ./dotnet-install.ps1
}
dotnet build -c Release
Start-Cleanup
