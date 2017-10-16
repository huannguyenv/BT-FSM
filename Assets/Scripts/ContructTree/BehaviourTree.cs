namespace BT
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class BehaviourTree : MonoBehaviour
    {
        public NodeStatus treeStatus;
        public Node[] nodes;

        private int m_indexCurrentNode = 0;
        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            Node currentNode = nodes[m_indexCurrentNode];
            if (currentNode.status == NodeStatus.RUNNING || currentNode.status == NodeStatus.READY)
            {
                treeStatus = currentNode.Poke();
            }
        }
    }

}