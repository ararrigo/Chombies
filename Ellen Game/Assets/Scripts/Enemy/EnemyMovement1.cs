using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement1 : MonoBehaviour
{



    //component setting
    //different gameobject
    public GameManager gameManager;


    //same gameobject
    public EnemyAnimations enemyAnimations;


    //Move and attack points/colliders
    public Transform enemyAttackPoint;
    public LayerMask whatCanBeAttacked;

    public Transform enemyMovePoint;
    public LayerMask whatStopsMovement;





    
    private bool canMove = true;
    private bool moving = false;
    private int moveSpeed = 5;
    private DIRECTION dir = DIRECTION.DOWN;
    private Vector3 position;

    public Collider2D playerCollider;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        position = transform.position;
    }

    // Start is called before the first frame update
    void Update()
    {
        if (gameManager.currentTurnStage == TurnStage.enemyMoveTurn)
        {
            //MOVING VIA UPDATE
            if (canMove)
            {
                position = transform.position;


                Move();
            }

            if (moving)
            {
                if (transform.position == position)
                {
                    moving = false;
                    canMove = true;


                    Move();
                }


            }
        }
        else if (gameManager.currentTurnStage == TurnStage.enemyAttackTurn)
        {
            if (Physics2D.OverlapCircle(enemyAttackPoint.position, 0.2f, whatCanBeAttacked))
            {
                playerCollider = Physics2D.OverlapCircle(enemyAttackPoint.position, 0.2f, whatCanBeAttacked);

                StartCoroutine(enemyAnimations.AnimateWhenMoving());
                //check update the list of -- trigger list uopdaTE
            }
            else
            {
                EventManager.TriggerEvent("endEnemyAttackStage");
            }


        }
        else
        {
            EventManager.TriggerEvent("enemyWaitAnimation");
        }

        transform.position = Vector3.MoveTowards(transform.position, position, Time.deltaTime * moveSpeed);


    }





    public void Move()
    {

        dir = DIRECTION.DOWN;
        //enemyAttackPoint.position = position + Vector3.down;

        canMove = false;
        moving = true;

        //enemyMovePoint.position += Vector3.down;
        if (!Physics2D.OverlapCircle(enemyMovePoint.position, 0.2f, whatStopsMovement))
        {
            position += Vector3.down;

           enemyAttackPoint.position = enemyMovePoint.position + Vector3.down;

            StartCoroutine(enemyAnimations.AnimateWhenMoving());
        }
        else
        {
            enemyMovePoint.position -= Vector3.down;
        }




    }
}
