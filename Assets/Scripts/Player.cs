using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build;
using UnityEngine;
using UnityEngine.Experimental.Rendering;

public class Player : MonoBehaviour
{
    Vector3 Rebirth, Direction;
    Rigidbody rbd;
    public GameObject Respawn, Check1, Check2, Mbullet, Gun, Boss;
    public float fuerza, fuerzaT, vel, vel2, coins, Vel_bullet, rango;
    float aux, x, z, i;
    bool jump = false;
    public bool fire = false;
    // Start is called before the first frame update
    void Start()
    {
        aux = vel;
        rbd = GetComponent<Rigidbody>();
        Rebirth = Respawn.transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (jump)
            {
                i = 0;
            }
            i++;
            if (i <= 2)
            {
                rbd.AddForce(new Vector3(0, 1, 0) * fuerza, ForceMode.Impulse);
                jump = false;
            }
        }
        x = Input.GetAxis("Horizontal");
        z = Input.GetAxis("Vertical");
        rbd.velocity = new Vector3(x * vel, rbd.velocity.y, z * vel);

        if (transform.position.y <= -3)
        {
            rebirth(Rebirth); 
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            vel = vel2;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            vel = aux;
        }

        Direction = (Boss.transform.position - Gun.transform.position);
        if (Direction.magnitude <= rango)
        {
            Gun.transform.forward = Direction.normalized;
        }

        if (Input.GetKeyDown(KeyCode.X) && fire == true)
        {
            MBullets();
        }
    }
    
    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("Trampolin"))
        {
            rbd.AddForce(new Vector3(0, 1, 0) * fuerzaT, ForceMode.Impulse);
        }

        if (col.gameObject.CompareTag("Platform") || col.gameObject.CompareTag("Checkpoint") || col.gameObject.CompareTag("Checkpoint2"))
        {
            jump = true;
        }

        if (col.gameObject.CompareTag("Checkpoint"))
        {
            Rebirth = Check1.transform.position;
        }

        if (col.gameObject.CompareTag("Checkpoint2"))
        {
            Rebirth = Check2.transform.position;
        }

        if (col.gameObject.CompareTag("Ball"))
        {
            rebirth(Rebirth);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin"))
        {
            coins++;
            Destroy(other.gameObject);
        }

        if (other.CompareTag("Supercoin"))
        {
            coins += 10;
            Destroy(other.gameObject);
        }

        if (other.CompareTag("Bullet"))
        {
            rebirth(Rebirth);
        }

        if (other.CompareTag("BBullet"))
        {
            rebirth(Rebirth);
        }

        if (other.CompareTag("Gun"))
        {
            fire = true;
            Destroy(other.gameObject);
        }
    }
    void rebirth(Vector3 Posicion)
    {
       transform.position = Posicion; 
    }

    void MBullets()
    {
        GameObject temp_Mbullet = Instantiate(Mbullet, Gun.transform.position, Quaternion.identity);
        temp_Mbullet.transform.up = Direction.normalized;
        temp_Mbullet.GetComponent<Rigidbody>().velocity = Direction.normalized * Vel_bullet;
    }
}
