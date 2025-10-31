@echo off
chcp 65001 >nul
echo ═══════════════════════════════════════════════════════════
echo    FM26 Patcher - .exe Oluşturuluyor...
echo ═══════════════════════════════════════════════════════════
echo.

REM Temizlik
if exist bin rmdir /s /q bin
if exist obj rmdir /s /q obj
if exist publish rmdir /s /q publish

echo [1/3] Proje temizleniyor...
dotnet clean FM26Patcher.csproj --configuration Release >nul 2>&1

echo [2/3] Proje derleniyor...
dotnet build FM26Patcher.csproj --configuration Release

echo [3/3] Tek dosya .exe oluşturuluyor...
dotnet publish FM26Patcher.csproj --configuration Release --output publish --self-contained true -p:PublishSingleFile=true -p:IncludeNativeLibrariesForSelfExtract=true -p:PublishTrimmed=false

echo.
echo ═══════════════════════════════════════════════════════════
echo    ✓ .exe dosyası oluşturuldu!
echo ═══════════════════════════════════════════════════════════
echo.
echo 📁 Konum: publish\FM26Patcher.exe
echo 📦 Dosya boyutu kontrol ediliyor...

if exist publish\FM26Patcher.exe (
    for %%A in (publish\FM26Patcher.exe) do (
        set size=%%~zA
        set /a sizeMB=%%~zA/1024/1024
    )
    echo    Boyut: !sizeMB! MB
    echo.
    echo ✓ Program hazır! Artık publish\FM26Patcher.exe dosyasını
    echo   herhangi bir Windows bilgisayarda çalıştırabilirsiniz.
    echo.
    echo ⚠ NOT: .NET Runtime yüklü olmayan PC'lerde de çalışır!
) else (
    echo.
    echo ✗ HATA: .exe dosyası oluşturulamadı!
    echo   .NET 6.0 SDK yüklü olduğundan emin olun:
    echo   https://dotnet.microsoft.com/download/dotnet/6.0
)

echo.
pause


