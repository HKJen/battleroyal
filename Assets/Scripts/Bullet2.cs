using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet2 : MonoBehaviour
{
    [SerializeField] int bulletCount;
    [SerializeField] float spreadAngle;
    [SerializeField] GameObject bullet;
    [SerializeField] float speed;
    [SerializeField] Transform gunStart;
    List<Quaternion> bullets;
    
    void Awake()
    {
        bullets = new List<Quaternion>(bulletCount);
        for (int i = 0; i < bulletCount; i++) {
            bullets.Add(Quaternion.Euler(Vector3.zero));
        }
    }

    
    void Update()
    {
        if(Input.GetButtonDown("Fire1")) {
            Fire();
        }
    }

    private void Fire() {
        int i = 0;
        foreach(Quaternion quat in bullets) {
            bullets[i] = Random.rotation;
            GameObject buf = Instantiate(bullet, gunStart.position, gunStart.rotation);
            buf.transform.rotation = Quaternion.RotateTowards(buf.transform.rotation, bullets[i], spreadAngle);
            buf.GetComponent<Rigidbody>().AddForce(buf.transform.right * speed);
            i++;

        }
    }
}
