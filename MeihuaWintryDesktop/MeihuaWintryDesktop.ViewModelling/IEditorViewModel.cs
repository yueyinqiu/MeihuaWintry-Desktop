using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MeihuaWintryDesktop.ViewModelling;
public interface IEditorViewModel
{
    bool IsNotSaved { get; }
    string Title { get; }
}
