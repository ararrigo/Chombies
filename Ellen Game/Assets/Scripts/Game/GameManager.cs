using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TurnStage
{
    mainMenu,
    playerMoveTurn,
    playerAttackTurn,
    enemyMoveTurn,
    enemyAttackTurn,
    loseLevel,
    winLevel,
    pauseLevel,
    idle
    
}


public class GameManager : MonoBehaviour
{
    public TurnStage currentTurnStage;
    public TurnStage stageAtPause;

    public int turnNumber;
    public bool roundWon;

    public bool canPause;

    public GameObject loseMenu;
    public GameObject winMenu;
    public GameObject pauseMenu;
    public GameObject gameplayMenu;
    public GameObject mainMenuMenu;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        switch (currentTurnStage)
        {
            case TurnStage.mainMenu:
                canPause = false;
                mainMenuMenu.SetActive(true);
                gameplayMenu.SetActive(false);
                loseMenu.SetActive(false);
                winMenu.SetActive(false);
                pauseMenu.SetActive(false);
                break;
            case TurnStage.playerMoveTurn:
                canPause = true;
                mainMenuMenu.SetActive(false);
                gameplayMenu.SetActive(true);
                loseMenu.SetActive(false);
                winMenu.SetActive(false);
                pauseMenu.SetActive(false);
                break;
            case TurnStage.playerAttackTurn:
                canPause = true;
                mainMenuMenu.SetActive(false);
                gameplayMenu.SetActive(true);
                loseMenu.SetActive(false);
                winMenu.SetActive(false);
                pauseMenu.SetActive(false);
                break;
            case TurnStage.enemyMoveTurn:
                canPause = true;
                mainMenuMenu.SetActive(false);
                gameplayMenu.SetActive(true);
                loseMenu.SetActive(false);
                winMenu.SetActive(false);
                pauseMenu.SetActive(false);
                break;
            case TurnStage.enemyAttackTurn:
                canPause = true;
                mainMenuMenu.SetActive(false);
                gameplayMenu.SetActive(true);
                loseMenu.SetActive(false);
                winMenu.SetActive(false);
                pauseMenu.SetActive(false);
                break;
            case TurnStage.winLevel:
                canPause = false;
                mainMenuMenu.SetActive(false);
                gameplayMenu.SetActive(false);
                loseMenu.SetActive(false);
                winMenu.SetActive(true);
                pauseMenu.SetActive(false);
                break;
            case TurnStage.loseLevel:
                canPause = false;
                mainMenuMenu.SetActive(false);
                gameplayMenu.SetActive(false);
                loseMenu.SetActive(true);
                winMenu.SetActive(false);
                pauseMenu.SetActive(false);
                break;
            case TurnStage.pauseLevel:
                canPause = false;
                mainMenuMenu.SetActive(false);
                gameplayMenu.SetActive(false);
                loseMenu.SetActive(false);
                winMenu.SetActive(false);
                pauseMenu.SetActive(true);
                break;
            case TurnStage.idle:
                break;

            default:
                Debug.Log("not one of the TurnStages");
                break;
        }
    }



    //round 1
    //player moves left/right/up/down
            // translates to grid position
        // if enemy is in-front of player after moving, attack enemy
    //player turn over
    //enemy cpu calculates moves
        //enemies all move
    //if enemy moves onto player square/grid - player dies
    //ROUND 1 OVER



    //big things to do
    //CPU LOGIC


}
