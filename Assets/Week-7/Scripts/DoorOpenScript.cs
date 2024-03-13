using mazegame;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace mazegame
{
    public class DoorOpenScript : MonoBehaviour
    {
        public GameHandler GH;
        public float doorspeed = 0.5f;
        // Start is called before the first frame update
        void Start()
        {
            GH = GameObject.Find("Canvas").GetComponent<GameHandler>();
        }

        // Update is called once per frame
        void Update()
        {
            if (GH.doorOpen)
            {
                GH.doorOpen = false;
                GH.keys--;

                for (int i = 0; i < 900; i++)
                {
                    transform.Translate(Vector3.up * doorspeed * Time.deltaTime);
                }

            }
        }
    }
}
