using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace mazegame
{
    public class EnemyCollisionDemo : MonoBehaviour
    {
        public Material materialDamaged;
        public Material materialNormal;
        private MeshRenderer mr;

        private void Awake()
        {
            mr = GetComponent<MeshRenderer>();
        }


        private void OnTriggerEnter(Collider other)
        {

            mr.material = materialDamaged;
            DOVirtual.DelayedCall(0.1f, () =>
            {
                mr.material = materialNormal;
            });
        }

        private void OnTriggerStay(Collider other)
        {

        }

        private void OnTriggerExit(Collider other)
        {

        }


        //for physics vvvv
        private void OnCollisionEnter(Collision collision)
        {

        }

    }
}