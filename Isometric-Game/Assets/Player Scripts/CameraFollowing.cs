using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowing : MonoBehaviour
{

    public Transform player;
    private Vector3 offset;

    [Range(0.01f,1.0f)]
    public float smoothFactor = 1;


    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - player.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newPosition = player.position + offset;
        transform.position = Vector3.Slerp(transform.position,newPosition,smoothFactor);
    }
}
