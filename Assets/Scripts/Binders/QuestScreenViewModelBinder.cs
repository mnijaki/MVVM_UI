using Binding;
using UnityEngine;
using UnityEngine.UI;
using ViewModel;

namespace Binders
{
    internal sealed class QuestScreenViewModelBinder : Binder
    {
        [SerializeField]
        private Binder m_goldQuestInfoBinder;

        [SerializeField]
        private Binder m_silverQuestInfoBinder;

        [SerializeField]
        private Binder m_bronzeQuestInfoBinder;
        
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
            if (questsScreenViewModel == null) 
                return;

            // MN: Bind individual quest binders.
            if (m_goldQuestInfoBinder)
                m_goldQuestInfoBinder.Bindable = questsScreenViewModel.GoldQuestInfoViewModel;

            if (m_silverQuestInfoBinder)
                m_silverQuestInfoBinder.Bindable = questsScreenViewModel.SilverQuestInfoViewModel;

            if (m_bronzeQuestInfoBinder)
                m_bronzeQuestInfoBinder.Bindable = questsScreenViewModel.BronzeQuestInfoViewModel;
            
            // MN: Bind the dynamic quest list.
            if (m_questListView)
                m_questListView.Bindables = questsScreenViewModel.AllQuests;
            
            // MN: Bind button click events.
            if (m_goldButton)
            {
                m_goldButton.onClick.RemoveAllListeners();
                m_goldButton.onClick.AddListener(() => questsScreenViewModel.ToggleGoldQuestSelectionCommand.Execute(null));
            }
            
            if (m_silverButton)
            {
                m_silverButton.onClick.RemoveAllListeners();
                m_silverButton.onClick.AddListener(() => questsScreenViewModel.ToggleSilverQuestSelectionCommand.Execute(null));
            }
            
            if (m_bronzeButton)
            {
                m_bronzeButton.onClick.RemoveAllListeners();
                m_bronzeButton.onClick.AddListener(() => questsScreenViewModel.ToggleBronzeQuestSelectionCommand.Execute(null));
            }
        }
    }
}