using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Week4
{
    public class Enemy : MonoBehaviour
    {
        public int health = 10;

        [SerializeField] private Player target;

        public void Damage(int amt)
        {
            health -= amt;
        }

        [ContextMenu("Attack")]

        void Attack()
        {
          
            
            target.Damage(3);
        }

        private Enemy FindNewTarget()
        {
            /*  Enemy[] enemies = GameObject.FindObjectsByType<Enemy>(FindObjectsSortMode.None);
              int randomIndex = Random.Range(0, enemies.Length);
              return enemies[randomIndex]; */

            GameObject enemyObj = GameObject.Find("Enemy");
            Enemy enemyComp = enemyObj.GetComponent<Enemy>();
            return enemyComp;

        }


        public int GetHealth()
        {
            return health;
        }
    }
}
