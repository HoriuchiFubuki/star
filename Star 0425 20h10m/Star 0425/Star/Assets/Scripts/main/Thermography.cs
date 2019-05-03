using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thermography : MonoBehaviour
{
    public GameObject thermographyOriginal;
    private GameObject thermography;
    bool coolTimeNow = false;
    int coolTimer = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!DebugPC.pc)
        {
            if (Input.GetMouseButtonDown(0) && !coolTimeNow)
            {
                thermography = Instantiate(thermographyOriginal, transform.position, Quaternion.identity) as GameObject;
                coolTimeNow = true;
            }
        }
        else
        {
            if (Input.GetMouseButtonDown(1) && !coolTimeNow)
            {
                thermography = Instantiate(thermographyOriginal, transform.position, Quaternion.identity) as GameObject;
                coolTimeNow = true;
            }
        }
        if (coolTimeNow)
        {
            coolTimer++;
            if (coolTimer > 120)
            {
                coolTimer = 0;
                coolTimeNow = false;
            }
        }
    }
}