using System;
using Abstractions;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace UserControlSystem.UI.Presenter
{
    public class TopPanelPresenter: MonoBehaviour
    {
        [SerializeField] private TMP_InputField _inputField;
        [SerializeField] private Button _menuButton;
        [SerializeField] private GameObject _menuToOpen;

        [Inject]
        private void Init(ITimeModel timeModel)
        {
            timeModel.GameTime.Subscribe(seconds =>
                {
                    var t = TimeSpan.FromSeconds(seconds);
                    _inputField.text = $"{t.Minutes:D2}:{t.Seconds:D2}";
                });

            _menuButton.OnClickAsObservable().Subscribe(_ =>
            {
                Time.timeScale = 0;
                _menuToOpen.SetActive(true);
            });
        }
    }
    
}