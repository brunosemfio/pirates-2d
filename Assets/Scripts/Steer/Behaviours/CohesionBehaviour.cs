using System.Linq;
using UnityEngine;

namespace Steer.Behaviours
{
    [CreateAssetMenu(menuName = "Steering/Behaviour/Cohesion")]
    public class CohesionBehaviour : MovementBehaviour
    {
        public override Vector2 CalculateMovement(Steering steering, Agent agent)
        {
            var cohesion = Vector3.zero;
            
            var allies = agent.Allies();

            if (allies.Length == 0) return cohesion;

            cohesion = allies.Aggregate(cohesion, (current, ship) => current + ship.transform.position);

            cohesion /= allies.Length;

            cohesion -= steering.transform.position;
            
            return cohesion;
        }
    }
}