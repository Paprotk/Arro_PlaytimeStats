@echo off
setlocal enabledelayedexpansion

rem Pobierz katalog bieżący, gdzie znajduje się plik konwertuj.bat
set "folder=%~dp0"

rem Przejdź do folderu
pushd "%folder%"

rem Przekonwertuj każdy plik .txt w folderze
for %%f in (*.txt) do (
    echo Converted: %%f
    "STBLize.exe" "%%f"
)

popd
pause
