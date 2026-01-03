using Binding;
using UnityEngine;
using ViewModel;

namespace Binders
{
    internal sealed class QuestScreenViewModelBinder : Binder
    {
        [SerializeField]
        private Binder m_goldQuestBinder;

        [SerializeField]
        private Binder m_silverQuestBinder;

        [SerializeField]
        private Binder m_bronzeQuestBinder;

        protected override void RefreshBindings()
        {
            var questsScreenViewModel = Bindable as QuestsScreenViewModel;

            if (m_goldQuestBinder)
                m_goldQuestBinder.Bindable = questsScreenViewModel?.GoldQuest;

            if (m_silverQuestBinder)
                m_silverQuestBinder.Bindable = questsScreenViewModel?.SilverQuest;

            if (m_bronzeQuestBinder)
                m_bronzeQuestBinder.Bindable = questsScreenViewModel?.BronzeQuest;
        }
    }
}