namespace datNET.Fake.Config

#r @"./packages/FAKE/tools/FakeLib.dll"

open Fake
open Fake.EnvironmentHelper
open System.IO

module Common =
  let RootDir = Directory.GetCurrentDirectory()

module Source =
  open Common

  let SolutionFile = !! (Path.Combine(RootDir, "*.sln"))

module Build =
  let TestAssemblies = !! "tests/**/*.Tests.dll" -- "**/obj/**/*.Tests.dll"
  let DotNetVersion = "4.5"
  let MSBuildArtifacts = !! "src/**/bin/**.*" ++ "src/**/obj/**/*.*"

module Nuget =
  let ApiEnvVar = "DAT_NET_NUGET_API_KEY"
  let ApiKey = environVar ApiEnvVar
  let PackageDirName = "nupkgs"

module Release =
  let Items = !! "**/bin/Release/FSharpFilePathUtils.dll"
  let Nuspec = "FSharpFilepathUtils.nuspec"

  let Project = "FSharp.FilePath.Utils"
  let Authors = [ "Andrew Seward"; "Mathew Glodack" ]
  let Description = "Filepath manipulation utilities"
  let WorkingDir = "bin"
  let OutputPath = WorkingDir
