using Abstractions.Commands;
using UnityEngine;

namespace Core
{
    public class MoveTask : IMoveTask
    {
        public Vector3 PathPoint { get;}

        public MoveTask(Vector3 point)
        {
            PathPoint = point;
        }
    }
}