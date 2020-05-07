using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    public int hit_limit;
    int hit = 0;
    // Start is called before the first frame update
    void Start()
    { 
    }
    // Update is called once per frame
    void Update()
    {
        if (hit_limit == hit)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bullet") || other.gameObject.CompareTag("BBullet") || (other.gameObject.CompareTag("MBullet")))
        {
            Destroy(other.gameObject);
            hit++;
        }
    }
}
