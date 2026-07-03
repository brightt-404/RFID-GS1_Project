$ErrorActionPreference = 'Stop'
$root = Split-Path -Parent $PSScriptRoot
$build = Join-Path $PSScriptRoot 'Build-GS1.ps1'
& $build
if ($LASTEXITCODE -ne 0) { exit $LASTEXITCODE }
$exe = Join-Path $root 'GS1\bin\Debug\GS1.exe'
if (-not (Test-Path $exe)) {
    Write-Error "Khong tim thay: $exe. Hay build truoc."
}
$dir = Split-Path $exe
Start-Process -FilePath $exe -WorkingDirectory $dir
