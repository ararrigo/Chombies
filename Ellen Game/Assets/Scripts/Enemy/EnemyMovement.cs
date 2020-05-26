using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{



    //component setting
    //different gameobject
    public GameManager gameManager;
    public EnemyManager enemyManager;


    //same gameobject
    public EnemyAnimations enemyAnimations;


    //Move and attack points/colliders
    public Transform enemyAttackPoint;
    public LayerMask whatCanBeAttacked;

    public Transform enemyMovePoint;
    public LayerMask whatStopsMovement;


    public int moveSpeed = 5;
    public DIRECTION dir = DIRECTION.DOWN;
    public Vector3 position;

    public Collider2D playerCollider;

    public float randomWaitTime;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        enemyManager = FindObjectOfType<EnemyManager>();

        position = transform.position;

        //used gor fgrid-based movement below
        enemyAttackPoint.parent = null;
        enemyMovePoint.parent = null;

    }

    // Start is called before the first frame update
    void Update()
    {

        if (gameManager.currentTurnStage == TurnStage.enemyAttackTurn)
        {
            if (Physics2D.OverlapCircle(enemyAttackPoint.position, 0.2f, whatCanBeAttacked))
            {
                playerCollider = Physics2D.OverlapCircle(enemyAttackPoint.position, 0.2f, whatCanBeAttacked);


                StartCoroutine(enemyAnimations.AnimateWhenAttacking());
            }
            else
            {
                enemyManager.enemyAttackCount--;
            }


        }


        //actual movement 
        transform.position = Vector3.MoveTowards(transform.position, position, Time.deltaTime * moveSpeed);

    }



    public IEnumerator TriggerEnemyMovement()
    {
        yield return new WaitForSeconds(randomWaitTime);
        Move();
    }

    public virtual void Move()
    {

    }
}
