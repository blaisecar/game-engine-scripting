using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace mazegame
{
    public class GameHandler : MonoBehaviour
    {


        public TextMeshProUGUI CoinText;
        public TextMeshProUGUI CoinText1;
        public TextMeshProUGUI KeyText;
        public TextMeshProUGUI HealText;
        public TextMeshProUGUI CoinText2;
        public PlayerHealth playerHealth;

        public int coins = 0;
        public int keys = 0;
        public bool doorOpen = false;


        private void Start()
        {
            HealText = GetComponent<TextMeshProUGUI>();
           

            // Ensure the PlayerHealth reference is set
            if (playerHealth == null)
            {
                Debug.LogWarning("PlayerHealth reference not set in HealthText script.");
                return;
            }
           
        }
        // Update is called once per frame
        void Update()
        {
            KeyText.text = "Keys : " + keys;
            CoinText.text = "Coins : " + coins;
            //HealText.text = "Health: " + playerHealth.GetCurrentHealth();
        }
    }
}