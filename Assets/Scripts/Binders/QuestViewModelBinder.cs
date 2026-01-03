using Binding;
using TMPro;
using UnityEngine;
using ViewModel;

namespace Binders
{
    internal sealed class QuestViewModelBinder : Binder
    {
        [SerializeField]
        private TextMeshProUGUI m_desciptionLabel;

        protected override void RefreshBindings()
        {
            var questViewModel = Bindable as QuestViewModel;

            if (m_desciptionLabel)
                m_desciptionLabel.text = questViewModel?.Description;
        }
    }
}