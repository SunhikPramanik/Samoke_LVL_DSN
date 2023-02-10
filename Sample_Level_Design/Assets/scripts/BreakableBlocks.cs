using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BreakableBlocks : MonoBehaviour
{
    public bool isBreaking = false;
    public Rigidbody body;
    public float breakTime;
    // Start is called before the first frame update
    void Start()
    {
        body= GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isBreaking)
        StartCoroutine(Break());
    }
    IEnumerator Break()
    {
        yield return new WaitForSeconds(breakTime);
        body.isKinematic= false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") == true)
        {
            isBreaking = true;
        } else isBreaking= false;
    }
}
