using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Steer
{
    public class Agent : MonoBehaviour
    {
        #region Static

        public static readonly List<Agent> All = new List<Agent>();

        #endregion

        #region Inspector

        [SerializeField] private float radarRadius;

        [SerializeField] private int groupId;

        #endregion

        private void OnEnable()
        {
            All.Add(this);
        }

        private void OnDisable()
        {
            All.Remove(this);
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, radarRadius);
        }
        public Agent[] Neighbors()
        {
            return (
                from agent in All
                where agent != this
                let distance = agent.transform.position - transform.position
                where distance.sqrMagnitude <= radarRadius * radarRadius
                select agent
            ).ToArray();
        }

        public Agent[] Allies()
        {
            return Neighbors().Where(agent => agent.groupId == groupId).ToArray();
        }
    }
}