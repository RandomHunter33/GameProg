using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public Camera Camera;
    public GameObject Player;

    public GameObject Creep1;
    public GameObject Creep2;
    public int Lives = 3;
    private int level = 1;
    private int ttlC1 = 1;
    private int ttlC2 = 0;
    public int CurrC1;
    public int CurrC2;

    private void Update()
    {
        Vector3 cameraPosition = Camera.transform.position;
        cameraPosition.x = Player.transform.position.x - 7.5f;
        cameraPosition.z = Player.transform.position.z - 7.5f;

        Camera.transform.position = cameraPosition;
        
        if (CurrC1 < 1 && CurrC2 < 1) // unity initialize public int as 0, so this is a work around
        {
            level++; Debug.Log(level);
            newLevel();
        }
    }

    private void newLevel()
    {
        if (level < 4)
        {
            ttlC1 += 1;
        }
        else if (level < 7)
        {
            ttlC1 += 2;
            ttlC2 += 1;
        }
        else if (level < 10)
        {
            ttlC1 += 3;
            ttlC2 += 2;
        }
        else
        {
            ttlC1 += 3;
            ttlC2 += 3;
        }

        CurrC1 = ttlC1;
        CurrC2 = ttlC2;

        for (int i = 0; i < ttlC1; i++)
        {
            int random = Random.Range(-5, 5);
            SpawnC1(new Vector3(i - 20, 2, 15 + random));
        }

        for (int i = 0; i < ttlC2; i++)
        {
            int random = Random.Range(-5, 5);
            SpawnC2(new Vector3(21 - i, 2, -15 + random));
        }
    }
    
    private void SpawnC1(Vector3 Coord)
    {
        GameObject temp = Instantiate(Creep1, Coord, Quaternion.Euler(0, 0, 0));
        temp.GetComponent<Creep>().CS = this.GetComponent<CameraScript>();
        temp.GetComponent<Creep>().targetObj = Player;
    }
    private void SpawnC2(Vector3 Coord)
    {
        GameObject temp = Instantiate(Creep2, Coord, Quaternion.Euler(0, 0, 0));
        temp.GetComponent<Creep2>().CS = this.GetComponent<CameraScript>();
        temp.GetComponent<Creep2>().targetObj = Player;
    }
}
