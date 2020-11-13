using Steer.Behaviours;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Pirates
{
    public class PlayerController : MonoBehaviour
    {
        #region Inspector

        [SerializeField] private DirectionBehaviour playerDirection;

        #endregion

        private void Update()
        {
            if (Joystick.current == null) return;

            playerDirection.direction = Joystick.current.stick.ReadValue();
        }
    }
}