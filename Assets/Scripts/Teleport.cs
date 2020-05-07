using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class Teleport: MonoBehaviour
{
    public GameObject player, teleport;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("player"))
        {
            player.transform.position = teleport.transform.position;
        }
    }
}
