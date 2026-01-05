using Binding;
using UnityEngine;
using UnityEngine.UI;
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
        
        // MN:Check
        [SerializeField]
        private View.BinderContainerView m_questListView;
        
        // MN:Check
        [SerializeField]
        private Button m_goldButton;
        
        // MN:Check
        [SerializeField]
        private Button m_silverButton;
        
        // MN:Check
        [SerializeField]
        private Button m_bronzeButton;

        protected override void RefreshBindings()
        {
            var questsScreenViewModel = Bindable as QuestsScreenViewModel;
            // MN:early return. No need to check ? everywhere.
            if (questsScreenViewModel == null) 
                return;

            // MN: Bind individual quest binders.
            if (m_goldQuestBinder)
                m_goldQuestBinder.Bindable = questsScreenViewModel.GoldQuest;

            if (m_silverQuestBinder)
                m_silverQuestBinder.Bindable = questsScreenViewModel.SilverQuest;

            if (m_bronzeQuestBinder)
                m_bronzeQuestBinder.Bindable = questsScreenViewModel.BronzeQuest;
            
            // MN: Bind the dynamic quest list.
            if (m_questListView)
                m_questListView.Bindables = questsScreenViewModel.AllQuests;
            
            // MN: Bind button click events.
            if (m_goldButton)
            {
                m_goldButton.onClick.RemoveAllListeners();
                m_goldButton.onClick.AddListener(() => questsScreenViewModel.SelectGoldQuestCommand.Execute(null));
            }
            
            if (m_silverButton)
            {
                m_silverButton.onClick.RemoveAllListeners();
                m_silverButton.onClick.AddListener(() => questsScreenViewModel.SelectSilverQuestCommand.Execute(null));
            }
            
            if (m_bronzeButton)
            {
                m_bronzeButton.onClick.RemoveAllListeners();
                m_bronzeButton.onClick.AddListener(() => questsScreenViewModel.SelectBronzeQuestCommand.Execute(null));
            }
        }
    }
}