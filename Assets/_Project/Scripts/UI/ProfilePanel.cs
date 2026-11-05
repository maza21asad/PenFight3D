using TMPro;
using UnityEngine;

namespace PenFight.UI
{
    public class ProfilePanel : UIPanel
    {
        [SerializeField] private TMP_Text _nameText;
        [SerializeField] private TMP_Text _levelText;
        [SerializeField] private TMP_Text _coinsText;
        [SerializeField] private TMP_Text _diamondsText;

        // Not called yet. The authentication step will feed it real data.
        public void SetProfile(string displayName, int level, long coins, long diamonds)
        {
            _nameText.text = displayName;
            _levelText.text = $"Level {level}";
            _coinsText.text = coins.ToString("N0");
            _diamondsText.text = diamonds.ToString("N0");
        }
    }
}