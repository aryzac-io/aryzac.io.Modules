param (
    [string]$name,
    [string]$path,
    [string]$sourceDir = (Get-Location).Path,
    [string]$ttFileName = "T.tt",
    [string]$csFileName = "TPartial.cs"
)

# Resolve $sourceDir to an absolute path if a relative path is provided
$sourceDir = Resolve-Path $sourceDir

# Check if required parameters are provided
if (-not $name -or -not $path) {
    Write-Host "This script requires two parameters: -name and -path."
    Write-Host "Optional parameters: -sourceDir [default: current directory], -ttFileName [default: 'T.tt'], -csFileName [default: 'TPartial.cs']"
    Write-Host "Example: .\YourScriptName.ps1 -name 'YourNewName' -path 'Your/Path/Here' -sourceDir './Controls'"
    exit
}

# Determine the new directory based on the subfolder parameter
$newDir = Join-Path $sourceDir $path
if (-not (Test-Path $newDir)) {
    New-Item -ItemType Directory -Path $newDir
}

# New file names
$newTTFileName = "$name`.tt"
$newCSFileName = "$name`Partial.cs"

# Paths for new files
$newTTFilePath = Join-Path $newDir $newTTFileName
$newCSFilePath = Join-Path $newDir $newCSFileName

# Read and copy .tt file
$ttFileContent = Get-Content (Join-Path $sourceDir $ttFileName)
$ttFileContent | Set-Content $newTTFilePath

# Read, modify, and copy .cs file
$csFileContent = Get-Content (Join-Path $sourceDir $csFileName) -Raw
# Update the class and constructor names
$modifiedCSFileContent = $csFileContent -replace "partial class T", "partial class ${name}"
$modifiedCSFileContent = $modifiedCSFileContent -replace "public T", "public ${name}"

# Update the namespace to include subfolders (convert slashes to dots)
$subNamespace = $path -replace '/', '.'
$updatedNamespace = "namespace Aryzac.IO.Modules.Client.Templates.Files.Composables.Controls.$subNamespace"
$modifiedCSFileContent = $modifiedCSFileContent -replace "namespace\s+[a-zA-Z0-9_.]+", $updatedNamespace

$modifiedCSFileContent | Set-Content $newCSFilePath

Write-Host "Files created in subfolder ${path}: $newTTFileName, $newCSFileName`n"


# New Write-Host commands for easy copy-paste
$newFileNameCamelCase = $name.Substring(0,1).ToLower() + $name.Substring(1) # Convert to camelCase

Write-Host "Set the Custom Tool for the .tt file to: TextTemplatingFilePreprocessor`n"

Write-Host "In the $newCSFileName file, add the following lines:`n"

Write-Host "`tpublic $name $newFileNameCamelCase = new $name(model.InternalElement);"
Write-Host "`tpublic $name $newFileNameCamelCase;"
Write-Host "`tpublic string $name => $newFileNameCamelCase.TransformText();`n"

Write-Host "Remember to replace `$name` with the actual class name in your code snippets."

