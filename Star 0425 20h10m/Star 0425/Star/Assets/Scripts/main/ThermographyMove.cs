using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThermographyMove : MonoBehaviour
{
    private GameObject player;
    Vector3 scale;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.forward * (30 / 60.0f);
        if (transform.localScale.x < 50)
        {
            transform.localScale = new Vector3(transform.localScale.x * 1.2f, transform.localScale.y * 1.2f, 1.0f);
        }
        if (transform.position.z > 50)
        {
            Destroy(gameObject);
        }
    }
}
