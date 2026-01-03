using System.ComponentModel;

namespace Binding
{
    /// <summary>
    /// Represents a bindable entity that can notify when its properties change.
    /// </summary>
    public interface IBindable : INotifyPropertyChanged
    {
    }
}