
using Abstractions;
using UnityEngine;
using UserControlSystem.UI.Model;
using Utils;

namespace UserControlSystem.UI.Presenter
{
    public class OutlineSelectorPresenter : MonoBehaviour
    {
        [SerializeField] private SelectableValue _selectableValue;
        private OutlineSelector[] _outlineSelectors;
        private ISelectable _currentSelectable;

        private void Start()
        {
            _selectableValue.OnSelected += OnSelected;
        }

        private void OnSelected(ISelectable obj)
        {
            if (_currentSelectable == obj) return;

            SetSelected(_outlineSelectors, false);
            _outlineSelectors = null;

            if (obj != null)
            {
                _outlineSelectors = (obj as Component)?.GetComponentsInParent<OutlineSelector>();
                SetSelected(_outlineSelectors, true);
            }
            else
            {
                if (_outlineSelectors != null)
                    SetSelected(_outlineSelectors, false);
            }

            _currentSelectable = obj;
        }

        static void SetSelected(OutlineSelector[] selectors, bool value)
        {
            if (selectors == null) return;
            foreach (var selector in selectors)
            {
                selector.SetSelected(value);
            }
        }
    }
}