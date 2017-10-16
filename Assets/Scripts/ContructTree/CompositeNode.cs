namespace BT
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class CompositeNode : Node
    {
        public NodeType compositeType;

        public Node[] childNodes;

        private int m_IndexChild = 0;

        [SerializeField]
        private int m_SuccessNode = 0;

        private bool[] m_Checked;
        private void Start()
        {
            m_Checked = new bool[childNodes.Length];
            type = NodeType.COMPOSITE;
            type = NodeType.COMPOSITE | compositeType;
        }

        public override NodeStatus Poke()
        {
            if (childNodes.Length < 1)
            {
                Debug.LogWarning("Composite node " + compositeType + "not contains any child");
                status = NodeStatus.FAILURE;
                return status;
            }
            else
            {
                switch (compositeType)
                {
                    case NodeType.SELECTOR:
                        HandleSelector();
                        break;
                    case NodeType.SEQUENCE:
                        HandleSequence();
                        break;
                    case NodeType.PARALLEL:
                        HandleParallel();
                        break;
                }
            }
            return status;
        }

        private NodeStatus HandleSelector()
        {
            Node currentNode;
            currentNode = childNodes[m_IndexChild];
            if (currentNode.status == NodeStatus.READY)
            {
                currentNode.Poke();
                status = NodeStatus.RUNNING;
                return status;
            }
            else if (currentNode.status == NodeStatus.RUNNING)
            {
                status = NodeStatus.RUNNING;
                return status;
            }
            else if (currentNode.status == NodeStatus.SUCCESS)
            {
                status = NodeStatus.SUCCESS;
                return status;
            }
            else
            {
                m_IndexChild++;
                if (m_IndexChild >= childNodes.Length)
                {
                    status = NodeStatus.FAILURE;
                    return status;
                }
                else
                {
                    status = NodeStatus.RUNNING;
                    return status;
                }
            }

        }

        private NodeStatus HandleSequence()
        {
            Debug.Log("handle sequence");
            Node currentNode;
            currentNode = childNodes[m_IndexChild];
            if (currentNode.status == NodeStatus.READY)
            {
                currentNode.Poke();
                status = NodeStatus.RUNNING;
                return status;
            }
            else if (currentNode.status == NodeStatus.RUNNING)
            {
                status = NodeStatus.RUNNING;
                return status;
            }
            else if (currentNode.status == NodeStatus.SUCCESS)
            {
                m_IndexChild++;
                if (m_IndexChild >= childNodes.Length)
                {
                    status = NodeStatus.SUCCESS;
                    return status;
                }
                else
                {
                    status = NodeStatus.RUNNING;
                    return status;
                }
            }
            else
            {
                status = NodeStatus.FAILURE;
                return status;
            }
        }

        private NodeStatus HandleParallel()
        {
            if(status == NodeStatus.READY || status == NodeStatus.RUNNING)
            {
                for (int i = 0; i < childNodes.Length; i++)
                {
                    if (childNodes[i].status == NodeStatus.READY)
                    {
                        childNodes[i].Poke();
                        status = NodeStatus.RUNNING;
                    }
                    else if (childNodes[i].status == NodeStatus.RUNNING)
                    {
                        childNodes[i].Poke();
                        status = NodeStatus.RUNNING;
                    }
                    else if (childNodes[i].status == NodeStatus.SUCCESS)
                    {
                        if (!m_Checked[i])
                        {
                            m_SuccessNode++;
                            m_Checked[i] = true;
                        }
                        
                        if (m_SuccessNode == childNodes.Length)
                        {
                            status = NodeStatus.SUCCESS;
                        }
                        else
                        {
                            status = NodeStatus.RUNNING;
                        }
                    }
                    else
                    {
                        status = NodeStatus.FAILURE;
                    }
                }
            }
            return status;
        }
    }

}