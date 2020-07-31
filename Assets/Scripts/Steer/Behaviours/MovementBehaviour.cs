using UnityEngine;

namespace Pirates.Steer.Behaviours
{
    public abstract class MovementBehaviour : ScriptableObject
    {
        public abstract Vector2 CalculateMovement(Steering steering, Agent agent);
    }
}