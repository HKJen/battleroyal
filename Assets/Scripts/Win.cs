using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Win : MonoBehaviour
{
    //win
    GameObject[] enemies;
    public static int enemyCount;
    [SerializeField] GameObject winScreen;
    
    void Start()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        enemyCount = enemies.Length;
    }

    
    void Update()
    {
        print(enemyCount);
        if (enemyCount <= 0) {
            print(enemyCount);
            winScreen.SetActive(true);
            GetComponent<Move>().enabled = false;
            GetComponent<Look>().enabled = false;
            Cursor.lockState = CursorLockMode.None;
        }
    }

    public void OnDeath() {
        enemyCount -= 1;
    }
}
