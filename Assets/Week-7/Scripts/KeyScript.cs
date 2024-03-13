using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace mazegame
{
    public class KeyScript : MonoBehaviour
    {
        public GameHandler GH;
        public AudioClip keySound;
        // Start is called before the first frame update
        void Start()
        {
            GH = GameObject.Find("Canvas").GetComponent<GameHandler>();
        }

        // Update is called once per frame
        void Update()
        {

        }
        private void OnTriggerEnter(Collider other)
        {
            GH.keys++;
            AudioSource.PlayClipAtPoint(keySound, transform.position);
            Destroy(gameObject);
        }
    }
}