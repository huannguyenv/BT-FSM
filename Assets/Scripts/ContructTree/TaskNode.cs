namespace BT
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public abstract class TaskNode : Node
    {
        public virtual void Start()
        {
            type = NodeType.TASK;
        }

        public abstract IEnumerator CoroutinePoke();
    }

}