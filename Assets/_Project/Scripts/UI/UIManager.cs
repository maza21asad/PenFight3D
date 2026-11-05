using System;
using System.Collections.Generic;
using UnityEngine;

namespace PenFight.UI
{
    public class UIManager : MonoBehaviour
    {
        [Serializable]
        public struct PanelEntry
        {
            public PanelId Id;
            public UIPanel Panel;
        }

        [SerializeField] private PanelEntry[] _panels;
        [SerializeField] private PanelId _startPanel = PanelId.Home;

        private readonly Dictionary<PanelId, UIPanel> _lookup = new();

        public PanelId Current { get; private set; }
        public event Action<PanelId> PanelChanged;

        private void Awake()
        {
            foreach (PanelEntry entry in _panels)
            {
                if (entry.Panel == null)
                {
                    Debug.LogWarning($"UIManager: panel '{entry.Id}' is not assigned.", this);
                    continue;
                }

                if (!_lookup.TryAdd(entry.Id, entry.Panel))
                {
                    Debug.LogWarning($"UIManager: panel '{entry.Id}' is listed twice.", this);
                    continue;
                }

                entry.Panel.Hide();
            }

            Current = _startPanel;

            if (_lookup.TryGetValue(_startPanel, out UIPanel start))
            {
                start.Show();
            }
            else
            {
                Debug.LogError($"UIManager: start panel '{_startPanel}' is missing.", this);
            }
        }

        public void Show(PanelId id)
        {
            if (id == Current)
            {
                return;
            }

            if (!_lookup.TryGetValue(id, out UIPanel next))
            {
                Debug.LogError($"UIManager: panel '{id}' is not registered.", this);
                return;
            }

            if (_lookup.TryGetValue(Current, out UIPanel previous))
            {
                previous.Hide();
            }

            next.Show();
            Current = id;
            PanelChanged?.Invoke(id);
        }
    }
}