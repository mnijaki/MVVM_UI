using System;
using Binding;
using CommunityToolkit.Mvvm.ComponentModel;
using Model;

namespace ViewModel
{
    /// <summary>
    /// View model for a quest.
    /// </summary>
    public sealed class QuestViewModel : ObservableObject, IBindable
    {
        /// <summary>
        /// Gets the description of the quest.
        /// </summary>
        public string Description { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="QuestViewModel"/> class.
        /// </summary>
        /// <param name="quest">The quest model to wrap.</param>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="quest"/> is <see langword="null"/>.</exception>
        public QuestViewModel(Quest quest)
        {
            if (quest == null)
                throw new ArgumentNullException(nameof(quest));

            Description = quest.Description;
        }
    }
}