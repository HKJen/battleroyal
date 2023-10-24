using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractUI : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] int area = 2;
    [SerializeField] GameObject interactUI;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, player.transform.position) < area) {
            interactUI.SetActive(true);

        } else {
            interactUI.SetActive(false);
        }
    }
}
