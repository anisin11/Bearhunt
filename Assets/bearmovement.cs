using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class bearmovement : MonoBehaviour
{
    public static GameObject bear;
    public float movementSpeed = 20f;
    public float rotationSpeed = 50f;
    public bool isWalking, isRotatingLeft, isRotatingRight;
    private bool Idle = false;
    private bool Eat = false;
    private bool WalkForward = false;
    private bool Sit = false;
    private bool Sleep = false;
    private bool Jump = false;
    public bool bearalive = true;
    public bool isbearalive;
    public GameObject chare;

    // Start is called before the first frame update
    Rigidbody rb;
    public Animator animator, charAnimator;
    void Start()
    {
        //animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        bear = this.gameObject;
        bearalive = true;
        isbearalive = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Idle == false)
        {
            StartCoroutine(Wander());
        }
        if (isRotatingRight == true && isbearalive)
        {
            transform.Rotate(transform.up * Time.deltaTime * rotationSpeed);
        }
        if (isRotatingLeft == true && isbearalive)
        {
            transform.Rotate(transform.up * Time.deltaTime * rotationSpeed);
        }
        if (WalkForward == true && isbearalive)
        {
            //rb.AddForce(transform.forward * movementSpeed);
            transform.Translate(0, 0, 1* Time.deltaTime);
            
        }
        if (Vector3.Distance(transform.position, chare.transform.position) <= 3f && isbearalive)
        {
            transform.LookAt(chare.transform);
        }



    }
    IEnumerator Wander()
    {
        int rotationTime = Random.Range(1, 3);
        int rotateWait = Random.Range(1, 3);
        int rotateDirection = Random.Range(1, 2);
        int walkWait = Random.Range(1, 3);
        int walkTime = Random.Range(1, 7);

        Idle = true;

        yield return new WaitForSeconds(walkWait);

        WalkForward = true;

        yield return new WaitForSeconds(walkTime);

        WalkForward = false;

        yield return new WaitForSeconds(rotateWait);

        if (rotateDirection == 1)
        {
            isRotatingLeft = true;
            yield return new WaitForSeconds(rotationTime);
            isRotatingLeft = false;

        }

        if (rotateDirection == 2)
        {
            isRotatingRight = true;
            yield return new WaitForSeconds(rotationTime);
            isRotatingRight = false;

        }
        Idle = false;
    }
    public static void destroy()
    {
        Destroy(bear);
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == chare && isbearalive)
        {
            animator.SetBool("Attack5",true);
            charAnimator.SetBool("isDie", true);
            //Destroy(chare);
            //SceneManager.LoadScene(4);
            Invoke("scchange", 5f);
        }
    }
    public void scchange()
    {
        SceneManager.LoadScene(4);
    }
}
