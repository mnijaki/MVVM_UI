using System.Collections.Generic;
using Binding;
using UnityEngine;

namespace View
{
    /// <summary>
    /// A container view that dynamically creates and manages binder instances for a collection of bindable objects.
    /// </summary>
    public sealed class BinderContainerView : MonoBehaviour
    {
        [SerializeField]
        private GameObject m_itemPrefab;

        /// <summary>
        /// Gets or sets the collection of bindable objects to display in the container.
        /// </summary>
        public IReadOnlyList<IBindable> Bindables
        {
            get => m_bindables;
            set
            {
                if (ReferenceEquals(m_bindables, value))
                    return;

                m_bindables = value;
                RefreshContainer();
            }
        }

        private IReadOnlyList<IBindable> m_bindables;
        private readonly List<GameObject> m_instantiatedItems = new();

        private void RefreshContainer()
        {
            ClearContainer();

            if (m_bindables == null)
                return;

            CreateItems();
        }


        private void ClearContainer()
        {
            foreach (var item in m_instantiatedItems)
            {
                if (item != null)
                    Destroy(item);
            }

            m_instantiatedItems.Clear();
        }

        private void CreateItems()
        {
            foreach (var bindable in m_bindables)
            {
                var itemObject = Instantiate(m_itemPrefab, transform);

                var binder = itemObject.GetComponent<Binder>();
                if (!binder)
                    throw new MissingComponentException($"The item prefab '{m_itemPrefab.name}' is missing a '{nameof(Binder)}' component.");
                
                binder.Bindable = bindable;
                m_instantiatedItems.Add(itemObject);
            }
        }
    }
}
