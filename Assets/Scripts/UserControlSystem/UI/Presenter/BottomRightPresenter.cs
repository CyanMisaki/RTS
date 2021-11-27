using Abstractions;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UserControlSystem.UI.Model;

namespace UserControlSystem.UI.Presenter
{
    public sealed class BottomRightPresenter : MonoBehaviour
    {
        [SerializeField] private Button _move;
        [SerializeField] private Button _attack;
        [SerializeField] private Button _patrool;
        [SerializeField] private Button _holdPosition;
        
        [SerializeField] private SelectableValue _selectedValue;
        private bool _isNeededType;
        private bool _isButtonsEnabled;

        private void Start()
        {
            _move.onClick.AddListener(Move);
            _attack.onClick.AddListener(Attack);
            _patrool.onClick.AddListener(Patrol);
            _holdPosition.onClick.AddListener(HoldPosition);

            EnableButtons(_isButtonsEnabled);

            _selectedValue.OnNewValue += ONSelected;
            ONSelected(_selectedValue.CurrentValue);
        }

        private void EnableButtons(bool state)
        {
            _move.gameObject.SetActive(state);
            _attack.gameObject.SetActive(state);
            _patrool.gameObject.SetActive(state);
            _holdPosition.gameObject.SetActive(state);
        }

        private void ONSelected(ISelectable selected)
        {
            
            EnableButtons(selected is { Type: EnvironmentType.Unit });
        }

        private void HoldPosition()
        {
            Debug.Log($"{_selectedValue.CurrentValue.Name} is holding position");
        }

        private void Patrol()
        {
            Debug.Log($"Set target to patrol with {_selectedValue.CurrentValue.Name}");
        }

        private void Attack()
        {
            Debug.Log($"Set target to attack with {_selectedValue.CurrentValue.Name}");
        }

        private void Move()
        {
            Debug.Log($"Set target to move with {_selectedValue.CurrentValue.Name}");
        }

        private void OnDestroy()
        {
            _selectedValue.OnNewValue -= ONSelected;
            
            _move.onClick.RemoveAllListeners();
            _attack.onClick.RemoveAllListeners();
            _patrool.onClick.RemoveAllListeners();
            _holdPosition.onClick.RemoveAllListeners();
        }
    }
}