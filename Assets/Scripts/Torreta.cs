using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torreta : MonoBehaviour
{
    public GameObject player, bullet, canon;
    public float velocity_bullet;
    public float rango;
    Vector3 direction;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Bullets", 2, 0.2f);
    }

    // Update is called once per frame
    void Update()
    {
        direction = (player.transform.position - transform.position);
        if (direction.magnitude <= rango)
        {
            transform.forward = direction.normalized;
        }
    }

    void Bullets()
    {
        if (direction.magnitude <= rango)
        {
            GameObject temp_bullet = Instantiate(bullet, canon.transform.position, Quaternion.identity);
            temp_bullet.transform.up = direction.normalized;
            temp_bullet.GetComponent<Rigidbody>().velocity = direction.normalized * velocity_bullet;
        }
    }

}
