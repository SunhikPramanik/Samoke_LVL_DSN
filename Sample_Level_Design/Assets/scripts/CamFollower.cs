using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollower : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset;
    public float smoothspeed = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        offset=this.transform.position-player.transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 desiredPosition=player.transform.position+offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothspeed);
        this.transform.position=smoothedPosition;
    }
}
