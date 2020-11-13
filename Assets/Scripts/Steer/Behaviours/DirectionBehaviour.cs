using UnityEngine;

namespace Steer.Behaviours
{
    [CreateAssetMenu(menuName = "Steering/Behaviour/Direction")]
    public class DirectionBehaviour : MovementBehaviour
    {
        #region Public

        public Vector2 direction;

        #endregion
        
        public override Vector2 CalculateMovement(Steering steering, Agent agent)
        {
            return direction;
        }
    }
}