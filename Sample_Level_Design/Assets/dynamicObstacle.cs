using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dynamicObstacle : MonoBehaviour
{
    public Vector3[] destination;
    public float obs_speed;
    public int des_index = 0;
    public Vector3 endpos;

    public
    // Start is called before the first frame update
    void Start()
    {
        endpos = destination[0];
    }

    // Update is called once per frame
    void Update()
    {
        MoveDir();
    }

    public void MoveDir()
    {
        if (transform.position == endpos)
        {
            des_index++;
            if (des_index >= destination.Length)
            {
                des_index = 0;
            }

            endpos = destination[des_index];
        }
        else transform.position= Vector3.MoveTowards(transform.position,endpos,obs_speed*Time.deltaTime);
    }
}
