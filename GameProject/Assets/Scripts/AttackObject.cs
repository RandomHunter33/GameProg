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

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Creep")
        {
            other.GetComponent<Creep>().health --;
        }
    }
}
