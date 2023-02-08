using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playermovement : MonoBehaviour
{
    public float mov_speed=2;
    public float jump_speed;
    private Vector3 dir;
    private Rigidbody rb;
    public bool onGround=true;
    public bool flag = false;
    // Start is called before the first frame update

    public static playermovement instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    void Start()
    {
        dir = Vector3.forward;
        rb=GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(this.transform.position.y<-2)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        this.transform.Translate(dir * mov_speed * Time.deltaTime);
        if (((dir == Vector3.forward) && Input.GetKeyDown(KeyCode.RightArrow)) || ((dir == Vector3.forward) && Input.GetKeyDown(KeyCode.D)))
        {
            dir = Vector3.right;
        }
        if (((dir == Vector3.left)&&Input.GetKeyDown(KeyCode.RightArrow)) ||((dir == Vector3.left) && Input.GetKeyDown(KeyCode.D)))
        {
            dir = Vector3.forward;
        }
        if (((dir == Vector3.forward) && Input.GetKeyDown(KeyCode.LeftArrow)) || ((dir == Vector3.forward) && Input.GetKeyDown(KeyCode.A)))
        {
            dir = Vector3.left;
        }
        if (((dir == Vector3.right) && Input.GetKeyDown(KeyCode.LeftArrow)) || ((dir == Vector3.right) && Input.GetKeyDown(KeyCode.A)))
        {
            dir = Vector3.forward;
        }
        /*if(Input.GetKey(KeyCode.A))
        {
            this.transform.Translate(Vector3.left * mov_speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            this.transform.Translate(Vector3.right * mov_speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            this.transform.Translate(Vector3.back * mov_speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.W))
        {
            this.transform.Translate(Vector3.forward * mov_speed * Time.deltaTime);
        }*/
        if (Input.GetKeyDown(KeyCode.Space) && onGround==true)
        {
            flag = true;
        }

        if((transform.position.z > 28)&&(transform.position.y < -1))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            transform.position = new Vector3(8, 0.625f, 28);
            dir = Vector3.forward;
        }
    }
    private void FixedUpdate()
    {
        if (flag == true)
        {
            rb.AddForce(Vector3.up * jump_speed, ForceMode.Impulse);
            onGround = false;
            flag= false;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("ground")==true)
        {
            onGround= true;
        } else onGround= false;
        if (collision.gameObject.CompareTag("Enemy") == true)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        if(collision.gameObject.CompareTag("Slippery")==true)
        {
            onGround = true;
            mov_speed = 8;
        } else mov_speed= 2;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("LevelChange")==true)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
