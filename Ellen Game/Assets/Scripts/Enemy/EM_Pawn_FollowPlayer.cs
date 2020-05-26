using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EM_Pawn_FollowPlayer : EnemyMovement
{

    public override void Move()
    {
        if (dir != DIRECTION.DOWN)
        {
            dir = DIRECTION.DOWN;
            enemyAttackPoint.position = position + Vector3.down;

        }

        enemyMovePoint.position += Vector3.down;
        if (!Physics2D.OverlapCircle(enemyMovePoint.position, 0.2f, whatStopsMovement))
        {
            position += Vector3.down;

            enemyAttackPoint.position = position + Vector3.down;

            StartCoroutine(enemyAnimations.AnimateWhenMoving());
            //TRIGGER end enemy move counter (IN COUROTUINE ABVOVE) for enemrymanager trigger end enemy attack turn

        }
        else
        {
            enemyMovePoint.position -= Vector3.down;
            //TRIGGER end enemy move counter  for enemrymanager trigger end enemy attack turn
        }


    }
}
