using UnityEngine;

namespace Steer.Behaviours
{
    [CreateAssetMenu(menuName = "Steering/Behaviour/Pursue")]
    public class PursueBehaviour : MovementBehaviour
    {
        #region Public

        public float prediction;

        #endregion

        public override Vector2 CalculateMovement(Steering steering, Agent agent)
        {
            var target = steering.Target;

            if (target == null) return Vector2.zero;

            var targetPosition = (Vector2) target.transform.position;
            targetPosition += target.Velocity * prediction;
            targetPosition -= (Vector2) steering.transform.position;

            return targetPosition;
        }
    }
}