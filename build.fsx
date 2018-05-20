#r "paket: 
nuget FSharp.Core prerelease
nuget Fake.Core.Target prerelease
nuget Fake.IO.FileSystem prerelease
nuget Fake.DotNet.Cli prerelease
"

#load "./.fake/build.fsx/intellisense.fsx"

open System.IO
open Fake.Core
open Fake.Core.TargetOperators
open Fake.IO.Globbing.Operators
open Fake.DotNet

// *** Define Targets ***
Target.create "Clean" (fun _ ->
  Trace.log " --- Cleaning stuff --- "
  DotNet.exec id "clean" ""
  |> ignore
)

Target.create "Build" (fun _ ->
  Trace.log " --- Building the app --- "
  DotNet.build id ""
)

Target.create "Test" (fun _ ->
  Trace.log " --- Testing the app --- "

  let setDotNetOptions (projectDirectory:string) : (DotNet.Options-> DotNet.Options)=
    fun (dotNetOptions:DotNet.Options) -> { dotNetOptions with WorkingDirectory = projectDirectory}

  //I could not find a way to run XUnit2 helper without having to specify "assemblies"
  !!("test/**/*.Tests.csproj")
  |> Seq.toArray
  |> Array.Parallel.map Path.GetDirectoryName
  |> Array.Parallel.map (fun projectDirectory -> DotNet.exec (setDotNetOptions projectDirectory) "xunit" "")
  |> ignore
)

Target.create "Publish" (fun _ ->
  Trace.log " --- Publishing app --- "
  DotNet.publish id ""
)

Target.create "Deploy" (fun _ ->
  Trace.log " --- Deploying app --- "
)


// *** Define Dependencies ***
"Clean"
  ==> "Build"
  ==> "Test"
  ==> "Publish"
  ==> "Deploy"


// *** Start Build ***
Target.runOrDefault "Deploy"