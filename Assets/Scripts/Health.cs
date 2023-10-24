using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Health : MonoBehaviour
{
    int health;
    [SerializeField] TextMeshProUGUI hp;
    [SerializeField] GameObject bullet;
    [SerializeField] GameObject gunStart;
    [SerializeField] GameObject gameOver;
    [SerializeField] Animator cameraAnim;
    [SerializeField] GameObject gun;
    [SerializeField] GameObject gunShotParticle;


    private AudioSource gunShot;

    [SerializeField] int ammo = 50;
    [SerializeField] TextMeshProUGUI ammoText;

    void Start()
    {
        ChangeHealth(100);
    }

    
    void Update()
    {
        if (ammo == 0 ) return;
        else {
            if (Input.GetMouseButtonDown(0)) {
                GameObject buf = Instantiate(bullet);
                buf.GetComponent<Bullet>().SetDirection(transform.forward);
                buf.transform.position = gunStart.transform.position;
                buf.transform.rotation = transform.rotation;
                gunShot = buf.GetComponent<AudioSource>();
                gunShot.pitch = (Random.Range(0.6f, 0.9f));
                gunShot.Play();
                Instantiate(gunShotParticle, transform.position, gunShotParticle.transform.rotation);
                ammo -= 1;
                ammoText.text = "AMMO: " + ammo.ToString() + "/50";
            }
        }
        

        if (Input.GetKeyDown(KeyCode.Mouse1)) {
            cameraAnim.SetBool("Aim", true);
            gun.GetComponent<Animator>().Play("gunShot1");

        }

        if (Input.GetKeyUp(KeyCode.Mouse1)) {
            cameraAnim.SetBool("Aim", false);
            gun.GetComponent<Animator>().Play("New State");
        }
    }

    public void ChangeHealth(int count) {
        health = health + count;
        hp.text = "HP: " + health;

        if (health <= 0) {
            gameOver.SetActive(true);
            GetComponent<Look>().enabled = false;
            Cursor.lockState = CursorLockMode.None;
        }
    }

    private void OnTriggerEnter(Collider collider) {
        if (collider.CompareTag("ammo")) {
            ammo += 10;
            ammoText.text = "AMMO: " + ammo.ToString() + "/50";

            Destroy(collider.gameObject);
        }
    }
}
