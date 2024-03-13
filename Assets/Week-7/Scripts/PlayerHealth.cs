using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace mazegame
{
    public class PlayerHealth : MonoBehaviour
    {
        public int maxHealth = 100;
        public int currentHealth;
        public GameHandler GH;

        private void Start()
        {
            currentHealth = maxHealth;
            GH = GameObject.Find("Canvas").GetComponent<GameHandler>();
        }

        public void TakeDamage(int damageAmount)
        {
            currentHealth -= damageAmount;
            Debug.Log("Player took " + damageAmount + " damage. Current health: " + currentHealth);

           
        }
        public int GetCurrentHealth()
        {
            return currentHealth;
        }
    }
}
