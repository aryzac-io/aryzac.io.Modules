param (
    [string]$name,
    [string]$path,
    [string]$sourceDir = (Split-Path (Get-Location).Path -Parent),
    [string]$ttFileName = (Join-Path (Get-Location).Path "T.tt"),
    [string]$csFileName = (Join-Path (Get-Location).Path "TPartial.cs"),
    [switch]$overwrite
)

# Resolve $sourceDir to an absolute path if a relative path is provided
$sourceDir = Resolve-Path $sourceDir

# Check if required parameters are provided
if (-not $name -or -not $path) {
    Write-Host "This script requires two parameters: -name and -path."
    Write-Host "Optional parameters: -sourceDir [default: current directory], -ttFileName [default: 'T.tt'], -csFileName [default: 'TPartial.cs'], -overwrite"
    Write-Host "Example: .\YourScriptName.ps1 -name 'YourNewName' -path 'Your/Path/Here' -sourceDir './Controls' -overwrite"
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

# Check if files exist and handle overwrite logic
$ttFileExists = Test-Path $newTTFilePath
$csFileExists = Test-Path $newCSFilePath

if ($ttFileExists -or $csFileExists) {
    if (-not $overwrite) {
        $userChoice = Read-Host "Files already exist. Overwrite? (Y/n)"
        # Check if userChoice is 'Y' or empty (default to 'Y' if Enter is pressed)
        if (-not $userChoice -or $userChoice -eq 'Y') {
            Write-Host "Overwriting files."
        } else {
            Write-Host "Exiting without overwriting files."
            exit
        }
    }
}

# Directly read and copy .tt file without using $sourceDir
$ttFileContent = Get-Content $ttFileName
$ttFileContent | Set-Content $newTTFilePath

# Directly read and modify .cs file without using $sourceDir
$csFileContent = Get-Content $csFileName -Raw
# Update the class and constructor names
$modifiedCSFileContent = $csFileContent -replace "partial class T", "partial class ${name}"
$modifiedCSFileContent = $modifiedCSFileContent -replace "public T", "public ${name}"
$modifiedCSFileContent | Set-Content $newCSFilePath

# Assuming $path might start with "./" or ".\" for relative paths
# Clean up relative path indicators and replace slashes with dots
$path = $path -replace '^\./|^\.\\', '' -replace '[/\\]', '.'

# Split the path by dots to process each segment
$subNamespaceParts = $path -split '\.' | Where-Object { $_ }

# Initialize an empty array to hold the PascalCase segments
$pascalCaseNamespaceParts = @()

# Loop through each part of the namespace, capitalizing the first letter
foreach ($part in $subNamespaceParts) {
    if (-not [string]::IsNullOrWhiteSpace($part)) {
        $capitalizedPart = $part.Substring(0,1).ToUpper() + $part.Substring(1)
        $pascalCaseNamespaceParts += $capitalizedPart
    }
}

# Join the parts back into a namespace
$subNamespace = [string]::Join(".", $pascalCaseNamespaceParts)

if (-not $subNamespace) {
    Write-Host "No valid namespace parts were generated from the path."
    exit
}

Write-Host "Generated namespace: $subNamespace"

# Now $subNamespace should be correctly formatted without leading or trailing dots
$updatedNamespace = "namespace Aryzac.IO.Modules.Client.Templates.Files.$subNamespace"

$modifiedCSFileContent = $modifiedCSFileContent -replace "namespace\s+[a-zA-Z0-9_.]+", $updatedNamespace

$modifiedCSFileContent | Set-Content $newCSFilePath

Write-Host "Files created in subfolder ${path}: $newTTFileName, $newCSFileName`n"


# New Write-Host commands for easy copy-paste
$newFileNameCamelCase = $name.Substring(0,1).ToLower() + $name.Substring(1) # Convert to camelCase

Write-Host "Set the Custom Tool for the .tt file to:"
Write-Host "`tTextTemplatingFilePreprocessor`n"

Write-Host "In the $newCSFileName file, add the following lines:`n"

Write-Host "Constructor"
Write-Host "`t$newFileNameCamelCase = new $name(model.InternalElement);"

Write-Host "Field and Property"
Write-Host "`tprivate $name $newFileNameCamelCase;"
Write-Host "`tpublic string $name => $newFileNameCamelCase.TransformText();`n"

Write-Host "Method"
Write-Host "`tpublic string Generate$name(IElement element)"
Write-Host "`t{"
Write-Host "`t  var template = new $name(element);"
Write-Host "`t  return template.TransformText();"
Write-Host "`t}`n"

Write-Host "Remember to replace `$name` with the actual class name in your code snippets."

