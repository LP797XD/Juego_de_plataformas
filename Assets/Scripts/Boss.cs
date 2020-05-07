using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public GameObject player, Bullet, canon;
    public float velocity_bullet, rango, hit_limit;
    public float hit = 0;
    Vector3 direction;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("BBullets", 4, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        direction = (player.transform.position - transform.position);
        if (direction.magnitude <= rango)
        {
            transform.forward = direction.normalized;
        }
        
        if (hit_limit == hit)
        {
            Destroy(gameObject);
        }
    }

    void BBullets()
    {
        if (direction.magnitude <= rango)
        {
            GameObject temp_bullet = Instantiate(Bullet, canon.transform.position, Quaternion.identity);
            temp_bullet.transform.up = direction.normalized;
            temp_bullet.GetComponent<Rigidbody>().velocity = direction.normalized * velocity_bullet;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if ((other.gameObject.CompareTag("MBullet")))
        {
            Destroy(other.gameObject);
            hit++;
        }
    }


}