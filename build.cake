#tool nuget:?package=NUnit.ConsoleRunner&version=3.4.0
//////////////////////////////////////////////////////////////////////
// ARGUMENTS
//////////////////////////////////////////////////////////////////////

var target = Argument("target", "Default");
var configuration = Argument("configuration", "Release");

//////////////////////////////////////////////////////////////////////
// PREPARATION
//////////////////////////////////////////////////////////////////////

// Define directories.
var buildDir = Directory("./build/bin") + Directory(configuration);

//////////////////////////////////////////////////////////////////////
// TASKS
//////////////////////////////////////////////////////////////////////

Task("Clean")
    .Does(() => {
        CleanDirectory(buildDir);
});

Task("Restore-NuGet-Packages")
    .IsDependentOn("Clean")
    .Does(() => {
        NuGetRestore("./src/MVC.Courses.sln");
});

Task("Build")
    .IsDependentOn("Restore-NuGet-Packages")
    .Does(() => {
        // Use MSBuild
        MSBuild("./src/MVC.Courses.sln", settings =>
            settings.SetConfiguration(configuration)
            .SetVerbosity(Verbosity.Quiet));
});

Task("Run-Tests")
    .IsDependentOn("Build")
    .Does(() => {
        NUnit3("./src/**/bin/" + configuration + "/*.Test.Unit.dll", new NUnit3Settings {
            NoResults = false
            });

        if(IsRunningOnWindows()) {
            NUnit3("./src/**/bin/" + configuration + "/*.Test.Integration.dll", new NUnit3Settings {
                NoResults = false
                });
        }
});

//////////////////////////////////////////////////////////////////////
// TASK TARGETS
//////////////////////////////////////////////////////////////////////

Task("Default")
    .IsDependentOn("Run-Tests");

//////////////////////////////////////////////////////////////////////
// EXECUTION
//////////////////////////////////////////////////////////////////////

RunTarget(target);
