using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedBarrel : MonoBehaviour
{
    [SerializeField] float radius;
    [SerializeField] GameObject explosion;


    public void Boom()
    {
        GameObject player = FindObjectOfType<Health>().gameObject;
        if (Vector3.Distance(transform.position, player.transform.position) < radius)
        {
            player.GetComponent<Health>().ChangeHealth(-80);
        }
        Instantiate(explosion);
        Destroy(gameObject);
    }
}
