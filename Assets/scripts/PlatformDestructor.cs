using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformDestructor : MonoBehaviour
{
    public GameObject platformDestructorPoint;
    // Start is called before the first frame update
    void Start()
    {
        platformDestructorPoint = GameObject.Find("PlatformDestructionPoint");
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < platformDestructorPoint.transform.position.x) {
            //Destroy(gameObject);
            gameObject.SetActive(false);
        }
    }
}
