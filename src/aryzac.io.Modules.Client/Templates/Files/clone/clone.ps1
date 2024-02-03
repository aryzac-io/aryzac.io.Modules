param (
    [string]$name,
    [string]$path,
    [string]$sourceDir = (Split-Path (Get-Location).Path -Parent),
    [string]$template = "T", # Default template name
    [switch]$overwrite
)

# Resolve $sourceDir to an absolute path if a relative path is provided
$sourceDir = Resolve-Path $sourceDir

# Default paths for the template files relative to the script's location
$templateBaseName = $template
$templatePartialName = $templateBaseName + "Partial.cs"
$ttFileName = Join-Path (Get-Location).Path "$templateBaseName.tt"
$csFileName = Join-Path (Get-Location).Path "$templatePartialName"
$newDir = Join-Path $sourceDir $path

# Correcting the path to remove any extraneous characters
# Just an example; adjust according to your actual logic
$csFileName = $csFileName -replace '\+\\', ''

# Create new directory if it doesn't exist
if (-not (Test-Path $newDir)) {
    New-Item -ItemType Directory -Path $newDir
}

# Construct new file names
$newTTFileName = "$name.tt"
$newCSFileName = "$name" + "Partial.cs"
$newTTFilePath = Join-Path $newDir $newTTFileName
$newCSFilePath = Join-Path $newDir $newCSFileName

# Function to extract placeholders from content
function Get-Placeholders {
    param (
        [string]$content
    )
    
    $pattern = '\$\{(\w+)\}'
    $matches = [regex]::Matches($content, $pattern)
    $placeholders = @{}
    foreach ($match in $matches) {
        $key = $match.Groups[1].Value
        $placeholders[$key] = $null
    }
    return $placeholders.Keys
}

# Function to replace placeholders in content
function Replace-Placeholders {
    param (
        [string]$content,
        [hashtable]$replacements
    )

    foreach ($key in $replacements.Keys) {
        # Escape special regex characters in key
        $escapedKey = [regex]::Escape("`${$key}")
        # Replace the placeholder with the value from the replacements hashtable
        $content = $content -replace $escapedKey, $replacements[$key]
    }

    return $content
}

# Check if required parameters are provided
if (-not $name -or -not $path) {
    Write-Host "This script requires two parameters: -name and -path."
    Write-Host "Optional parameters: -sourceDir [default: current directory], -template [default: 'T'], -overwrite"
    Write-Host "Example: .\YourScriptName.ps1 -name 'YourNewName' -path 'Your/Path/Here' -sourceDir './Controls' -template 'CustomTemplate' -overwrite"
    exit
}

# Check if files exist and handle overwrite logic
$ttFileExists = Test-Path $newTTFilePath
$csFileExists = Test-Path $newCSFilePath

if ($ttFileExists -or $csFileExists) {
    if (-not $overwrite) {
        $userChoice = Read-Host "Files already exist. Overwrite? (Y/n)"
        if (-not $userChoice -or $userChoice -eq 'Y') {
            Write-Host "Overwriting files."
        } else {
            Write-Host "Exiting without overwriting files."
            exit
        }
    }
}

# Process template files
$templateFiles = @($ttFileName, $csFileName)
foreach ($file in $templateFiles) {

    $content = Get-Content $file -Raw

    # Extract placeholders
    $placeholders = Get-Placeholders -content $content

    # Initialize replacements hashtable
    $replacements = @{}

    # Adjust the logic to match placeholders with PSBoundParameters
    foreach ($placeholder in $placeholders) {
        # Check if a corresponding parameter was passed
        $paramName = "-" + $placeholder  # Add '-' prefix to match PSBoundParameters' keys
        $matchedParam = $PSBoundParameters.GetEnumerator() | Where-Object { $_.Key -eq $paramName.TrimStart('-') }

        if ($matchedParam) {
            # If a matching parameter is found, use its value for replacement
            $replacements[$placeholder] = $matchedParam.Value
        }
    }

    $content = Replace-Placeholders -content $content -replacements $replacements
    
    # Correctly construct $newFilePath
    $fileName = [System.IO.Path]::GetFileName($file) # Isolate the file name
    $newFileName = $fileName.Replace($templateBaseName, $name) # Replace template base name with the specified name
    $newFilePath = Join-Path $newDir $newFileName # Join the new directory path with the new file name
    
    $content | Set-Content $newFilePath
}


Write-Host "Files created in subfolder ${path}: $newTTFileName, $newCSFileName`n"

# Additional Write-Host commands for easy copy-paste, adapted from the first script
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
Write-Host "`tpublic string GenerateHeading(IElement element)"
Write-Host "`t{"
Write-Host "`t  var heading = new Heading(element);"
Write-Host "`t  return heading.TransformText();"
Write-Host "`t}`n"

Write-Host "Remember to replace `$name` with the actual class name in your code snippets."
Write-Host "Template processing complete. Files generated at $newDir"
