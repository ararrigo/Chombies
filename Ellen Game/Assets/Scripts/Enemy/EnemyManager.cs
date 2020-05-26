using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{

    //find all enemy gameobjects in scene
    //for each enemy gameobject trigger move function when it's enemy turn
    //disable enemy turn once move function is triggered
    public GameManager gameManager;


    public List<GameObject> enemyList = new List<GameObject>();


    public int enemyMoveCount;
    public int enemyAttackCount;

    public bool enemiesCanMove;





    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        //if enemy list is empty, then player wins game
        if(enemyList.Count == 0)
        {
            if (!gameManager.roundWon)
            {
                gameManager.roundWon = true;
                EventManager.TriggerEvent("winLevel");
            }
            
        }

        //if all enemymovecounts triggered then end move turn
        if(enemyMoveCount == 0 && gameManager.currentTurnStage == TurnStage.enemyMoveTurn)
        {
            EventManager.TriggerEvent("endEnemyMoveStage");
        }

        if (enemyAttackCount == 0 && gameManager.currentTurnStage == TurnStage.enemyAttackTurn)
        {
            EventManager.TriggerEvent("endEnemyAttackStage");
        }

        //if all enemy attackcounts triggered then end attack turn


        if (gameManager.currentTurnStage == TurnStage.enemyMoveTurn)
        {

            //this is contained within the enemy listener
            
            // GOING TO HAVE TO NOT CAL ENEMYMOVE DURING UPDATE EITHE RWITH IDLE OR WITH ANOTHER COUNTER WHICH RESETS AFTER EACH TURN

            if (enemiesCanMove)
            {
                enemiesCanMove = false;

                //change from listenr to calling function in for each enemy in list
                foreach(GameObject enemy in enemyList)
                {
                    float randomWaitTime = Random.Range(0.1f, 1.0f);
                    enemy.GetComponent<EnemyMovement>().randomWaitTime = randomWaitTime;

                    StartCoroutine(enemy.GetComponent<EnemyMovement>().TriggerEnemyMovement());
                    


                }
                
            }
            


        }

        
        
    }

    public void UpdateEnemyList()
    {
        foreach (GameObject enemy in GameObject.FindGameObjectsWithTag("Enemy"))
        {
            enemyMoveCount++;
            enemyAttackCount++;
            enemyList.Add(enemy);

        }

        
    }

    public void ClearEnemyList()
    {
        enemyList.Clear();
    }

    public void ResetEnemyMoveCount()
    {
        foreach (GameObject enemy in GameObject.FindGameObjectsWithTag("Enemy"))
        {
            enemyMoveCount++;


        }


    }

    public void ResetEnemyAttackCount()
    {
        foreach (GameObject enemy in GameObject.FindGameObjectsWithTag("Enemy"))
        {
            enemyAttackCount++;


        }


    }
}
