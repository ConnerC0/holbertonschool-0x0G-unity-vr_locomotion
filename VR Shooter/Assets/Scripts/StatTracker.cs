using UnityEngine;
using TMPro;

public class StatTracker : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public TextMeshProUGUI playerHealthText;
    public TextMeshProUGUI zombieKillsText;

    public int zombieKills;

    private void Start()
    {
        zombieKills = 0;
        UpdatePlayerHealthText();
        UpdateZombieKillsText();
    }

    private void Update()
    {
        UpdatePlayerHealthText();
    }

    public void IncrementZombieKill()
    {
        zombieKills++;
        UpdateZombieKillsText();
    }

    public void UpdatePlayerHealthText()
    {
        playerHealthText.text = $"Health: {playerHealth.health}";
    }

    private void UpdateZombieKillsText()
    {
        zombieKillsText.text = $"Zombie Kills: {zombieKills}";
    }
}
