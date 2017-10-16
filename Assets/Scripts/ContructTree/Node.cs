namespace BT
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public abstract class Node : ScriptableObject
    {
        public NodeStatus status;
        public NodeType type;

        public abstract NodeStatus Poke();
    }

}