#!/bin/bash

mono --runtime=v4.0 .nuget\NuGet.exe install FAKE -OutputDirectory packages -ExcludeVersion
mono --runtime=v4.0 tools/FAKE/tools/FAKE.exe build.fsx