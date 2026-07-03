$ErrorActionPreference = 'Stop'
$root = Split-Path -Parent $PSScriptRoot
$sln = Join-Path $root 'GS1.sln'
$vswhere = Join-Path ${env:ProgramFiles(x86)} 'Microsoft Visual Studio\Installer\vswhere.exe'
if (-not (Test-Path $vswhere)) {
    Write-Error 'Khong tim thay vswhere. Cai Visual Studio 2022 hoac Build Tools for Visual Studio.'
}
$msb = & $vswhere -latest -requires Microsoft.Component.MSBuild -find 'MSBuild\**\Bin\MSBuild.exe' | Select-Object -First 1
if (-not $msb) { Write-Error 'Khong tim thay MSBuild.' }
& $msb $sln /p:Configuration=Debug /v:m
exit $LASTEXITCODE
