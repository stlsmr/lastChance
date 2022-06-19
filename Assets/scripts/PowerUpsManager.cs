using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpsManager : MonoBehaviour
{
    private bool doublePoints;
    private bool safeMode;

    private bool powerUpActive;

    private float powerUpLenghtCounter;

    private ScoreManager theScoreManager;
    private PlatformGenerator thePlatformGenerator;
    private GameManager theGameManager;

    private float normalPointsPerSecond;
    private float spikeRate;

    private PlatformDestructor[] spikeList;

    
    // Start is called before the first frame update
    void Start()
    {
        thePlatformGenerator = FindObjectOfType<PlatformGenerator>();
        theScoreManager = FindObjectOfType<ScoreManager>();
        theGameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
    if(powerUpActive)
        {
            powerUpLenghtCounter -= Time.deltaTime;

            if (theGameManager.powerupReset)
            {
                powerUpLenghtCounter = 0;
                theGameManager.powerupReset = false;
            }

            if (doublePoints)
            {
                theScoreManager.pointsPerSecond = normalPointsPerSecond * 2;
                theScoreManager.shouldDouble = true;
            }

            if (safeMode)
            {
                thePlatformGenerator.randomSpikeThreshold = 0f;
            }

            if (powerUpLenghtCounter<=0)
            {
                theScoreManager.pointsPerSecond = normalPointsPerSecond;
                theScoreManager.shouldDouble = false;
                thePlatformGenerator.randomSpikeThreshold = spikeRate;

                powerUpActive = false;
            }
        }    
    }

    public void ActivatePowerup(bool points, bool safe, float time)
    {
        doublePoints = points;
        safeMode = safe;
        powerUpLenghtCounter = time;

        normalPointsPerSecond = theScoreManager.pointsPerSecond;
        spikeRate = thePlatformGenerator.randomCoinThresHold;

        if (safeMode)
        {
            spikeList = FindObjectsOfType<PlatformDestructor>();
            for (int i = 0; i < spikeList.Length; i++)
            {
                if (spikeList[i].gameObject.name.Contains("spikes"))
                {
                    spikeList[i].gameObject.SetActive(false);
                }
            }
        }

        powerUpActive = true;
    }
}
