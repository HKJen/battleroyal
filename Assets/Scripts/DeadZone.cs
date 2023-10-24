using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZone : MonoBehaviour
{
    [SerializeField] float waitCooldown;
    [SerializeField] float moveCooldown;
    float waitTime;
    float moveTime;
    [SerializeField] float sizeSpeed;


    void Start()
    {
        
    }

    
    void Update()
    {
        waitTime +=Time.deltaTime;

        if (waitTime > waitCooldown) {
            moveTime += Time.deltaTime;
            transform.localScale -= new Vector3(sizeSpeed, 0, sizeSpeed);
            if (moveTime > moveCooldown) {
                waitTime = 0;
                moveTime = 0;

            }
        }
    }

    private void OnTriggerExit (Collider collider) {
        if (collider.CompareTag("Player")) {
            collider.GetComponent<Health>().ChangeHealth(-1000);
        }

        if (collider.CompareTag("Enemy")) {
            Destroy(collider.gameObject);
        }
    }
}
