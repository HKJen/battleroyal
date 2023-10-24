using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpawner : MonoBehaviour
{
    [SerializeField] GameObject spawner;
    //[SerializeField] float radius = 10;
    [SerializeField] GameObject cube;
    float timer = 0;
    float cooldown = 1;


    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > cooldown) {
            timer = 0;
            GameObject buffer = Instantiate(spawner, transform);
/*
            float x = Random.Range(-radius, radius);
            float z = Random.Range(-radius, radius);

*/
            buffer.transform.position = cube.transform.position;

        }
    }
}

