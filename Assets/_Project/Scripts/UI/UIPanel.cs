using UnityEngine;

namespace PenFight.UI
{
    public class UIPanel : MonoBehaviour
    {
        public void Show()
        {
            gameObject.SetActive(true);
            OnShown();
        }

        public void Hide()
        {
            gameObject.SetActive(false);
            OnHidden();
        }

        protected virtual void OnShown() { }

        protected virtual void OnHidden() { }
    }
}