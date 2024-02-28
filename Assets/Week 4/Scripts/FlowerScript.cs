using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Timers;
using static UnityEngine.RuleTile.TilingRuleOutput;


public class FlowerScript : MonoBehaviour
{ 
    [SerializeField] private float gainNectarTime = 20;
[SerializeField] private float plantDeathTime = 60;
[SerializeField] private float timer = 0;

public bool hasNectar = true;
[SerializeField] private int timesGained = 0;
[SerializeField] private GameObject flower;

[SerializeField] private AudioSource flowerDeathSFX;

[SerializeField] private SpriteRenderer spriteRenderer;

// Start is called before the first frame update
void Start()
{
    setNecterToTrue();
}

// Update is called once per frame
void Update()
{
    if (!hasNectar)
    {
        spriteRenderer.color = new Color32(125, 125, 125, 255);
        if (timer < gainNectarTime)
        {
            timer = timer + Time.deltaTime;
        }
        else
        {
            timer = 0;
            setNecterToTrue();
        }
    }

    if (hasNectar)
    {
        if (timer < plantDeathTime)
        {
            timer = timer + Time.deltaTime;
        }
        else
        {
            spriteRenderer.color = new Color32(125, 0, 0, 255);
            flowerDeathSFX.Play();
            Destroy(gameObject, flowerDeathSFX.clip.length);
        }
    }
}

void setNecterToTrue()
{
    hasNectar = true;
    spriteRenderer.color = Color.white;
    timer = 0;
}

public void GetNectar()
{
    hasNectar = false;
    timesGained++;
    timer = 0;

    if (timesGained >= 3)
    {
        Vector3 SpawnPosition = new Vector3(Random.Range(-8, 8), Random.Range(-3, 5), 0);
        timesGained = 0;
        Instantiate(flower, SpawnPosition, transform.rotation);
    }
}
}

/*{

    public bool hasNectar = false;
    public float countdownTime = 10f; // Initial countdown time in seconds
    private float currentTime; // Current time left in the countdown
    private bool isTimerRunning = true; // Flag to check if the timer is running

    [SerializeField] private GameObject flower;

    [SerializeField] private SpriteRenderer spriteRenderer;

    void Start()
    {
        currentTime = countdownTime; // Set the initial time
        NectarTrue();
    }
   


    // Update is called once per frame
    void Update()
    {
        if (isTimerRunning)
        {
            // Decrease the current time every frame
            currentTime -= Time.deltaTime;

            // If the timer reaches zero or less, stop the timer and display a message
            if (currentTime <= 0f)
            {
                isTimerRunning = false;
                currentTime = 0f; // Ensure the current time doesn't go negative
                Debug.Log("Timer has run out!");
                NectarFalse();
}
        }
    }

    public void NectarTrue()
    {
        hasNectar = true;
        spriteRenderer.color = Color.white;
        isTimerRunning = true;
    }

    public void NectarFalse()
    {
        hasNectar = false;
        spriteRenderer.color = Color.black;
        isTimerRunning = false;
    }
}*/


