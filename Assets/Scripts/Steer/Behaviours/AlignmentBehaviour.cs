using System.Linq;
using UnityEngine;

namespace Steer.Behaviours
{
    [CreateAssetMenu(menuName = "Steering/Behaviour/Alignment")]
    public class AlignmentBehaviour : MovementBehaviour
    {
        public override Vector2 CalculateMovement(Steering steering, Agent agent)
        {
            var alignment = Vector3.zero;

            var allies = agent.Allies();

            if (allies.Length == 0) return alignment;

            alignment = allies.Aggregate(alignment, (current, ship) => current + ship.transform.up);

            alignment /= allies.Length;

            return alignment;
        }
    }
}