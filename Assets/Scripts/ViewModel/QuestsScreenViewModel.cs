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
        public QuestViewModel GoldQuest { get; }

        /// <summary>
        /// Gets the view model for the silver quest.
        /// </summary>
        public QuestViewModel SilverQuest { get; }

        /// <summary>
        /// Gets the view model for the bronze quest.
        /// </summary>
        public QuestViewModel BronzeQuest { get; }
        
        // MN:Check
        // MN: MVVM Community Toolkit will automatically generate public property 'AllQuests'
        [ObservableProperty]
        private ObservableCollection<QuestViewModel> m_allQuests;
        
        // MN:Check
        // MN:Will automatically generate command property, e.g. SelectGoldQuestCommand.
        // MN:These command property will be created during object initialization.
        [RelayCommand]
        private void SelectGoldQuest() => GoldQuest.AnimateBump();
        
        // MN:Check
        // MN:Will automatically generate command property, e.g. SelectGoldQuestCommand.
        // MN:These command property will be created during object initialization.
        [RelayCommand]
        private void SelectSilverQuest() => SilverQuest.AnimateBump();
        
        // MN:Check
        // MN:Will automatically generate command property, e.g. SelectGoldQuestCommand.
        // MN:These command property will be created during object initialization.
        [RelayCommand]
        private void SelectBronzeQuest() => BronzeQuest.AnimateBump();

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

            GoldQuest = new QuestViewModel(goldQuest);
            SilverQuest = new QuestViewModel(silverQuest);
            BronzeQuest = new QuestViewModel(bronzeQuest);
            
            // MN:Check
            AllQuests = new ObservableCollection<QuestViewModel> {GoldQuest, SilverQuest, BronzeQuest};
        }
    }
}
