using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EM_Pawn_Turn : EnemyMovement
{
    public int directionFacing;


    public void PickRandomDirection()
    {
        directionFacing = Random.Range(0, 4);
        Debug.Log("DIRECTION: " + directionFacing);
    }



    public override void Move()
    {

        PickRandomDirection();

        //GO THROUGH ALL POTENTIAL MOVE PATHS

        if (directionFacing == 0)
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

                Move();
            }
        }
        else if (directionFacing == 1)
        {
            if (dir != DIRECTION.UP)
            {
                dir = DIRECTION.UP;
                enemyAttackPoint.position = position + Vector3.up;

            }

            enemyMovePoint.position += Vector3.up;
            if (!Physics2D.OverlapCircle(enemyMovePoint.position, 0.2f, whatStopsMovement))
            {
                position += Vector3.up;

                enemyAttackPoint.position = position + Vector3.up;

                StartCoroutine(enemyAnimations.AnimateWhenMoving());
                //TRIGGER end enemy move counter (IN COUROTUINE ABVOVE) for enemrymanager trigger end enemy attack turn

            }
            else
            {
                enemyMovePoint.position -= Vector3.up;
                //TRIGGER end enemy move counter  for enemrymanager trigger end enemy attack turn

                Move();
            }
        }
        else if (directionFacing == 2)
        {
            if (dir != DIRECTION.LEFT)
            {
                dir = DIRECTION.LEFT;
                enemyAttackPoint.position = position + Vector3.left;

            }

            enemyMovePoint.position += Vector3.left;
            if (!Physics2D.OverlapCircle(enemyMovePoint.position, 0.2f, whatStopsMovement))
            {
                position += Vector3.left;

                enemyAttackPoint.position = position + Vector3.left;

                StartCoroutine(enemyAnimations.AnimateWhenMoving());
                //TRIGGER end enemy move counter (IN COUROTUINE ABVOVE) for enemrymanager trigger end enemy attack turn

            }
            else
            {
                enemyMovePoint.position -= Vector3.left;
                //TRIGGER end enemy move counter  for enemrymanager trigger end enemy attack turn

                Move();
            }
        }
        else if (directionFacing == 3)
        {
            if (dir != DIRECTION.RIGHT)
            {
                dir = DIRECTION.RIGHT;
                enemyAttackPoint.position = position + Vector3.right;

            }

            enemyMovePoint.position += Vector3.right;
            if (!Physics2D.OverlapCircle(enemyMovePoint.position, 0.2f, whatStopsMovement))
            {
                position += Vector3.right;

                enemyAttackPoint.position = position + Vector3.right;

                StartCoroutine(enemyAnimations.AnimateWhenMoving());
                //TRIGGER end enemy move counter (IN COUROTUINE ABVOVE) for enemrymanager trigger end enemy attack turn

            }
            else
            {
                enemyMovePoint.position -= Vector3.right;
                //TRIGGER end enemy move counter  for enemrymanager trigger end enemy attack turn

                Move();
            }
        }
        else if (directionFacing == 4)
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

                Move();


            }



        }

    }
}
