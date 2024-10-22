using UnityEngine;
using UnityEngine.UI;

public class PlayerInventory : MonoBehaviour
{
    // Bandage count
    public int bandageCount = 0;

    // Player health variables
    public int playerHealth = 50;  // Current health
    public int maxHealth = 100;    // Maximum health
    public int healAmount = 25;    // Amount to heal with one bandage

    // UI elements
    public Text bandageText;        // Reference to UI Text element that shows bandage count
    public Slider healthBarSlider;  // Reference to UI Slider element for health bar

    // Audio feedback (optional)
    public AudioClip pickupSound;  // Sound to play when a bandage is picked up
    public AudioClip healSound;    // Sound to play when a bandage is used

    // Start is called before the first frame update
    void Start()
    {
        // Initialize the health bar to match the player's current health
        healthBarSlider.maxValue = maxHealth;
        healthBarSlider.value = playerHealth;

        // Update the bandage UI at the start
        UpdateBandageUI();
    }

    // Method to add a bandage to inventory
    public void AddBandage()
    {
        bandageCount++;
        UpdateBandageUI();
        if (pickupSound != null)
        {
            AudioSource.PlayClipAtPoint(pickupSound, transform.position);
        }
    }

    // Method to use a bandage
    public bool UseBandage()
    {
        if (bandageCount > 0)
        {
            bandageCount--;
            HealPlayer();
            UpdateBandageUI();
            if (healSound != null)
            {
                AudioSource.PlayClipAtPoint(healSound, transform.position);
            }
            return true;
        }
        return false;
    }

    // Method to heal the player
    private void HealPlayer()
    {
        playerHealth += healAmount;
        playerHealth = Mathf.Min(playerHealth, maxHealth);  // Cap at max health

        // Update the health bar UI
        UpdateHealthBar();
        
        Debug.Log("Player healed! Current health: " + playerHealth);
    }

    // Update the health bar to reflect current player health
    private void UpdateHealthBar()
    {
        if (healthBarSlider != null)
        {
            healthBarSlider.value = playerHealth;
        }
    }

    // Update the bandage count in the UI
    private void UpdateBandageUI()
    {
        if (bandageText != null)
        {
            bandageText.text = "Bandages: " + bandageCount;
        }
    }

    // Player input to use bandage
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            bool used = UseBandage();
            if (!used)
            {
                Debug.Log("No bandages available!");
            }
        }
    }
}
