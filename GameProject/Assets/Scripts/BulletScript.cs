using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Creep")
        {
            other.GetComponent<Creep>().health--; 
            Destroy(this.gameObject);
        }
        if (other.gameObject.tag == "Creep2")
        {
            other.GetComponent<Creep2>().health--;
            Destroy(this.gameObject);
        }
    }
}
