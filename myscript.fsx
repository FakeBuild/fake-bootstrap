(* -- Fake Dependencies paket-inline
storage: none
source https://api.nuget.org/v3/index.json

nuget Fake.Core.Target prerelease
-- Fake Dependencies -- *)
#load "./.fake/myscript.fsx/intellisense.fsx"

open Fake.Core

// *** Define Targets ***
Target.Create "Clean" (fun _ ->
  Trace.log " --- Cleaning stuff --- "
)

Target.Create "Build" (fun _ ->
  Trace.log " --- Building the app --- "
)

Target.Create "Deploy" (fun _ ->
  Trace.log " --- Deploying app --- "
)

open Fake.Core.TargetOperators

// *** Define Dependencies ***
"Clean"
  ==> "Build"
  ==> "Deploy"

// *** Start Build ***
Target.RunOrDefault "Deploy"