using System;
using Abstractions;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UserControlSystem.UI.Model;
using Zenject;
using UniRx;

namespace UserControlSystem.UI.Presenter
{
    public sealed class BottomRightPresenter : MonoBehaviour
    {
        [SerializeField] private Button _move;
        [SerializeField] private Button _attack;
        [SerializeField] private Button _patrool;
        [SerializeField] private Button _holdPosition;
        
        [Inject] private IObservable<ISelectable> _selectedValue;
        private bool _isNeededType;
        private bool _isButtonsEnabled;

        private void Start() => _selectedValue.Subscribe(ONSelected);
        
        private void ONSelected(ISelectable selected)
        {
            
        }
    }
}