namespace Vecerdi.GitInit;

internal static class PromptHelper {
    public static string GetInput(string prompt, string defaults, string noneMessage = "none") {
        Console.Write($"> Enter {prompt} (default: {defaults}, '-' for {noneMessage}): ");
        string? input = Console.ReadLine()?.Trim();

        return string.IsNullOrWhiteSpace(input) ? defaults : input;
    }
}