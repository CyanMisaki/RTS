using System.Collections.Generic;
using System.Linq;
using Abstractions;
using UnityEngine;
using UnityEngine.EventSystems;
using UserControlSystem.UI.Model;
using Utils;

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
    
        private void Start() => _groundPlane = new Plane(_groundTransform.up, 0);

        private void Update()
        {
            if (!Input.GetMouseButtonUp(0) && !Input.GetMouseButton(1))
            {
                return;
            }
        
            if (_eventSystem.IsPointerOverGameObject())
            {
                return;
            }
        
            var ray = _camera.ScreenPointToRay(Input.mousePosition);
            var hits = Physics.RaycastAll(ray);
            if (Input.GetMouseButtonUp(0))
            {
                _selectedObject.SetValue(HittedObject<ISelectable>(hits, out var selectable) ? selectable : null);
            }
            else
            {
                if (HittedObject<IAttackable>(hits, out var attackable))
                {
                    _attackablesRMB.SetValue(attackable);
                }
                else if (_groundPlane.Raycast(ray, out var enter))
                {
                    _groundClicksRMB.SetValue(ray.origin + ray.direction * enter);
                }
            }
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