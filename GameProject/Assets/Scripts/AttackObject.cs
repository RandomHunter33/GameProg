using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackObject : MonoBehaviour
{
    private float time = 0;

    private void Update()
    {
        time += Time.deltaTime;

        if (time > 0.5)
        {
            Destroy(this.gameObject);
        }
        
    }

    private void DamageCheck()
    {
        Collider[] colide = Physics.OverlapBox(transform.position, new Vector3(0.5f, 0.5f, 0.5f), transform.rotation); 

        foreach(Collider c in colide)
        {
            Debug.Log("hit");
            if (c.gameObject.tag == "Creep")
            {
                Debug.Log("hit2");
                c.GetComponent<Creep>().health--;
            }
            if (c.gameObject.tag == "Player")
            {
                Debug.Log("hit3");

            }
        }
    }
}
