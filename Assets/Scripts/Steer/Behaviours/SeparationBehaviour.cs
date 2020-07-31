using UnityEngine;

namespace Pirates.Steer.Behaviours
{
    [CreateAssetMenu(menuName = "Steering/Behaviour/Separation")]
    public class SeparationBehaviour : MovementBehaviour
    {
        #region Public

        public float distance;

        #endregion

        public override Vector2 CalculateMovement(Steering steering, Agent agent)
        {
            var separation = Vector2.zero;
            
            var neighbors = agent.Neighbors();

            if (neighbors.Length == 0) return separation;

            var count = 0;

            foreach (var ship in neighbors)
            {
                var direction = steering.transform.position - ship.transform.position;

                if (direction.sqrMagnitude > distance * distance) continue;

                separation += (Vector2) direction;
                
                count++;
            }

            if (count > 0) separation /= count;

            return separation;
        }
    }
}