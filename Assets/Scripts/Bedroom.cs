using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bedroom : MonoBehaviour
{
    public GameObject playerPrefab;

    void Start()
    {
        GameObject player;

        

        if (!FindObjectOfType<Player>())
        {
            player = Instantiate(playerPrefab);
            player.transform.position = new Vector3(-3.6f, 0, 0);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
