using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "KnockState", menuName = "StatesSO/Knock")]
public class KnockState : StatesSO
{
    private EnemyController ec;

    public override void OnStateEnter(EnemyController ec)
    {
        ec.gameObject.GetComponent<ChaseBehaviour>().StopChasing();
        ec.gameObject.GetComponent<KnockBack>().GetKnockedBack(ec.target.transform, 5f);
    }

    public override void OnStateExit(EnemyController ec)
    {
    }

    public override void OnStateUpdate(EnemyController ec)
    {
       
    }
}
