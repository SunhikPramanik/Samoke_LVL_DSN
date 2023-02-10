using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextBrickBreakable : MonoBehaviour
{
    public GameObject nextBrick;
    public bool isBreaking;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void Update()
    {
        if (isBreaking)
            StartCoroutine(Break());
    }
    IEnumerator Break()
    {
        yield return new WaitForSeconds(0.0f);
        nextBrick.GetComponent<Rigidbody>().isKinematic = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") == true)
        {
            isBreaking = true;
        }
        else isBreaking = false;
    }
}
