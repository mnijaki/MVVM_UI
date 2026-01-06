using System;
using System.Collections.ObjectModel;
using Binding;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Model;

namespace ViewModel
{
    /// <summary>
    /// View model for the quests screen.
    /// </summary>
    public sealed partial class QuestsScreenViewModel : ObservableObject, IBindable
    {
        public QuestInfoViewModel GoldQuestInfoViewModel { get; }
        public QuestInfoViewModel SilverQuestInfoViewModel { get; }
        public QuestInfoViewModel BronzeQuestInfoViewModel { get; }
        
        [ObservableProperty]
        private ObservableCollection<QuestViewModel> m_questsCollection;
        
        [RelayCommand]
        private void ToggleGoldQuestSelection()
        {
            GoldQuestInfoViewModel.ToggleSelection();
            UpdateQuestsCollection();
        }

        [RelayCommand]
        private void ToggleSilverQuestSelection()
        {
            SilverQuestInfoViewModel.ToggleSelection();
            UpdateQuestsCollection();
        }

        [RelayCommand]
        private void ToggleBronzeQuestSelection()
        {
            BronzeQuestInfoViewModel.ToggleSelection();
            UpdateQuestsCollection();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="QuestsScreenViewModel"/> class.
        /// </summary>
        /// <param name="goldQuest">The gold quest model.</param>
        /// <param name="silverQuest">The silver quest model.</param>
        /// <param name="bronzeQuest">The bronze quest model.</param>
        /// <exception cref="ArgumentNullException">
        /// Thrown when <paramref name="goldQuest"/>, <paramref name="silverQuest"/>, or <paramref name="bronzeQuest"/> is <see langword="null"/>.
        /// </exception>
        public QuestsScreenViewModel(Quest goldQuest, Quest silverQuest, Quest bronzeQuest)
        {
            if (goldQuest == null)
                throw new ArgumentNullException(nameof(goldQuest));

            if (silverQuest == null)
                throw new ArgumentNullException(nameof(silverQuest));

            if (bronzeQuest == null)
                throw new ArgumentNullException(nameof(bronzeQuest));

            GoldQuestInfoViewModel = new QuestInfoViewModel(goldQuest);
            SilverQuestInfoViewModel = new QuestInfoViewModel(silverQuest);
            BronzeQuestInfoViewModel = new QuestInfoViewModel(bronzeQuest);

            QuestsCollection = new ObservableCollection<QuestViewModel>
            {
                GoldQuestInfoViewModel.QuestViewModel,
                SilverQuestInfoViewModel.QuestViewModel,
                BronzeQuestInfoViewModel.QuestViewModel
            };
        }
        
        private void UpdateQuestsCollection()
        {
            var newAllQuests = new ObservableCollection<QuestViewModel>(QuestsCollection);
            QuestsCollection = newAllQuests;
        }
    }
}
