using Binding;
using Model;
using UnityEngine;
using ViewModel;

/// <summary>
/// Entry point for initializing the quest screen.
/// </summary>
/// <remarks>
/// NOTE: THIS CLASS SHOULD NOT BE MODIFIED.
/// </remarks>
internal sealed class EntryPoint : MonoBehaviour
{
    [SerializeField]
    private Binder m_questScreenBinder;

    private Quest m_goldQuest;
    private Quest m_silverQuest;
    private Quest m_bronzeQuest;
    private QuestsScreenViewModel m_questsScreenViewModel;

    private void Awake()
    {
        m_goldQuest = new Quest("Lorem ipsum dolor sit amet, consectetur adipiscing elit.");
        m_silverQuest = new Quest("Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.");
        m_bronzeQuest = new Quest("Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.");

        m_questsScreenViewModel = new QuestsScreenViewModel(m_goldQuest, m_silverQuest, m_bronzeQuest);
    }

    private void Start() =>
        m_questScreenBinder.Bindable = m_questsScreenViewModel;
}
