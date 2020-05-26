using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{

    public EnemyManager enemyManager;
    public GameManager gameManager;

    private void Awake()
    {
        enemyManager.enabled = false;
    }

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    // called second
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {

        //Score reset with each level load
        gameManager.turnNumber = 0;

        //reset enemymoveandattackcounters each level
        enemyManager.enemyMoveCount = 0;
        enemyManager.enemyAttackCount = 0;

        //reset roundwon to false
        gameManager.roundWon = false;

        //clear enemy list manager

        if (SceneManager.GetActiveScene().buildIndex > 1)
        {
            enemyManager.enabled = true;
            enemyManager.ClearEnemyList();
            enemyManager.UpdateEnemyList();

            EventManager.TriggerEvent("startPlayerMoveStage");

            
        }
        else
        {
            enemyManager.ClearEnemyList();
            enemyManager.enabled = false;
        }

        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            gameManager.currentTurnStage = TurnStage.mainMenu;
        }

    }

    public void Start()
    {
        LoadNextLevel();
    }

    public void Update()
    {

     
        if (Input.GetKeyUp("p"))
        {
            Pause();
        }
       
    }


    public void RestartLevel()
    {
        int thisLevel = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(thisLevel);
    }

    public void RetryLevel()
    {
        int thisLevel = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(thisLevel);
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");

    }

    public void LoadNextLevel()
    {
        int thisLevel = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(thisLevel + 1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void Pause()
    {
        if (gameManager.currentTurnStage != TurnStage.pauseLevel && gameManager.currentTurnStage != TurnStage.mainMenu)
        {
            gameManager.stageAtPause = gameManager.currentTurnStage;
            gameManager.currentTurnStage = TurnStage.pauseLevel;
        }
        else if(gameManager.currentTurnStage != TurnStage.mainMenu)
        {
            gameManager.currentTurnStage = gameManager.stageAtPause;
        }
    }
}
