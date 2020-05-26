using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Killable : MonoBehaviour
{

    //components from same gameobject
    public EnemyManager enemyManager;
    public EnemyMovement enemyMovement;
    public Animator animator;

    //components of different GameObject
    public PlayerMovement playerMovement;


    public void Start()
    {
        enemyManager = FindObjectOfType<EnemyManager>();
    }

    public IEnumerator Kill()
    {
        Debug.Log("Kill script called");

        //SET ANIMATION TO MOVE ANIMATION
        animator.SetTrigger("isAttacked");


        //adjust enemy move and attack amounts
        enemyManager.enemyMoveCount--;
        enemyManager.enemyAttackCount--;




        //wait to register moving animation
        yield return new WaitForSeconds(0.05f);


        //BUGTESTING
        yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length + animator.GetCurrentAnimatorStateInfo(0).normalizedTime);


        EventManager.TriggerEvent("endPlayerAttackStage");

        enemyMovement.playerCollider.gameObject.GetComponent<PlayerMovement>().canAttack = true;

        enemyManager.enemyList.Remove(this.gameObject);

        Destroy(enemyMovement.enemyMovePoint.gameObject);
        Destroy(enemyMovement.enemyAttackPoint.gameObject);
        Destroy(this.gameObject);

        

         
    }

}
