@echo off

cls

"tls\NuGet\nuget.exe" "Install" "FAKE" "-OutputDirectory" "tls" "-ExcludeVersion"
"tls\FAKE\tools\Fake.exe" build.fsx

pause