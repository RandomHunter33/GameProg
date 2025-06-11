using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public Vector3 HitPoint;
    private float time = 0;

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, HitPoint, 50 * Time.deltaTime);

        time += Time.deltaTime;

        if (time > 2)
        {
            Collider[] colide = Physics.OverlapSphere(transform.position, 5f);

            foreach (Collider c in colide)
            {
                Debug.Log("hit");
                if (c.gameObject.tag == "Creep")
                {
                    c.GetComponent<Creep>().health -= 5;
                }
                if (c.gameObject.tag == "Creep2")
                {
                    c.GetComponent<Creep2>().health -= 5;
                }

            }
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Creep" || other.gameObject.tag == "Creep2")
        {
            Collider[] colide = Physics.OverlapSphere(transform.position, 5f);

            foreach (Collider c in colide)
            {
                Debug.Log("hit");
                if (c.gameObject.tag == "Creep")
                {
                    c.GetComponent<Creep>().health -=5;
                }
                if (c.gameObject.tag == "Creep2")
                {
                    c.GetComponent<Creep2>().health -= 5;
                }
            }
            Destroy(this.gameObject);
        }
    }
}
