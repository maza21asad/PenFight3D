using UnityEngine;
using UnityEngine.UI;

namespace PenFight.UI
{
    [RequireComponent(typeof(Button))]
    public class NavButton : MonoBehaviour
    {
        [SerializeField] private UIManager _uiManager;
        [SerializeField] private PanelId _target;
        [SerializeField] private GameObject _selectedMark; // optional

        private Button _button;

        private void Awake()
        {
            _button = GetComponent<Button>();
            _button.onClick.AddListener(OnClicked);
        }

        // Start (not OnEnable) so UIManager.Awake has already run.
        private void Start()
        {
            _uiManager.PanelChanged += Refresh;
            Refresh(_uiManager.Current);
        }

        private void OnDestroy()
        {
            if (_uiManager != null)
            {
                _uiManager.PanelChanged -= Refresh;
            }

            _button.onClick.RemoveListener(OnClicked);
        }

        private void OnClicked()
        {
            _uiManager.Show(_target);
        }

        private void Refresh(PanelId current)
        {
            if (_selectedMark != null)
            {
                _selectedMark.SetActive(current == _target);
            }
        }
    }
}