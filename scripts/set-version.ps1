$token = $env:appveyor_api_token #should be defined as a secure variable
$branch = $env:APPVEYOR_REPO_BRANCH

$headers = @{ 
    "Authorization" = "Bearer $token"
    "Content-type" = "application/json"
}
$apiURL = "https://ci.appveyor.com/api/projects/$env:APPVEYOR_ACCOUNT_NAME/$env:APPVEYOR_PROJECT_SLUG"
$history = Invoke-RestMethod -Uri "$apiURL/history?recordsNumber=2&branch=$branch" -Headers $headers  -Method Get

[int]$version = (Get-Content .\version)
[int]$major = $version.Substring(0, $version.IndexOf("."))
[int]$minor = $version.Substring($version.IndexOf(".") + 1)

# skip scheduled build with same commit id as previous build
if ($history.builds.Count -eq 2)
{
    $resetBuild = $false
    
    $previousVersion = $history.builds[1].version
    [int]$previousMajor = $previousVersion.Substring(0, $previousVersion.IndexOf("."))
    [int]$previousMinor = $previousVersion.Substring($previousVersion.IndexOf(".") + 1, $previousVersion.LastIndexOf(".") - ($previousVersion.IndexOf(".") + 1))
    [int]$previousPatch = $previousVersion.Substring($previousVersion.LastIndexOf(".") + 1)
    
    Write-Host "Previous version: $previousVersion"
    Write-Host "Previous major version: $previousMajor"
    Write-Host "Previous minor version: $previousMinor"
    Write-Host "Current version specified: $version"
    if ($previousMajor -ne $major)
    {
        if ($major -ne $previousMajor + 1)
        {
            throw "Major version identity $major can only be incremented by one in regards to previous major $previousMajor"
        }
        
        if ($minor -ne 0)
        {
            throw "Minor version has to be set to 0 when incrementing major version"
        }
        
        $resetBuild = $true        
        Write-Warning "Major version has been changed, resetting build number and version format"
    }
    if ($previousMinor -ne $minor)
    {
        if ($minor -ne $previousMinor + 1)
        {
            throw "Minor version identity $minor can only be incremented by one in regards to previous minor $previousMinor"
        }
        
        Write-Warning "Minor version has been changed, resetting build number and version format"
        $resetBuild = $true
    }
    
    $versionFormat="$version.{build}"
    if ($branch -ne "master"){
        $versionFormat+="-rc"
    }
    Write-Warning "Updating build version format to $versionFormat. Please ensure that it is not set in YAML"
    
    $s = Invoke-RestMethod -Uri "https://ci.appveyor.com/api/projects/$env:APPVEYOR_ACCOUNT_NAME/$env:APPVEYOR_PROJECT_SLUG/settings" -Headers $headers  -Method Get
    $s.settings.versionFormat = $versionFormat
    
    if ($resetBuild)
    {
        #reset current build number to 0 and next one to 1
        $s.settings.nextBuildNumber = "1"
        $env:APPVEYOR_BUILD_NUMBER = "0"
        Update-AppveyorBuild -Version "$version.$env:APPVEYOR_BUILD_NUMBER"
    }

    Invoke-RestMethod -Uri 'https://ci.appveyor.com/api/projects' -Headers $headers  -Body ($s.settings | ConvertTo-Json -Depth 10) -Method Put    
}