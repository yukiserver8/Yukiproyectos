# Script para convertir imagenes PNG a BMP para Inno Setup
# Ejecutar con: powershell -ExecutionPolicy Bypass .\convertir_imagenes.ps1

Add-Type -AssemblyName System.Drawing

$srcDir = "C:\Source 97k+99b\imagenesmuyuki"
$dstDir = "C:\Source 97k+99b\InstallerYukiMu\images"

# Banner lateral (WizardImageFile) - tamano recomendado: 164x314
$bannerSrc = Join-Path $srcDir "muyukishadowelemental.png"
$bannerDst = Join-Path $dstDir "banner.bmp"
if (Test-Path $bannerSrc) {
    $img = [System.Drawing.Image]::FromFile($bannerSrc)
    $bmp = New-Object System.Drawing.Bitmap(164, 314)
    $g = [System.Drawing.Graphics]::FromImage($bmp)
    $g.InterpolationMode = [System.Drawing.Drawing2D.InterpolationMode]::HighQualityBicubic
    $g.DrawImage($img, 0, 0, 164, 314)
    $g.Dispose()
    $bmp.Save($bannerDst, [System.Drawing.Imaging.ImageFormat]::Bmp)
    $bmp.Dispose()
    $img.Dispose()
    Write-Host "OK - Banner creado: $bannerDst"
} else {
    Write-Host "WARN - No se encontro $bannerSrc, se usara el default de Inno Setup"
}

# Logo superior (WizardSmallImageFile) - tamano recomendado: 55x55
$logoSrc = Join-Path $srcDir "muyukifairy.png"
$logoDst = Join-Path $dstDir "logo.bmp"
if (Test-Path $logoSrc) {
    $img = [System.Drawing.Image]::FromFile($logoSrc)
    $bmp = New-Object System.Drawing.Bitmap(55, 55)
    $g = [System.Drawing.Graphics]::FromImage($bmp)
    $g.InterpolationMode = [System.Drawing.Drawing2D.InterpolationMode]::HighQualityBicubic
    $g.DrawImage($img, 0, 0, 55, 55)
    $g.Dispose()
    $bmp.Save($logoDst, [System.Drawing.Imaging.ImageFormat]::Bmp)
    $bmp.Dispose()
    $img.Dispose()
    Write-Host "OK - Logo creado: $logoDst"
} else {
    Write-Host "WARN - No se encontro $logoSrc"
}

# Copiar icono
$iconSrc = Join-Path $srcDir "iconomuyuki.ico"
$iconDst = Join-Path $dstDir "iconomuyuki.ico"
if (Test-Path $iconSrc) {
    Copy-Item $iconSrc $iconDst -Force
    Write-Host "OK - Icono copiado: $iconDst"
} else {
    Write-Host "WARN - No se encontro $iconSrc"
}

Write-Host "`nImagenes listas en: $dstDir"
