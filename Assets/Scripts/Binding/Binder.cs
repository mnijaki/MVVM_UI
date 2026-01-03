using System.ComponentModel;
using UnityEngine;

namespace Binding
{
    /// <summary>
    /// Base class for components that bind UI elements to <see cref="IBindable"/> data sources.
    /// </summary>
    public abstract class Binder : MonoBehaviour
    {
        /// <summary>
        /// Gets or sets the bindable data source for this binder.
        /// </summary>
        public IBindable Bindable
        {
            get => m_bindable;
            set
            {
                if (ReferenceEquals(m_bindable, value))
                    return;

                EnsureBindableUnregistered();
                m_bindable = value;
                EnsureBindableRegistered();

                RefreshBindings();
            }
        }

        private IBindable m_bindable;
        
        /// <summary>
        /// When overridden in a derived class, updates the UI elements to reflect the current state of the <see cref="Bindable"/>.
        /// </summary>
        protected abstract void RefreshBindings();
        
        /// <summary>
        /// Called when the component is enabled. Registers property change notifications.
        /// </summary>
        protected virtual void OnEnable() =>
            EnsureBindableRegistered();

        /// <summary>
        /// Called when the component is disabled. Unregisters property change notifications.
        /// </summary>
        protected virtual void OnDisable() =>
            EnsureBindableUnregistered();
        
        private void EnsureBindableRegistered()
        {
            if (enabled && m_bindable != null)
                m_bindable.PropertyChanged += OnBindablePropertyChanged;
        }
        
        private void EnsureBindableUnregistered()
        {
            if (m_bindable != null)
                m_bindable.PropertyChanged -= OnBindablePropertyChanged;
        }

        private void OnBindablePropertyChanged(object _, PropertyChangedEventArgs __) =>
            RefreshBindings();
    }
}
