using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : BaseEnemy
{
    private Vector2 endPos = new Vector2(1, 2f);
    public float intervalAfterGoingOnStage = 1f;
    void Start()
    {
        base.goToStage(endPos);
    }

    protected override IEnumerator goingOnStage(Vector3 endPos)
    {
        yield return StartCoroutine(base.goingOnStage(endPos));
        yield return new WaitForSeconds(intervalAfterGoingOnStage);
        base.hover();
        base.aim();
    }
}
