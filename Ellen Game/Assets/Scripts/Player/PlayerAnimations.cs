using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    public Animator animator;
    public PlayerMovement playerMovement;


    void OnEnable()
    {
        EventManager.StartListening("playerIdleAnimation", PlayerIdleAnimation);
        EventManager.StartListening("playerMoveAnimation", PlayerMoveAnimation);
        EventManager.StartListening("playerAttackAnimation", PlayerAttackAnimation);
        EventManager.StartListening("playerWaitAnimation", PlayerWaitAnimation);
    }

    void OnDisable()
    {
        EventManager.StopListening("playerIdleAnimation", PlayerIdleAnimation);
        EventManager.StopListening("playerMoveAnimation", PlayerMoveAnimation);
        EventManager.StopListening("playerAttackAnimation", PlayerAttackAnimation);
        EventManager.StopListening("playerWaitAnimation", PlayerWaitAnimation);
    }


    public void PlayerIdleAnimation()
    {
        Debug.Log("player IDLE animation has been triggered ");
        
    }

    public void PlayerMoveAnimation()
    {
        Debug.Log("player MOVING animation has been triggered ");
        
        //Need to set up trigger in animator for animatiomn w/ duration = to time needed to move to next square
    }

    public void PlayerAttackAnimation()
    {
        Debug.Log("player ATTACKING animation has been triggered ");
    }

    public void PlayerWaitAnimation()
    {
        Debug.Log("player WAITING UNTIL NEXT TURN animation has been triggered ");
    }

    public IEnumerator AnimateWhenMoving()
    {

        playerMovement.canMoveInput = false;


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


        //TURN CHANGER
        EventManager.TriggerEvent("endPlayerMoveStage");

        


    }

    public IEnumerator AnimateWhenAttacking()
    {

        playerMovement.canAttack = false;

        //SET ANIMATION TO MOVE ANIMATION
        animator.SetBool("isAttacking", true);

        //wait to register moving animation
        yield return new WaitForSeconds(0.05f);


        //BUGTESTING
        yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length + animator.GetCurrentAnimatorStateInfo(0).normalizedTime);

        animator.SetBool("isAttacking", false);

        if (playerMovement.enemyCollider)
        {
            Debug.Log("Player is attacking and if not actually attacjking you know coroutine calls everytiem");

            StartCoroutine(playerMovement.enemyCollider.gameObject.GetComponent<Killable>().Kill());

            //TURN CHANGER --- GOING TO NEED TO CHANGE AFTER ENEMY BANIMARTION BLOWS UP
            


            playerMovement.canMoveInput = true;
            

        }
        
       
        



    }
}
