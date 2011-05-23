@echo off
echo Rebuilding!!!!

"C:\Program Files (x86)\Microsoft Visual Studio 10.0\Common7\IDE\devenv" /rebuild debug "Pojjaman.sln" | find "Rebuild All"

pause
