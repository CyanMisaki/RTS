using System.Collections.Generic;
using System.Linq;
using Abstractions;
using UnityEngine;
using UnityEngine.EventSystems;
using UserControlSystem.UI.Model;
using Utils;
using UniRx;

namespace UserControlSystem.UI.Presenter
{
    public sealed class MouseInteractionPresenter : MonoBehaviour
    {
        [SerializeField] private Camera _camera;
        [SerializeField] private SelectableValue _selectedObject;
        [SerializeField] private EventSystem _eventSystem;
    
        [SerializeField] private Vector3Value _groundClicksRMB;
        [SerializeField] private AttackableValue _attackablesRMB;
        [SerializeField] private Transform _groundTransform;
    
        private Plane _groundPlane;

        private Ray ray;
        private RaycastHit[] hits;
    
        private void Start()
        {
            _groundPlane = new Plane(_groundTransform.up, 0);

            Observable.EveryUpdate().Where(t => Input.GetMouseButtonUp(0)).Subscribe(_ =>
            {
                if (_eventSystem.IsPointerOverGameObject())
                {
                    return;
                }
        
                GetRaycastHits();

                _selectedObject.SetValue(HittedObject<ISelectable>(hits, out var selectable) ? selectable : null);
                    
            });
            
            Observable.EveryUpdate().Where(t => Input.GetMouseButtonUp(1)).Subscribe(_ =>
            {
                GetRaycastHits();
                
                if (HittedObject<IAttackable>(hits, out var attackable))
                {
                    _attackablesRMB.SetValue(attackable);
                }
                else if (_groundPlane.Raycast(ray, out var enter))
                {
                    _groundClicksRMB.SetValue(ray.origin + ray.direction * enter);
                }
            });
            
        }

        private void GetRaycastHits()
        {
            ray = _camera.ScreenPointToRay(Input.mousePosition);
            hits = Physics.RaycastAll(ray);
        }
        private bool HittedObject<T>(IReadOnlyCollection<RaycastHit> hits, out T result) where T : class
        {
            result = default;
            if (hits.Count == 0)
            {
                return false;
            }    
            result = hits
                .Select(hit => hit.collider.GetComponentInParent<T>())
                .FirstOrDefault(item => item != null);
            return result != default;
        }
    }
}