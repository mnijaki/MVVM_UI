using System;
using Binding;
using CommunityToolkit.Mvvm.ComponentModel;
using Model;

namespace ViewModel
{
    /// <summary>
    /// View model for the quests screen.
    /// </summary>
    public sealed class QuestsScreenViewModel : ObservableObject, IBindable
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
        }
    }
}
