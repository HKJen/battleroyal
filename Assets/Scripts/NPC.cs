using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    List<string> greets = new List<string>();

    
    void Start()
    {
        greets.Add("Hey!");
        greets.Add("What can i help you with?");
        greets.Add("Where do all these punks come from?!");

    }

    
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider collider) {
        if(collider.CompareTag("Player")) {
            int index = Random.Range(0, greets.Count);

            print(greets[index]);
        }
        
    }
}
