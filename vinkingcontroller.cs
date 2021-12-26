using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Collider))]
public class vinkingcontroller : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float MovingSpeed = 0.2f;
    Rigidbody rb;
    //public Queue<GameObject> q = new Queue<GameObject>();
    Animator animator;
    bool isjump = false;
    [SerializeField] float JumpingForce = 10000f;
    bool run = false;

    void Start()
    {
        bool isjump = false;
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        Debug.Log("Hello World");
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.timeScale == 0f)  return;
        if (Input.GetKey(KeyCode.W))
        {
            /*if (q.Count != 0)
            {
                if (transform.position.x-q.Peek().transform.position.x>20&& transform.position.z - q.Peek().transform.position.z > 20)
                {
                    Destroy(q.Peek());
                    q.Dequeue();
                }
            }*/
            transform.position += MovingSpeed * transform.forward;
            run = true;
        }
        else
        {
            run = false;
        }
        if(Input.GetKeyDown(KeyCode.A))
        {
            transform.Rotate(new Vector3(0f, -90f, 0f));
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            transform.Rotate(new Vector3(0f, 90f, 0f));
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isjump==false)
            {
                //rb.AddForce(JumpingForce * Time.deltaTime * Vector3.up);
                rb.velocity = new Vector3(0, 7, 0);
                isjump = true;
            }
        }
        //animator.SetBool("atk", atk);
        animator.SetBool("Jump", isjump);
        animator.SetBool("Run", run);
    }

    void OnCollisionEnter(Collision collision)
    { 
        isjump = false;
    }

    private void OnCollisionStay(Collision collision)
    {
        isjump = false;
    }
    private void OnCollisionExit(Collision collision)
    {
        isjump = true;
    }
}
