using System.Collections;
using Binding;
using UnityEngine;
using UnityEngine.UI;
using ViewModel;

namespace Binders
{
    internal sealed class QuestInfoViewModelBinder : Binder
    {
        [SerializeField]
        private Image m_checkMarkImage;
        
        private Coroutine m_currentAnimation;
        private const float m_AnimationDuration = 0.1f;

        private void Awake()
        {
            if (m_checkMarkImage)
            {
                UpdateCheckmarkScale(false);
            }
        }

        protected override void RefreshBindings()
        {
            if (Bindable is not QuestInfoViewModel questInfoViewModel) 
                return;
            
            StopRunningCheckmarkAnimation(!questInfoViewModel.IsSelected);
            StartCheckmarkAnimation(questInfoViewModel.IsSelected);
        }

        private void StopRunningCheckmarkAnimation(bool waSelected)
        {
            if (m_checkMarkImage == null || m_currentAnimation == null)
            {
                return;
            }
            
            StopCoroutine(m_currentAnimation);
            m_currentAnimation = null;
            m_checkMarkImage.transform.localScale = Vector3.one * (waSelected ? 1f : 0f);
        }
        
        private void StartCheckmarkAnimation(bool isSelected)
        {
            if (m_checkMarkImage == null) 
                return;
            
            m_currentAnimation = StartCoroutine(AnimateCheckmark(isSelected));
        }

        private IEnumerator AnimateCheckmark(bool isSelected)
        {
            Vector3 startScale = m_checkMarkImage.transform.localScale;
            Vector3 targetScale = Vector3.one * (isSelected ? 1f : 0f);
            
            float elapsed = 0f;
            while (elapsed < m_AnimationDuration)
            {
                m_checkMarkImage.transform.localScale = Vector3.Lerp(startScale, targetScale, elapsed / m_AnimationDuration);
                elapsed += Time.deltaTime;
                yield return null;
            }
            
            UpdateCheckmarkScale(isSelected);
            
            m_currentAnimation = null;
        }
        
        private void UpdateCheckmarkScale(bool isSelected)
        {
            m_checkMarkImage.transform.localScale = Vector3.one * (isSelected ? 1f : 0f);
        }
    }
}