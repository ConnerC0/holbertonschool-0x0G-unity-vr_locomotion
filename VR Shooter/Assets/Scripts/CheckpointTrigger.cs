using BNG;
using UnityEngine;

public class CheckpointTrigger : MonoBehaviour
{
    public TimerController timerController;
    public GameObject player;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {

            timerController.StopTimerAndShowEndScreen();

            // Disable the player locomotion script
            player.GetComponent<SmoothLocomotion>().enabled = false;
        }
    }
}
