using MeihuaWintryDesktop.Storaging.CaseStoraging;
using MeihuaWintryDesktop.Storaging.CaseStoraging.Cases;
using MeihuaWintryDesktop.Storaging.CaseStoraging.Diviners;
using MeihuaWintryDesktop.ViewModelling.Tools.CaseEditing.Scripting;

namespace MeihuaWintryDesktop.ViewModelling.Tools.CaseEditing;
internal sealed partial class CaseCreator
{
    private readonly CaseStore store;
    public CaseCreator(CaseStore store)
    {
        this.store = store;
    }

    public async ValueTask<IStoredCase> CreateAsync(string title,
        string owner, TheThreeTimes time, string script,
        CancellationToken cancellationToken = default)
    {
        var globals = new CaseCreationGlobals(
            caseCreationExtraInformation: new(this.store, script),
            caseCreationResult: new(title, owner, "", time, new(), new(), "", new()));
        var runner = new ScriptRunner<CaseCreationGlobals>(globals);
        var diviner = this.store.Diviners.Diviner;
        await runner.ContinueAsync(diviner.PreScript, cancellationToken);
        await runner.ContinueAsync(script, cancellationToken);
        await runner.ContinueAsync(diviner.PostScript, cancellationToken);
        return globals.CaseCreationResult;
    }

    public async ValueTask<IStoredCaseWithId> CreateAndInsertAsync(string title,
        string owner, TheThreeTimes time, string script,
        CancellationToken cancellationToken = default)
    {
        var c = await this.CreateAndInsertAsync(title, owner, time, script, cancellationToken);
        return this.store.Cases.InsertCase(c);
    }
}
