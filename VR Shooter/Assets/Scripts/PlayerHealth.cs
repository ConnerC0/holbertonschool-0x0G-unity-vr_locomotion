using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int health = 3;
    public TimerController timerController;
    public StatTracker statTracker;

    public void TakeDamage(int damage)
    {
        health -= damage;
        statTracker.UpdatePlayerHealthText();
        Debug.Log("Player health: " + health);

        if (health <= 0)
        {
            timerController.StopTimerAndShowGameOverScreen();
        }
    }
}