using Binding;
using TMPro;
using UnityEngine;
using ViewModel;

namespace Binders
{
    internal sealed class QuestViewModelBinder : Binder
    {
        [SerializeField]
        private TextMeshProUGUI m_descriptionLabel;

        protected override void RefreshBindings()
        {
            var questViewModel = Bindable as QuestViewModel;
            if (questViewModel == null) 
                return;

            if (m_descriptionLabel)
                m_descriptionLabel.text = questViewModel.Description;
            
            gameObject.SetActive(questViewModel.IsVisible);
        }
    }
}