using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playermovement : MonoBehaviour
{
    public float mov_speed;
    public float jump_speed;
    private Vector3 dir;
    private Rigidbody rb;
    public bool onGround=true;
    // Start is called before the first frame update
    void Start()
    {
        dir = Vector3.right;
        rb=GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(this.transform.position.y<-1)
        {
            SceneManager.LoadScene(0);
        }
        /*this.transform.Translate(dir * mov_speed * Time.deltaTime);
        if ((dir == Vector3.right) && Input.GetKeyDown(KeyCode.D))
        {
            dir = Vector3.back;
        }
        if ((dir == Vector3.forward)&&Input.GetKeyDown(KeyCode.D))
        {
            dir = Vector3.right;
        }
        if ((dir == Vector3.right) && Input.GetKeyDown(KeyCode.A))
        {
            dir = Vector3.forward;
        }
        if ((dir == Vector3.back) && Input.GetKeyDown(KeyCode.A))
        {
            dir = Vector3.right;
        }*/
        if(Input.GetKey(KeyCode.A))
        {
            this.transform.Translate(Vector3.forward * mov_speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            this.transform.Translate(Vector3.back * mov_speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            this.transform.Translate(Vector3.left * mov_speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.W))
        {
            this.transform.Translate(Vector3.right * mov_speed * Time.deltaTime);
        }
        if (Input.GetKeyDown(KeyCode.Space) && onGround==true)
        {
            rb.AddForce(Vector3.up * jump_speed, ForceMode.Impulse);
            onGround= false;
        }
        if (this.transform.position.x > 39)
        {
            SceneManager.LoadScene(1);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("ground")==true)
        {
            onGround= true;
        }
        if (collision.gameObject.CompareTag("Enemy") == true)
        {
            SceneManager.LoadScene(0);
        }
    }
}
