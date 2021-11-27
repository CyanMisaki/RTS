using System;
using System.Linq;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Utils
{
    [CreateAssetMenu(fileName = nameof(AssetsContext), menuName = "RTS/" + nameof(AssetsContext), order = 1)]
    public sealed class AssetsContext : ScriptableObject
    {
        [SerializeField] private Object[] _objects;

        public Object GetObjectOfType(Type targetType, string targetName = null)
        {
            return _objects.Where(obj => obj.GetType().IsAssignableFrom(targetType)).FirstOrDefault(obj => targetName == null || obj.name == targetName);
        }
    }
}