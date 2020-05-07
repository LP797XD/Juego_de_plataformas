using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

public class Platform_M4 : MonoBehaviour
{
    public GameObject pos1,pos2,pos3,pos4;
    public float velocidad;
    public int i;
    // Start is called before the first frame update
    private void FixedUpdate()
    {
        switch (i)
        {
            case 1:
                transform.position = (Vector3.MoveTowards(transform.position, pos1.transform.position, velocidad * Time.fixedDeltaTime));
                break;
            case 2:
                transform.position = (Vector3.MoveTowards(transform.position, pos2.transform.position, velocidad * Time.fixedDeltaTime));
                break;
            case 3:
                transform.position = (Vector3.MoveTowards(transform.position, pos3.transform.position, velocidad * Time.fixedDeltaTime));
                break;
            case 4:
                transform.position = (Vector3.MoveTowards(transform.position, pos4.transform.position, velocidad * Time.fixedDeltaTime));
                break;
        }

        if (transform.position == pos4.transform.position) i = 1;
        else if (transform.position == pos1.transform.position) i = 2;
        else if (transform.position == pos2.transform.position) i = 3;
        else if (transform.position == pos3.transform.position) i = 4;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("player"))
        {
            collision.transform.parent = transform;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("player"))
        {
            collision.transform.parent = null;
        }
    }
}

