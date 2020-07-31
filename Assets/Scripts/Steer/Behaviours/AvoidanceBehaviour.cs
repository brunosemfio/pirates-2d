using UnityEngine;

namespace Pirates.Steer.Behaviours
{
    [CreateAssetMenu(menuName = "Steering/Behaviour/Avoidance")]
    public class AvoidanceBehaviour : MovementBehaviour
    {
        public override Vector2 CalculateMovement(Steering steering, Agent agent)
        {
            return Vector2.zero;
        }
    }
}