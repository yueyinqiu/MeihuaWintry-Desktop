using MeihuaWintryDesktop.Storaging.CaseStoraging;
using MeihuaWintryDesktop.Storaging.CaseStoraging.Cases;
using MeihuaWintryDesktop.Storaging.CaseStoraging.Diviners;
using MeihuaWintryDesktop.ViewModelling.Tools.CaseEditing.Scripting;

namespace MeihuaWintryDesktop.ViewModelling.Tools.CaseEditing;
internal sealed partial class CaseCreator
{
    private readonly CaseStore store;
    private readonly IStoredDiviner diviner;
    public CaseCreator(CaseStore store)
    {
        this.store = store;
        this.diviner = store.Diviners.Diviner;
    }

    public string DefaultScript => diviner.DefaultScript;

    public async ValueTask<IStoredCase> CreateAsync(string title,
        string owner, DateTime? time, string script,
        CancellationToken cancellationToken = default)
    {
        var ownerDescription = store.Cases.CreateQuery()
            .FilterByOwner(owner)
            .OrderByLastEdit(true)
            .Limit(1)
            .Query()
            .Select(x => x.OwnerDescription)
            .FirstOrDefault(defaultValue: "");

        var globals = new CaseCreationGlobals(
            caseCreationExtraInformation: new(this.store, script),
            caseCreationResult: new(title, owner, ownerDescription, time, new(), new(), "", new()));
        var runner = new ScriptRunner<CaseCreationGlobals>(globals);
        await runner.ContinueAsync(this.diviner.PreScript, cancellationToken);
        await runner.ContinueAsync(script, cancellationToken);
        await runner.ContinueAsync(this.diviner.PostScript, cancellationToken);
        return globals.CaseCreationResult;
    }
}
