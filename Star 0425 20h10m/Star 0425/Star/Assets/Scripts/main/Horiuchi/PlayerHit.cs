using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHit : MonoBehaviour
{
    public GameGenerator gameGenerator;

    // Start is called before the first frame update
    void Start()
    {

    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "DangerObject" && !other.gameObject.GetComponent<ThermographyHit>().thermographyHitNow)
        {
            if (SystemInfo.supportsVibration)
            {
                Handheld.Vibrate();
            }
            if (gameGenerator.GetComponent<GameGenerator>().star <= 0)
            {
                SceneManager.LoadScene("ResultScene");
            }
        }
    }
}
