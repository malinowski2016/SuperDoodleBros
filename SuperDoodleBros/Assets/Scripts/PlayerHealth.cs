using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour {

    public int startingHealth = 100;
    public int currentHealth;

    bool damaged;
    //public Slider healthSlider;

    // Use this for initialization
    void Start () {
        currentHealth = startingHealth;
	}

    // Update is called once per frame
    void Update()
    {
        //if (damaged){}

        // Reset the damaged flag.
        damaged = false;
    }


    public void TakeDamage(int amount)
    {
        // Set the damaged flag so the screen will flash.
        damaged = true;

        // Reduce the current health by the damage amount.
        currentHealth -= amount;

        // Set the health bar's value to the current health.
        //healthSlider.value = currentHealth;


        // If the player has lost all it's health and the death flag hasn't been set yet...
        /*if (currentHealth <= 0 && !isDead)
        {
            // ... it should die.
            Death();
        }*/
    }
}
