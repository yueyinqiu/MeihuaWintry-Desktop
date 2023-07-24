using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MeihuaWintryDesktop.ViewModelling.Tools.CaseEditing.CaseCreator;

namespace MeihuaWintryDesktop.ViewModelling.Tools.CaseEditing.Scripting;
internal sealed class CaseCreationGlobals
{
    public CaseCreationGlobals(CaseCreationExtraInformation caseCreationExtraInformation, CaseCreationResult caseCreationResult)
    {
        this.CaseCreationExtraInformation = caseCreationExtraInformation;
        this.CaseCreationResult = caseCreationResult;
    }

    public CaseCreationResult CaseCreationResult { get; }
    public CaseCreationExtraInformation CaseCreationExtraInformation { get; }
}
