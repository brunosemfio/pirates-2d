using UnityEngine;

namespace Steer.Behaviours
{
    [CreateAssetMenu(menuName = "Steering/Behaviour/Forward")]
    public class ForwardBehaviour : MovementBehaviour
    {
        public override Vector2 CalculateMovement(Steering steering, Agent agent)
        {
            return steering.transform.up;
        }
    }
}