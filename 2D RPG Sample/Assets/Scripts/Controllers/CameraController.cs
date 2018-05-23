using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public Transform player;
    public float southMapEdge, westMapEdge, northMapEdge, eastMapEdge;


    void Update()
    {

        transform.position = new Vector3(
            Mathf.Clamp(player.position.x, westMapEdge, eastMapEdge),
            Mathf.Clamp(player.position.y, southMapEdge, northMapEdge),
            transform.position.z);

    }
}
