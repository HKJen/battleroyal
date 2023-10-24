using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject spawner;
    [SerializeField] GameObject spawn;

    [SerializeField] float radius = 10f;
    float timer = 0;
    float cooldown = 1;
    
    void Start()
    {
        
    }

    
    void Update()
    {
        timer += Time.deltaTime;
        if(timer > cooldown) {
            timer = 0;
            GameObject buffer  = Instantiate(spawner, transform.position, transform.rotation);

            float x = Random.Range(-radius, radius);
            float z = Random.Range(-radius, radius);

            buffer.transform.position = spawn.transform.position + new Vector3(x, 0, z);
        }
    }
}
