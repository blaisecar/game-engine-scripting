using mazegame;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace mazegame
{
    public class LavaScript : MonoBehaviour
    {
        public GameHandler GH;

        // Start is called before the first frame update
        void Start()
        {
            GH = GameObject.Find("Canvas").GetComponent<GameHandler>();
        }

        // Update is called once per frame
        void Update()
        {

        }

        public int damageAmount = 1;
        public float damageInterval = 1f;
        public bool canDamage = true;
        private void OnTriggerStay(Collider other)
        {
            
            if (other.CompareTag("Player")) 
            {
                if (canDamage)
                {
                    PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
                    if (playerHealth != null)
                    {
                        playerHealth.TakeDamage(damageAmount); 
                    }
                    canDamage = false; 
                    Invoke("ResetDamageFlag", damageInterval); 
                }
            }
        }

        private void ResetDamageFlag()
        {
            canDamage = true; 
        }
    }
}
