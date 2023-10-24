using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovement : MonoBehaviour
{
    [SerializeField] private float lifeTime = 3f;
    [SerializeField] private float speed = 10;
    private Vector3 direction;

    private void Start()
    {
        direction = -transform.forward;
        Destroy(gameObject, lifeTime);
    }
    private void Update()
    {
        transform.position += direction * speed * Time.deltaTime;
    }
}
