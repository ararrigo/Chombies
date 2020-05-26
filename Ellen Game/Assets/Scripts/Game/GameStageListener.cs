using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class GameStageListener : MonoBehaviour
{
    public GameManager gameManager;
    public EnemyManager enemyManager;

    void OnEnable()
    {
        EventManager.StartListening("startPlayerMoveStage", StartPlayerMoveStage);
        EventManager.StartListening("endPlayerMoveStage", EndPlayerMoveStage);
        EventManager.StartListening("endPlayerAttackStage", EndPlayerAttackStage);
        EventManager.StartListening("endEnemyMoveStage", EndEnemyMoveStage);
        EventManager.StartListening("endEnemyAttackStage", EndEnemyAttackStage);
        EventManager.StartListening("loseLevel", LoseLevel);
        EventManager.StartListening("winLevel", WinLevel);
    }

    void OnDisable()
    {
        EventManager.StopListening("startPlayerMoveStage", StartPlayerMoveStage);
        EventManager.StopListening("endPlayerMoveStage", EndPlayerMoveStage);
        EventManager.StopListening("endPlayerAttackStage", EndPlayerAttackStage);
        EventManager.StopListening("endEnemyMoveStage", EndEnemyMoveStage);
        EventManager.StopListening("endEnemyAttackStage", EndEnemyAttackStage);
        EventManager.StopListening("loseLevel", LoseLevel);
        EventManager.StopListening("winLevel", WinLevel);
    }

    public void Start()
    {
        enemyManager = FindObjectOfType<EnemyManager>();
    }

    private void StartPlayerMoveStage()
    {
        gameManager.currentTurnStage = TurnStage.playerMoveTurn;
        Debug.Log("Current Stage = " + gameManager.currentTurnStage);
    }

    private void EndPlayerMoveStage()
    {
        gameManager.currentTurnStage = TurnStage.playerAttackTurn;
        Debug.Log("Current Stage = " + gameManager.currentTurnStage);
    }

    private void EndPlayerAttackStage()
    {
        enemyManager.enemiesCanMove = true;
        gameManager.currentTurnStage = TurnStage.enemyMoveTurn;
        Debug.Log("Current Stage = " + gameManager.currentTurnStage);
    }

    private void EndEnemyMoveStage()
    {
        gameManager.currentTurnStage = TurnStage.enemyAttackTurn;
        Debug.Log("Current Stage = " + gameManager.currentTurnStage);
    }

    private void EndEnemyAttackStage()
    {
        

        enemyManager.ResetEnemyMoveCount();
        enemyManager.ResetEnemyAttackCount();
        gameManager.turnNumber++;

        gameManager.currentTurnStage = TurnStage.playerMoveTurn;

        Debug.Log("Current Stage = " + gameManager.currentTurnStage);
    }

    private void LoseLevel()
    {
        gameManager.currentTurnStage = TurnStage.loseLevel;
        Debug.Log("Current Stage = " + gameManager.currentTurnStage);
    }

    private void WinLevel()
    {
        gameManager.currentTurnStage = TurnStage.winLevel;
        Debug.Log("Current Stage = " + gameManager.currentTurnStage);
    }
}

