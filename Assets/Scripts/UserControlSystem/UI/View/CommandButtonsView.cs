using System;
using System.Collections.Generic;
using System.Linq;
using Abstractions.Commands;
using Abstractions.Commands.CommandsInterfaces;
using UnityEngine;
using UnityEngine.UI;

namespace UserControlSystem.UI.View
{
    public sealed class CommandButtonsView : MonoBehaviour
    {
        public Action<ICommandExecutor> OnClick;

        [SerializeField] private GameObject _attackButton;
        [SerializeField] private GameObject _moveButton;
        [SerializeField] private GameObject _patrolButton;
        [SerializeField] private GameObject _stopButton;
        [SerializeField] private GameObject _produceUnitButton;

        private Dictionary<Type, GameObject> _buttonsByExecutorType;

        private void Start()
        {
            _buttonsByExecutorType = new Dictionary<Type, GameObject>();
            _buttonsByExecutorType
                .Add(typeof(CommandExecutorBase<IAttackCommand>), _attackButton);
            _buttonsByExecutorType
                .Add(typeof(CommandExecutorBase<IMoveCommand>), _moveButton);
            _buttonsByExecutorType
                .Add(typeof(CommandExecutorBase<IPatrolCommand>), _patrolButton);
            _buttonsByExecutorType
                .Add(typeof(CommandExecutorBase<IStopCommand>), _stopButton);
            _buttonsByExecutorType
                .Add(typeof(CommandExecutorBase<IProduceUnitCommand>), _produceUnitButton);
        }

        public void BlockInteractions(ICommandExecutor commandExecutor)
        {
            UnblockAllInteractions();
            GETButtonGameObjectByType(commandExecutor.GetType())
                .GetComponent<Selectable>().interactable = false;
        }

        private GameObject GETButtonGameObjectByType(Type executorInstanceType)
        {
            return _buttonsByExecutorType
                .First(type => type.Key.IsAssignableFrom(executorInstanceType))
                .Value;
        }

        public void UnblockAllInteractions() => SetInteractable(true);

        private void SetInteractable(bool value)
        {
            _attackButton.GetComponent<Selectable>().interactable = value;
            _moveButton.GetComponent<Selectable>().interactable = value;
            _patrolButton.GetComponent<Selectable>().interactable = value;
            _stopButton.GetComponent<Selectable>().interactable = value;
            _produceUnitButton.GetComponent<Selectable>().interactable = value;
        }

        public void MakeLayout(IEnumerable<ICommandExecutor> commandExecutors)
        {
            foreach (var currentExecutor in commandExecutors)
            {
                try
                {
                    var buttonGameObject = GETButtonGameObjectByType(currentExecutor.GetType());
                    buttonGameObject.SetActive(true);
                    var button = buttonGameObject.GetComponent<Button>();
                    button.onClick.AddListener(() => OnClick?.Invoke(currentExecutor));
                }
                catch (Exception e)
                {
                    // ignored
                }
            }
        }

        public void Clear()
        {
            foreach (var item in _buttonsByExecutorType)
            {
                item.Value.GetComponent<Button>().onClick.RemoveAllListeners();
                item.Value.SetActive(false);
            }
        }
    }
}