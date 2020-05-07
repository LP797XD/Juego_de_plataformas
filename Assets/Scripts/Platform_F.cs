using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform_F : MonoBehaviour
{
    Rigidbody rbd;
    public GameObject Pos1;
    // Start is called before the first frame update
    void Start()
    {
        rbd = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator tiempo_f()
    {
        yield return new WaitForSeconds(1);
        rbd.isKinematic = false;
        yield return new WaitForSeconds(4);
        transform.position = Pos1.transform.position;
        rbd.isKinematic = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("player"))
        {
            StartCoroutine(tiempo_f());
        }
    }
}