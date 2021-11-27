using UnityEngine;

namespace Utils
{
    public class OutlineSelector : MonoBehaviour
    {
        [SerializeField] private Outline[] _outlineComponents;

        private bool _isSelectedCache;

        private void Start() => DisableOutline();

        private void DisableOutline()
        {
            foreach (var item in _outlineComponents)
            {
                item.enabled = false;
            }
        }

        public void SetSelected(bool isSelected)
        {
            if (isSelected == _isSelectedCache) return;
            if (isSelected) EnableOutline();
            else DisableOutline();

            _isSelectedCache = isSelected;
        }

        private void EnableOutline()
        {
            foreach (var item in _outlineComponents)
            {
                item.enabled = true;
            }
        }
    }
}