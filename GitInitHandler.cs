using System.CommandLine.Invocation;

namespace Vecerdi.GitInit;

internal class GitInitHandler : ICommandHandler {
    private readonly Action<InvocationContext> m_Invoke;

    public GitInitHandler(Action<InvocationContext> invoke) {
        this.m_Invoke = invoke;
    }

    /// <summary>
    /// Performs an action when the associated command is invoked on the command line.
    /// </summary>
    /// <param name="context">Provides context for the invocation, including parse results and binding support.</param>
    /// <returns>A value that can be used as the exit code for the process.</returns>
    public int Invoke(InvocationContext context) {
        this.m_Invoke(context);
        return 0;
    }

    /// <summary>
    /// Performs an action when the associated command is invoked on the command line.
    /// </summary>
    /// <param name="context">Provides context for the invocation, including parse results and binding support.</param>
    /// <returns>A value that can be used as the exit code for the process.</returns>
    public Task<int> InvokeAsync(InvocationContext context) {
        this.m_Invoke(context);
        return Task.FromResult(0);
    }
}