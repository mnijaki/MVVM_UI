using System.Collections;
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
        
        // MN: Get reference to rootTransform, so we can get initial scale of icon (used in bump animation).
        [SerializeField]
        private RectTransform m_rootTransform;
        
        // MN: local variables used for animation.
        private bool m_isAnimating;
        private Vector3 m_originalScale;

        // MN: Get initial scale.
        private void Awake()
        {
            if(m_rootTransform)
                m_originalScale = m_rootTransform.localScale;
        }

        protected override void RefreshBindings()
        {
            var questViewModel = Bindable as QuestViewModel;
            // MN:early return. No need to check ? everywhere.
            if (questViewModel == null) 
                return;

            if (m_descriptionLabel)
                m_descriptionLabel.text = questViewModel.Description;
            
            // MN: Run animation if flag in model tells you so, and we are not already animating.
            // MN: Check if this will correctly work with multiple fast clicks (think not, because it should kill the animation and start new one) ?
            if (questViewModel.ShouldAnimateBump && !m_isAnimating)
                StartBumpAnimation();
        }
        
        // MN: Animation handling.
        private void StartBumpAnimation()
        {
            if(m_rootTransform == null) 
                return;
            
            m_isAnimating = true;

            StartCoroutine(AnimateBump());
        }

        private IEnumerator AnimateBump()
        {
            // Scale up.
            Vector3 targetScale = m_originalScale * 1.1f;
            const float duration = 0.1f;
            float elapsed = 0f;

            while (elapsed < duration)
            {
                m_rootTransform.localScale = Vector3.Lerp(m_originalScale, targetScale, elapsed / duration);
                elapsed += Time.deltaTime;
                yield return null;
            }
            
            // MN:check if this is needed
            m_rootTransform.localScale = targetScale;
            
            // Scale back to normal.
            elapsed = 0f;
            while (elapsed < duration)
            {
                m_rootTransform.localScale = Vector3.Lerp(targetScale, m_originalScale, elapsed / duration);
                elapsed += Time.deltaTime;
                yield return null;
            }
            
            m_rootTransform.localScale = m_originalScale;
            m_isAnimating = false;
            
            // Reset animation flag in ViewModel.
            if(Bindable is QuestViewModel questViewModel)
                questViewModel.ShouldAnimateBump = false;
        }
    }
}