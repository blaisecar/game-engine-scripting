using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Awake()
    {
        Destroy(gameObject, 10f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    public void Damage()
    {
        Debug.Log("The Bullet damaged me!");    }
    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        if(other.transform.name == "Enemy")
        {
           // other.GetComponent<EnemyCollisionDemo>().Damage();
        }

    }
}
