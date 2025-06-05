using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public Camera Camera;
    public GameObject Player;
    

    private void Update()
    {
        Vector3 cameraPosition = Camera.transform.position;
        cameraPosition.x = Player.transform.position.x - 7.5f;
        cameraPosition.z = Player.transform.position.z - 7.5f;

        Camera.transform.position = cameraPosition;
    }
    
}
