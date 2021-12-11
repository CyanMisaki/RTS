using UnityEngine;

namespace Abstractions.Commands
{
    public interface IMoveTask
    {
        public Vector3 PathPoint { get; }
    }
}