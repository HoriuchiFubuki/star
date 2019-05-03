using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public GameGenerator gameGenerator;
    public GameObject[] particles;
    public float defPosZ;
    public int maxCount;
    public float maxDistanse;
    private Vector3 oldPos;
    private GameObject player;
    private float target;
    private Vector3 targetV3;
    private float move;
    private int saveCount;
    private int count;
    private ParticleSystem particle;

    void Start()
    {
        saveCount = 0;
        count = 0;
        transform.position = new Vector3(transform.position.x, transform.position.y, defPosZ);
        oldPos = Vector3.zero;
        player = GameObject.FindWithTag("Player");
        particle = particles[0].GetComponent<ParticleSystem>();
    }
    void Update()
    {
        Vector3 v3 = player.transform.position - oldPos;
        targetV3 = new Vector3(player.transform.position.x / (saveCount + 1), player.transform.position.y / (saveCount + 1), transform.position.z);
        transform.position += new Vector3((targetV3.x - transform.position.x) / (saveCount + 1), (targetV3.y - transform.position.y) / (saveCount + 1), 0);
        oldPos = player.transform.position;
        transform.LookAt(player.transform.position);

        int star = gameGenerator.GetComponent<GameGenerator>().star;
        int[] changeCount = gameGenerator.musicChangeCount;
        int nowCount = 0;

        if (count == maxCount)
        {
            for (int i = 0; i < changeCount.Length; i++)
            {
                if (star >= changeCount[i])
                {
                    nowCount = i;
                }
                else
                {
                    break;
                }
            }
            if (nowCount != saveCount)
            {
                if (nowCount > saveCount)
                {
                    particle = particles[0].GetComponent<ParticleSystem>();
                }
                else
                {
                    particle = particles[1].GetComponent<ParticleSystem>();
                }
                if (changeCount[nowCount] == 0)
                    target = defPosZ;
                else
                    target = (maxDistanse / changeCount.Length * (nowCount + 1));
                move = target - transform.position.z;
                saveCount = nowCount;
                count = 0;
                particle.Play();
            }
            else
            {
                particle.Stop();
            }
        }
        else if (count < maxCount)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + move / maxCount);
            count++;
        }
    }
}
