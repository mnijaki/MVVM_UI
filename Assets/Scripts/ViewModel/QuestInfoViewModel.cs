using System;
using Binding;
using CommunityToolkit.Mvvm.ComponentModel;
using Model;

namespace ViewModel
{
    /// <summary>
    /// View model for a quest info.
    /// </summary>
    public sealed partial class QuestInfoViewModel : ObservableObject, IBindable
    {
        [ObservableProperty]
        private bool m_isSelected;

        public readonly QuestViewModel QuestViewModel;

        public QuestInfoViewModel(Quest quest)
        {
            if (quest == null)
                throw new ArgumentNullException(nameof(quest));

            QuestViewModel = new QuestViewModel(quest, false);
        }
        
        public void ToggleSelection()
        {
            IsSelected = !IsSelected;
            QuestViewModel.ToggleVisibility(IsSelected);
        }
    }
}