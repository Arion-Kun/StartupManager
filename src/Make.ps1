# Minimum Script Requirement: Set-ExecutionPolicy RemoteSigned

$NUGET_LINK = 'https://dist.nuget.org/win-x86-commandline/latest/nuget.exe'
$DOTNET_LINK = 'https://dot.net/v1/dotnet-install.ps1'

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
}

if (!(IsDotnetPresent))
{
    Write-Output "Downloading the Dotnet SDK from '$DOTNET_LINK'"
    # If the install script is not here, we download it and ask to install, if the script is here, we ask to install.
    if (!(Test-Path -Path dotnet-install.ps1)) 
    {
        Invoke-WebRequest $DOTNET_LINK -O dotnet-install.ps1
        Write-Output "The install file has been downloaded, would you like to install now? y/n"
    }
    else 
    {
        Write-Output "The install file has been detected, would you like to install now? y/n"
    }
    
    $resp = Read-Host
    if ($resp -eq "y")
    {
        Write-Output "Installing Please wait..."
        Write-Output "This might take a while!"
        Write-Output "#########################"
        ./dotnet-install.ps1
    }
    else 
    {
        Start-Cleanup
        Exit-PSHostProcess
    }
}
dotnet build -c Release
Start-Cleanup
