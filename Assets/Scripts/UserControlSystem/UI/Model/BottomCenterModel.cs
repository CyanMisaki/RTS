using System;
using Abstractions;
using UniRx;
using UnityEngine;
using Zenject;

namespace UserControlSystem.UI.Model
{
    public class BottomCenterModel
    {
        public IObservable<IUnitProducer> UnitProducers { get; private set; }

        [Inject]
        public void Init(IObservable<ISelectable> selected)
        {
            UnitProducers = selected.Select(selectable => selectable as Component)
                .Select(component => component?.GetComponent<IUnitProducer>());
        }
    }
}