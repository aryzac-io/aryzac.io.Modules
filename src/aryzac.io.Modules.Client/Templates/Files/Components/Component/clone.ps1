param (
    [string]$newName,
    [string]$subFolder
)

# Define the source directory and file names
$sourceDir = "D:\src\aryzac-io\aryzac.io.Modules\src\aryzac.io.Modules.Client\Templates\Files\Components\Component"
$ttFileName = "T.tt"
$csFileName = "TPartial.cs"

# Determine the new directory based on the subfolder parameter
$newDir = Join-Path $sourceDir $subFolder
if (-not (Test-Path $newDir)) {
    New-Item -ItemType Directory -Path $newDir
}

# New file names
$newTTFileName = "$newName`Template.tt"
$newCSFileName = "$newName`TemplatePartial.cs"

# Paths for new files
$newTTFilePath = Join-Path $newDir $newTTFileName
$newCSFilePath = Join-Path $newDir $newCSFileName

# Read and copy .tt file
$ttFileContent = Get-Content (Join-Path $sourceDir $ttFileName)
$ttFileContent | Set-Content $newTTFilePath

# Read, modify, and copy .cs file
$csFileContent = Get-Content (Join-Path $sourceDir $csFileName) -Raw
# Update the class and constructor names
$modifiedCSFileContent = $csFileContent -replace "partial class Template", "partial class ${newName}Template"
$modifiedCSFileContent = $modifiedCSFileContent -replace "public Template", "public ${newName}Template"
# Update the namespace
$namespacePattern = "namespace\s+[a-zA-Z0-9_.]+"
$updatedNamespace = "namespace Aryzac.IO.Modules.Client.Templates.Files.Components.Component.$subFolder"
$modifiedCSFileContent = $modifiedCSFileContent -replace $namespacePattern, $updatedNamespace
$modifiedCSFileContent | Set-Content $newCSFilePath

Write-Host "Files created in subfolder $subFolder: $newTTFileName, $newCSFileName"
