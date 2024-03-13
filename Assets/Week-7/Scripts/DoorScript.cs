using mazegame;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace mazegame
{

    public class DoorScript : MonoBehaviour
    {
        public GameHandler GH;
        public AudioClip doorSound;
        
        
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
            GH.doorOpen = true;
            AudioSource.PlayClipAtPoint(doorSound, transform.position);
            Destroy(gameObject);
        }
    }
}
