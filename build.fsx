#r "paket: 
nuget FSharp.Core prerelease
nuget Fake.Core.Target prerelease
nuget Fake.IO.FileSystem prerelease
nuget Fake.DotNet.Cli prerelease
"

#load "./.fake/build.fsx/intellisense.fsx"

open System.IO
open Fake.Core
open Fake.IO.Globbing.Operators
open Fake.DotNet

// *** Define Targets ***
Target.create "Clean" (fun _ ->
  Trace.log " --- Cleaning stuff --- "

  let setDotNetOptions defaultDtNetOptions : DotNet.Options =
    defaultDtNetOptions

  DotNet.exec setDotNetOptions "clean" ""
  |> printfn "===============================================================\n%A\n"
)

Target.create "Build" (fun _ ->
  Trace.log " --- Building the app --- "

  let setBuildParams defaultBuildParamas = defaultBuildParamas
  DotNet.build setBuildParams ""
)

Target.create "Test" (fun _ ->
  Trace.log " --- Testing the app --- "

  let setDotNetOptions (projectDirectory:string) : (DotNet.Options-> DotNet.Options)=
    fun (dotNetOptions:DotNet.Options) -> { dotNetOptions with WorkingDirectory = projectDirectory}

  !!("test/**/*.Tests.csproj")
  |> Seq.toArray
  |> Array.Parallel.map Path.GetDirectoryName
  |> Array.Parallel.map (fun projectDirectory -> DotNet.exec (setDotNetOptions projectDirectory) "xunit" "")
  |> Array.Parallel.iter (fun cliResults -> printfn "===============================================================\n%A\n" cliResults)
)

Target.create "Publish" (fun _ ->
  Trace.log " --- Publishing app --- "
  let setPublishParams defaultPublishParams = defaultPublishParams
  DotNet.publish setPublishParams ""
)

Target.create "Deploy" (fun _ ->
  Trace.log " --- Deploying app --- "
)

open Fake.Core.TargetOperators

// *** Define Dependencies ***
"Clean"
  ==> "Build"
  ==> "Test"
  ==> "Publish"
  ==> "Deploy"


// *** Start Build ***
Target.runOrDefault "Deploy"