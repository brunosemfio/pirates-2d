using System;
using UnityEngine;

namespace Pirates.Steer.Behaviours
{
    [CreateAssetMenu(menuName = "Steering/Behaviour/Composite")]
    public class CompositeBehaviour : MovementBehaviour
    {
        #region Public

        public BehaviourWeight[] movements;

        #endregion
        
        public override Vector2 CalculateMovement(Steering steering, Agent agent)
        {
            var direction = Vector2.zero;

            foreach (var movement in movements)
            {
                var partial = movement.behaviour.CalculateMovement(steering, agent) * movement.weight;

                if (partial.sqrMagnitude > movement.weight * movement.weight)
                {
                    partial = partial.normalized * movement.weight;
                }

                direction += partial;
            }

            return direction;
        }
    }

    [Serializable]
    public struct BehaviourWeight
    {
        public MovementBehaviour behaviour;
        public float weight;
    }
}