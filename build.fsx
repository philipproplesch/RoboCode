#r "packages/FAKE/tools/FakeLib.dll"
open Fake

// Properties
let buildDir = "./out/"

// Targets
Target "Clean" (fun _ ->
  CleanDir buildDir
)

Target "Compile" (fun _ ->
  !! "*.sln"
    |> MSBuildRelease buildDir "Build"
    |> Log "Build output: "
)

// Dependencies
"Clean"
  ==> "Compile"

// start build
RunTargetOrDefault "Compile"