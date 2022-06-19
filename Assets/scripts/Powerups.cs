using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerups : MonoBehaviour
{

    public bool doublePoints;
    public bool safeMode;

    public float powerupLenght;

    private PowerUpsManager thePowerUpManager;

    public Sprite[] powerUpSprites;
    // Start is called before the first frame update
    void Start()
    {
        thePowerUpManager = FindObjectOfType<PowerUpsManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Awake()
    {
        int powerupSelector = Random.Range(0, 2);
        switch (powerupSelector)
        {
            case 0: doublePoints = true;
                break;
            case 1: safeMode = true;
                break;
        }
        GetComponent<SpriteRenderer>().sprite = powerUpSprites[powerupSelector];
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.name == "Player")
        {
            thePowerUpManager.ActivatePowerup(doublePoints, safeMode, powerupLenght);
        }
        gameObject.SetActive(false);
    }
}
