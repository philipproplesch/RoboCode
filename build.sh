#!/bin/bash

mono --runtime=v4.0 tls/NuGet/nuget.exe install FAKE -OutputDirectory tls -ExcludeVersion
mono --runtime=v4.0 tls/FAKE/tools/FAKE.exe build.fsx $@