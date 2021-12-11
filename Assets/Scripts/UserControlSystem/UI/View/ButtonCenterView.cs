using System;
using Abstractions;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace UserControlSystem.UI.View
{
    public class ButtonCenterView : MonoBehaviour
    {
        public IObservable<int> CancelButtonClicks => _cancelButtonClicks;

        [SerializeField] private Slider _productionProcessSlider;
        [SerializeField] private TextMeshProUGUI _currentUnitName;

        [SerializeField] private Image[] _images;
        [SerializeField] private GameObject[] _imageHolders;
        [SerializeField] private Button[] _buttons;


        private Subject<int> _cancelButtonClicks = new Subject<int>();

        private IDisposable _unitProductionTaskCt;

        [Inject]
        private void Init()
        {
            for (var i = 0; i < _buttons.Length; i++)
            {
                var index = i;
                _buttons[i].onClick.AddListener(()=>_cancelButtonClicks.OnNext(index));
            }
        }

        public void Clear()
        {
            for (var i = 0; i < _images.Length; i++)
            {
                _images[i].sprite = null;
                _imageHolders[i].SetActive(false);
            }
            _productionProcessSlider.gameObject.SetActive(false);
            _currentUnitName.text=string.Empty;
        }

        public void SetTask(IUnitProductionTask task, int index)
        {
            if (task == null)
            {
                _imageHolders[index].SetActive(false);
                _images[index].sprite = null;

                if (index == 0)
                {
                    _productionProcessSlider.gameObject.SetActive(false);
                    _currentUnitName.text = string.Empty;
                    _currentUnitName.enabled = false;
                    _unitProductionTaskCt?.Dispose();
                }
            }
            else
            {
                _imageHolders[index].SetActive(true);
                _images[index].sprite = task.Icon;

                if (index == 0)
                {
                    _productionProcessSlider.gameObject.SetActive(true);
                    _currentUnitName.text = task.UnitName;
                    _currentUnitName.enabled = true;
                    _unitProductionTaskCt = Observable.EveryUpdate()
                        .Subscribe(_ =>
                        {
                            _productionProcessSlider.value = task.TimeLeft / task.ProductionTime;
                        });
                }    
            }
        }
    }
}