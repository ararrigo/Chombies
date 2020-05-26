using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseLevel : MonoBehaviour
{

    public Collider2D borderCollider;

    public void OnTriggerStay2D(Collider2D collision)
    {

        Debug.Log(gameObject + " collided with bottom border");

        if (collision.gameObject.tag == "Enemy")
        {
            borderCollider.enabled = !borderCollider.enabled;
            EventManager.TriggerEvent("loseLevel");
            
        }

    }

    public void AttackedByEnemy()
    {
        EventManager.TriggerEvent("loseLevel");
    }
}
