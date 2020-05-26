using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimations : MonoBehaviour
{
    public Animator animator;
    public EnemyMovement enemyMovement;
    public EnemyManager enemyManager;

    public GameObject loseLevelCollider;


    


    void OnEnable()
    {
        EventManager.StartListening("enemyIdleAnimation", EnemyIdleAnimation);
        EventManager.StartListening("enemyMoveAnimation", EnemyMoveAnimation);
        EventManager.StartListening("enemyAttackAnimation", EnemyAttackAnimation);
        EventManager.StartListening("enemyWaitAnimation", EnemyWaitAnimation);
    }

    void OnDisable()
    {
        EventManager.StopListening("enemyIdleAnimation", EnemyIdleAnimation);
        EventManager.StopListening("enemyMoveAnimation", EnemyMoveAnimation);
        EventManager.StopListening("enemyAttackAnimation", EnemyAttackAnimation);
        EventManager.StopListening("enemyWaitAnimation", EnemyWaitAnimation);
    }

    public void Start()
    {
        enemyManager = FindObjectOfType<EnemyManager>();
    }


    public void EnemyIdleAnimation()
    {
    }

    public void EnemyMoveAnimation()
    {
        //Need to set up trigger in animator for animatiomn w/ duration = to time needed to move to next square
    }

    public void EnemyAttackAnimation()
    {
    }

    public void EnemyWaitAnimation()
    {
    }

    public IEnumerator AnimateWhenMoving()
    {


        //SET ANIMATION TO MOVE ANIMATION
        //EventManager.TriggerEvent("playerMoveAnimation");
        animator.SetBool("isMoving", true);

        //wait to register moving animation
        yield return new WaitForSeconds(0.05f);

        //BUGTESTING
        Debug.Log(animator.GetCurrentAnimatorStateInfo(0).length + animator.GetCurrentAnimatorStateInfo(0).normalizedTime);



        yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length + animator.GetCurrentAnimatorStateInfo(0).normalizedTime);

        //end move animation
        //EventManager.TriggerEvent("playerIdleAnimation");

        animator.SetBool("isMoving", false);


        enemyManager.enemyMoveCount--;

        //NEED NEW WAY TO TRIGGER ONCE FROM ENEMYMANAGER
        //IMPORTANT
        //IMPORTANT
        //EventManager.TriggerEvent("endEnemyMoveStage");
    }

    public IEnumerator AnimateWhenAttacking()
    {



        //yield return new WaitForSeconds(0);
        //SET ANIMATION TO MOVE ANIMATION
        EventManager.TriggerEvent("enemyAttackAnimation");

        

        yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length + animator.GetCurrentAnimatorStateInfo(0).normalizedTime);
        

        Debug.Log(gameObject + " KILLED ENEMY PLAYER WITH ATTACK");





        //SET ANIMATION TO MOVE ANIMATION
        animator.SetBool("isAttacking", true);

        //wait to register moving animation
        yield return new WaitForSeconds(0.05f);


        //BUGTESTING
        yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length + animator.GetCurrentAnimatorStateInfo(0).normalizedTime);

        animator.SetBool("isAttacking", false);


        //KILL PLAYER
        loseLevelCollider.GetComponent<LoseLevel>().AttackedByEnemy();


        //enemyMovement.playerCollider.gameObject.GetComponent<Killable>().Kill();


        enemyManager.enemyAttackCount--;


       // if (enemyMovement.playerCollider)
        //{
            

        //}

        





        //NEED A DIFFERNT KILLABLE FOR PLAYER NOT CONNECTED TO ENEMYMANAGER
        //enemyMovement.playerCollider.gameObject.GetComponent<Killable>().Kill();
        //enemyMovement.playerCollider = null;

        //NEED NEW WAY TO TRIGGER ONCE FROM ENEMYMANAGER
        //IMPORTANT
        //IMPORTANT
        // EventManager.TriggerEvent("endEnemyAttackStage");
    }
}

