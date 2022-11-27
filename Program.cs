using System.CommandLine;
using Vecerdi.GitInit;

RootCommand rootCommand = new() {
    Name = "gitinit",
    Description = "Initialize a git repository",
};

Option<bool> acceptDefaultsOption = new(new[] { "--accept-defaults", "-a" }, "Accept all defaults");

Option<string> licenseTypeOption = new(new[] { "--license", "-l" }, "License type (SPDX identifier)");
Option<bool> noLicenseOption = new(new[] { "--no-license", "-L" }, "Do not create a LICENSE file");

Option<string> ignoresOption = new(new[] { "--ignores", "-i" }, "Comma-separated list of ignores to add to .gitignore");
Option<bool> noIgnoresOption = new(new[] { "--no-gitignore", "-I" }, "Do not create a .gitignore file");

Option<string> commitMessageOption = new(new[] { "--commit-message", "-m" }, "Commit message");
Option<bool> noCommitOption = new(new[] { "--no-commit", "-M" }, "Do not commit the initial commit");

Option<bool> dontAddAllOption = new(new[] { "--dont-add-all", "-A" }, "Do not add all files to the initial commit");

Option<bool> dryRunOption = new(new[] { "--dry-run", "-d" }, "Do not actually run any commands");

rootCommand.AddOption(acceptDefaultsOption);
rootCommand.AddOption(ignoresOption);
rootCommand.AddOption(noIgnoresOption);
rootCommand.AddOption(licenseTypeOption);
rootCommand.AddOption(noLicenseOption);
rootCommand.AddOption(commitMessageOption);
rootCommand.AddOption(noCommitOption);
rootCommand.AddOption(dontAddAllOption);
rootCommand.AddOption(dryRunOption);

rootCommand.Handler = new GitInitHandler(context => {
    bool acceptDefaults = context.ParseResult.GetValueForOption(acceptDefaultsOption);
    string? ignores = context.ParseResult.GetValueForOption(ignoresOption);
    bool noIgnores = context.ParseResult.GetValueForOption(noIgnoresOption);
    string? licenseType = context.ParseResult.GetValueForOption(licenseTypeOption);
    bool noLicense = context.ParseResult.GetValueForOption(noLicenseOption);
    string? commitMessage = context.ParseResult.GetValueForOption(commitMessageOption);
    bool noCommit = context.ParseResult.GetValueForOption(noCommitOption);
    bool dontAddAll = context.ParseResult.GetValueForOption(dontAddAllOption);
    bool dryRun = context.ParseResult.GetValueForOption(dryRunOption);

    GitInit.Run(acceptDefaults, ignores, noIgnores, licenseType, noLicense, commitMessage, noCommit, dontAddAll, dryRun);
});

return await rootCommand.InvokeAsync(args);