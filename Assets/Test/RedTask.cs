using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BT;

public class RedTask : TaskNode
{
    public SpriteRenderer render;
    public float waitTime;

    public override void Start()
    {
        base.Start();
        status = NodeStatus.READY;
    }

    public override NodeStatus Poke()
    {
        //StartCoroutine(WaitASec(waitTime));
        
        return status;
    }

    private IEnumerator WaitASec(float sec)
    {
        render.color = Color.red;
        yield return new WaitForSeconds(sec);
        status = NodeStatus.SUCCESS;
    }

    public override IEnumerator CoroutinePoke()
    {
        render.color = Color.blue;
        yield return new WaitForSeconds(waitTime);
        status = NodeStatus.SUCCESS;
    }
}
