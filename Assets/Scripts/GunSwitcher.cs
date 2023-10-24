using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunSwitcher : MonoBehaviour
{
    [SerializeField] Transform equipPosition;
    [SerializeField] float distance = 10f;
    GameObject currentWeapon;
    GameObject wp;

    bool canGrab;

    private void Update() {
        CheckWeapons();

        if (canGrab) {
            if (Input.GetKeyDown(KeyCode.Q)) {
                if (currentWeapon != null) 
                    Drop();
                PickUp();    
            }
        }

        if (currentWeapon != null) {
            if (Input.GetKeyDown(KeyCode.R)) {
                Drop();
            }
        }
    }

    private void CheckWeapons() {
        RaycastHit hit;

        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, distance)) {
            if (hit.transform.tag == "Gun") {
                canGrab = true;
                wp = hit.transform.gameObject;
            }
        }
        else {
            canGrab = false;
        }
    }

    private void PickUp() {
        currentWeapon = wp;
        currentWeapon.transform.position = equipPosition.position;
        currentWeapon.transform.parent = equipPosition;
        currentWeapon.transform.localEulerAngles = new Vector3(0f, 180f, 0f);
        currentWeapon.GetComponent<Rigidbody>().isKinematic = true;

    }

    private void Drop() {
        currentWeapon.transform.parent = null;
        currentWeapon.GetComponent<Rigidbody>().isKinematic = false;
        currentWeapon = null;


    }
}
