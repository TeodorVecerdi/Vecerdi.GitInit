namespace Vecerdi.GitInit;

internal static class GitInit {
    public static void Run(
        bool acceptDefaults, string? ignores, bool noIgnores, string? licenseType, bool noLicense,
        string? commitMessage, bool noCommit, bool dontAddAll, bool dryRun
    ) {
        CommandHelper.Run("git", "init", dry: dryRun);

        if (!noIgnores) {
            if ((ignores ??= acceptDefaults ? "rider,unity,dotnet" : PromptHelper.GetInput(".gitignore templates", "rider,unity,dotnet", "no .gitignore")) is not "-") {
                CommandHelper.Run("ignore", $"{ignores} --silent", dry: dryRun);
            }
        }

        if (!noLicense) {
            if ((licenseType ??= acceptDefaults ? "NON-AI-MIT" : PromptHelper.GetInput("license type", "NON-AI-MIT", "no license")) is not "-") {
                CommandHelper.Run("license", $"--silent --accept-placeholders --license=\"{licenseType}\"", dry: dryRun);
            }
        }

        if (!dontAddAll) {
            CommandHelper.Run("git", "add .", dry: dryRun);
        }

        if (!noCommit) {
            if ((commitMessage ??= acceptDefaults ? "Initial commit" : PromptHelper.GetInput("commit message", "Initial commit", "no commit")) is not "-") {
                CommandHelper.Run("git", $"commit -m \"{commitMessage}\"", dry: dryRun);
            }
        }
    }
}