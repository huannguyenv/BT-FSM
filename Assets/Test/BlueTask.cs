using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BT;
public class BlueTask : TaskNode
{
    public SpriteRenderer render;
    public float waitTime;

    public override IEnumerator CoroutinePoke()
    {
        render.color = Color.blue;
        yield return new WaitForSeconds(waitTime);
        status = NodeStatus.SUCCESS;
    }

    public override NodeStatus Poke()
    {
        //StartCoroutine(WaitASec(waitTime));
        
        return status;
    }

    // Use this for initialization
    public override void Start()
    {
        base.Start();
        status = NodeStatus.READY;
    }

    private IEnumerator WaitASec(float sec)
    {
        render.color = Color.blue;
        yield return new WaitForSeconds(sec);
        status = NodeStatus.SUCCESS;
    }
}
