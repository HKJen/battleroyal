using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private GameObject player;
    CharacterController enemyContr;
    [SerializeField] float shootRadius = 15f;
    float timer = 0;
    float cooldown = 1;
    [SerializeField] GameObject gunStart;
    [SerializeField] GameObject bullet;
    [SerializeField] float findRadius = 30f;
    [SerializeField] float speed = 2f;
    Animator animEnemy;






    void Start()
    {
        player = FindObjectOfType<Health>().gameObject;
        enemyContr = GetComponent<CharacterController>();
        animEnemy = GetComponent<Animator>();
        
    }

    
    void Update()
    {
        if (Vector3.Distance(transform.position, player.transform.position) < shootRadius) {
            transform.LookAt(player.transform);
            timer += Time.deltaTime;
            if (timer > cooldown) {
                timer = 0;
                GameObject buf = Instantiate(bullet);
                buf.GetComponent<Bullet>().SetDirection(transform.forward);
                buf.transform.position = gunStart.transform.position;
                buf.transform.rotation = transform.rotation;
            }
        }

        else if (Vector3.Distance(transform.position, player.transform.position) < findRadius) {
            transform.LookAt(player.transform);
            GetComponent<CharacterController>().Move(transform.forward * Time.deltaTime * speed);
            if (enemyContr.velocity.magnitude > 0.001f) {
                animEnemy.SetBool("Run", true);
            }
            else animEnemy.SetBool("Run", false);
        }
        
        
    }

    
}
