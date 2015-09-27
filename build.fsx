#r "packages/fake/tools/fakelib.dll"
open Fake

let buildDir = "build"
let deployDir = "deploy"
let solutionFile = Include "./*.sln"

Target "Clean" (fun _ -> 
    CleanDirs ["./build/"; "./deploy/"]
)

Target "Build" (fun _ ->
    MSBuildRelease buildDir "Build" ["Dispatcher\Dispatcher.csproj"; "Worker\Worker.csproj"] |> ignore
)

"Clean"
    ==> "Build"

RunTargetOrDefault "Build"