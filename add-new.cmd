@echo off
setlocal enabledelayedexpansion
set num=%1

for /L %%x in (1,1,10) do ( if "!num:~%%x!"=="" (set /A len=%%x) &  goto Result )

:Result 

IF "%len%"=="0" (
    echo Project number wrong or missed
    goto Finish )
IF "%len%"=="1" (
    set "project=Problem.000%1" )
IF "%len%"=="2" (
    set "project=Problem.00%1" )
IF "%len%"=="3" (
    set "project=Problem.0%1" )
IF "%len%"=="4" (
    set "project=Problem.%num%" )

echo on
dotnet new console -n %project%
dotnet sln add %project%/%project%.csproj
@echo off

:Finish
