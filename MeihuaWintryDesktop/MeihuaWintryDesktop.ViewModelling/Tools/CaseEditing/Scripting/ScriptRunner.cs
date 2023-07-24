using Microsoft.CodeAnalysis.CSharp.Scripting;
using Microsoft.CodeAnalysis.Scripting;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeihuaWintryDesktop.ViewModelling.Tools.CaseEditing.Scripting;
public sealed class ScriptRunner<TGlobals>
{
    private ScriptState? state;

    public TGlobals Globals { get; }
    public ScriptRunner(TGlobals globals)
    {
        this.Globals = globals;
    }

    public async ValueTask ContinueAsync(
        string script, CancellationToken cancellationToken = default)
    {
        try
        {
            if (this.state is null)
            {
                this.state = await CSharpScript.RunAsync(
                    script,
                    globals: this.Globals,
                    cancellationToken: cancellationToken);
            }
            else
            {
                this.state = await this.state.ContinueWithAsync(
                    script,
                    cancellationToken: cancellationToken);
            }
        }
        catch(Exception ex)
        {
            throw new ScriptFailedException(ex);
        }
    }
}
