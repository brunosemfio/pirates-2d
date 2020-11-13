using Steer.Behaviours;
using UnityEngine;

namespace Steer
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(Agent))]
    public class Steering : MonoBehaviour
    {
        #region Inspector

        [SerializeField] private MovementBehaviour behaviour;

        [SerializeField] private float maxVelocity;

        [SerializeField] private float maxAcceleration;

        #endregion

        #region Public

        public Vector2 Velocity => rb.velocity;

        public Steering Target { get; set; }

        public MovementBehaviour Behaviour
        {
            get => behaviour;
            set => behaviour = value;
        }

        #endregion

        #region Smooth

        private Vector2 currentDirection;

        private float currentAngle;

        #endregion

        #region Components

        private Rigidbody2D rb;

        private Agent agent;

        #endregion

        private void Awake()
        {
            rb = GetComponent<Rigidbody2D>();

            agent = GetComponent<Agent>();
        }

        private void FixedUpdate()
        {
            CalculateMovement();

            FaceDirection();
        }

        private void CalculateMovement()
        {
            if (behaviour == null) return;

            var direction = behaviour.CalculateMovement(this, agent);

            // direction = Vector2.SmoothDamp(transform.up, direction, ref currentDirection, turnSpeed);

            rb.velocity += direction * (maxAcceleration * Time.deltaTime);

            if (rb.velocity.sqrMagnitude > maxVelocity * maxVelocity)
            {
                rb.velocity = rb.velocity.normalized * maxVelocity;
            }
        }

        private void FaceDirection()
        {
            var direction = rb.velocity.normalized;

            var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90;
            
            // angle = Mathf.SmoothDampAngle(rb.rotation, angle, ref currentAngle, .1f);
            
            rb.MoveRotation(Quaternion.Euler(0f, 0f, angle));
        }
    }
}