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
    ///  MN: Class needs to be marked as 'partial' so the source generators can run correctly and
    ///          generate necessary code for [ObservableProperty] and [RelayCommand].
    /// </summary>
    public sealed partial class QuestsScreenViewModel : ObservableObject, IBindable
    {
        /// <summary>
        /// Gets the view model for the gold quest.
        /// </summary>
        public QuestInfoViewModel GoldQuestInfoViewModel { get; }

        /// <summary>
        /// Gets the view model for the silver quest.
        /// </summary>
        public QuestInfoViewModel SilverQuestInfoViewModel { get; }

        /// <summary>
        /// Gets the view model for the bronze quest.
        /// </summary>
        public QuestInfoViewModel BronzeQuestInfoViewModel { get; }
        
        // MN:Check
        // MN: MVVM Community Toolkit will automatically generate public property 'AllQuests'
        [ObservableProperty]
        private ObservableCollection<QuestViewModel> m_allQuests;
        
        // MN:Check
        // MN:Will automatically generate command property, e.g. SelectGoldQuestCommand.
        // MN:These command property will be created during object initialization.
        [RelayCommand]
        private void ToggleGoldQuestSelection()
        {
            GoldQuestInfoViewModel.ToggleSelection();
            
            var newAllQuests = new ObservableCollection<QuestViewModel>(AllQuests);
            if (GoldQuestInfoViewModel.IsSelected)
            {
                newAllQuests.Add(GoldQuestInfoViewModel.QuestViewModel);
            }
            else
            {
                newAllQuests.Remove(GoldQuestInfoViewModel.QuestViewModel);
            }
            
            AllQuests = newAllQuests;
        }

        // MN:Check
        // MN:Will automatically generate command property, e.g. SelectGoldQuestCommand.
        // MN:These command property will be created during object initialization.
        [RelayCommand]
        private void ToggleSilverQuestSelection()
        {
            SilverQuestInfoViewModel.ToggleSelection();
            
            var newAllQuests = new ObservableCollection<QuestViewModel>(AllQuests);
            if (SilverQuestInfoViewModel.IsSelected)
            {
                newAllQuests.Add(SilverQuestInfoViewModel.QuestViewModel);
            }
            else
            {
                newAllQuests.Remove(SilverQuestInfoViewModel.QuestViewModel);
            }
            
            AllQuests = newAllQuests;
        }

        // MN:Check
        // MN:Will automatically generate command property, e.g. SelectGoldQuestCommand.
        // MN:These command property will be created during object initialization.
        [RelayCommand]
        private void ToggleBronzeQuestSelection()
        {
            BronzeQuestInfoViewModel.ToggleSelection();
            
            var newAllQuests = new ObservableCollection<QuestViewModel>(AllQuests);
            if (BronzeQuestInfoViewModel.IsSelected)
            {
                newAllQuests.Add(BronzeQuestInfoViewModel.QuestViewModel);
            }
            else
            {
                newAllQuests.Remove(BronzeQuestInfoViewModel.QuestViewModel);
            }
            
            AllQuests = newAllQuests;
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

            AllQuests = new ObservableCollection<QuestViewModel>();
        }
    }
}
