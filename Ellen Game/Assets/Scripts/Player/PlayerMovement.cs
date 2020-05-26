using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DIRECTION
{
    UP,
    DOWN,
    LEFT,
    RIGHT
}

public class PlayerMovement : MonoBehaviour
{
    //need to set up proper movement and attack wait times via animations


    //component connections
    //other gameobjects
    public GameManager gameManager;

    //same gameobject
    public PlayerAnimations playerAnimations;


    //Move and attack points/colliders
    public Transform playerAttackPoint;
    public LayerMask whatCanBeAttacked;

    public Transform playerMovePoint;
    public LayerMask whatStopsMovement;

    //movement variables
    private bool canMove = true;
    private bool moving = false;
    private int moveSpeed = 5;
    //private int moveCoolDown = 0;
    private DIRECTION dir = DIRECTION.DOWN;
    private Vector3 position;

    public Collider2D enemyCollider;

    //fix for quick double move bug
    public bool canMoveInput = true;

    //fix for multiple attack/kil triggers?
    public bool canAttack = true;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();

        //used gor fgrid-based movement below
        playerAttackPoint.parent = null;
        playerMovePoint.parent = null;

    }

    void Update()
    {
        if (gameManager.currentTurnStage == TurnStage.playerMoveTurn)
        {
            //MOVING COOLDOWN TIMER
            //moveCoolDown--;


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
        } else if (gameManager.currentTurnStage == TurnStage.playerAttackTurn)
        {
            if (canAttack)
            {
                if (Physics2D.OverlapCircle(playerAttackPoint.position, 0.2f, whatCanBeAttacked))
                {
                    enemyCollider = Physics2D.OverlapCircle(playerAttackPoint.position, 0.2f, whatCanBeAttacked);


                    StartCoroutine(playerAnimations.AnimateWhenAttacking());
                }
                else
                {
                    EventManager.TriggerEvent("endPlayerAttackStage");
                    canMoveInput = true;
                    canAttack = true;
                }

            } 


        }
            
        transform.position = Vector3.MoveTowards(transform.position, position, Time.deltaTime * moveSpeed);
    }

    private void Move()
    {

        if (canMoveInput)
        {
            //if (moveCoolDown <= 0)
            //{
                if (Input.GetKeyUp(KeyCode.UpArrow))
                {
                    if (dir != DIRECTION.UP)
                    {

                        dir = DIRECTION.UP;
                        playerAttackPoint.position = position + Vector3.up;

                        //animations
                        playerAnimations.animator.SetFloat("moveX", 0f);
                        playerAnimations.animator.SetFloat("moveY", 1f);
                    }
                    else
                    {

                        //moveCoolDown = 50;
                        canMove = false;
                        moving = true;

                        playerMovePoint.position += Vector3.up;
                        if (!Physics2D.OverlapCircle(playerMovePoint.position, 0.2f, whatStopsMovement))
                        {
                            position += Vector3.up;

                            playerAttackPoint.position = position + Vector3.up;

                            StartCoroutine(playerAnimations.AnimateWhenMoving());


                        }
                        else
                        {
                            playerMovePoint.position -= Vector3.up;
                        }

                    }

                }

                else if (Input.GetKeyUp(KeyCode.DownArrow))
                {
                    if (dir != DIRECTION.DOWN)
                    {

                        dir = DIRECTION.DOWN;
                        playerAttackPoint.position = position + Vector3.down;

                        //animations
                        playerAnimations.animator.SetFloat("moveX", 0f);
                        playerAnimations.animator.SetFloat("moveY", -1f);
                    }
                    else
                    {
                        //moveCoolDown = 50;
                        canMove = false;
                        moving = true;

                        playerMovePoint.position += Vector3.down;
                        if (!Physics2D.OverlapCircle(playerMovePoint.position, 0.2f, whatStopsMovement))
                        {
                            position += Vector3.down;

                            playerAttackPoint.position = position + Vector3.down;

                            StartCoroutine(playerAnimations.AnimateWhenMoving());
                        }
                        else
                        {
                            playerMovePoint.position -= Vector3.down;
                        }

                    }


                }

                else if (Input.GetKeyUp(KeyCode.LeftArrow))
                {
                    if (dir != DIRECTION.LEFT)
                    {

                        dir = DIRECTION.LEFT;
                        playerAttackPoint.position = position + Vector3.left;

                        //animations
                        playerAnimations.animator.SetFloat("moveX", -1f);
                        playerAnimations.animator.SetFloat("moveY", 0f);
                    }
                    else
                    {
                        //moveCoolDown = 50;
                        canMove = false;
                        moving = true;

                        playerMovePoint.position += Vector3.left;
                        if (!Physics2D.OverlapCircle(playerMovePoint.position, 0.2f, whatStopsMovement))
                        {
                            position += Vector3.left;

                            playerAttackPoint.position = position + Vector3.left;

                            StartCoroutine(playerAnimations.AnimateWhenMoving());
                        }
                        else
                        {
                            playerMovePoint.position -= Vector3.left;
                        }
                    }


                }

                else if (Input.GetKeyUp(KeyCode.RightArrow))
                {
                    if (dir != DIRECTION.RIGHT)
                    {

                        dir = DIRECTION.RIGHT;
                        playerAttackPoint.position = position + Vector3.right;

                        //animations
                        playerAnimations.animator.SetFloat("moveX", 1f);
                        playerAnimations.animator.SetFloat("moveY", 0f);
                    }
                    else
                    {
                        //moveCoolDown = 50;
                        canMove = false;
                        moving = true;

                        playerMovePoint.position += Vector3.right;
                        if (!Physics2D.OverlapCircle(playerMovePoint.position, 0.2f, whatStopsMovement))
                        {
                            position += Vector3.right;

                            playerAttackPoint.position = position + Vector3.right;

                            StartCoroutine(playerAnimations.AnimateWhenMoving());
                        }
                        else
                        {
                            playerMovePoint.position -= Vector3.right;
                        }
                    }
                }
            //}
        }

        
    }
}
