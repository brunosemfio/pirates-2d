using System;
using UnityEngine;

namespace Steer.Behaviours
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

            for (var i = 0; i < movements.Length; i++)
            {
                var partial = movements[i].behaviour.CalculateMovement(steering, agent) * movements[i].weight;

                if (partial.sqrMagnitude > movements[i].weight * movements[i].weight)
                {
                    partial = partial.normalized * movements[i].weight;
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