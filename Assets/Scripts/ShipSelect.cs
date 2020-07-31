using System.Linq;
using Cinemachine;
using Pirates.Steer;
using Pirates.Steer.Behaviours;
using UnityEngine;

namespace Pirates
{
    public class ShipSelect : MonoBehaviour
    {
        #region Inspector

        [SerializeField] private CinemachineVirtualCamera virtualCamera;

        [SerializeField] private MovementBehaviour playerBehaviour;

        #endregion

        private void Start()
        {
            Select();
        }

        private void Select()
        {
            var agent = Agent.All.FirstOrDefault();

            if (agent == null) return;

            var steering = agent.GetComponent<Steering>();

            steering.Behaviour = playerBehaviour;

            virtualCamera.Follow = steering.transform;

            for (var i = Agent.All.Count - 1; i >= 0; i--)
            {
                if (Agent.All[i] == agent) return;

                Agent.All[i].GetComponent<Steering>().Target = steering;
            }
        }
    }
}