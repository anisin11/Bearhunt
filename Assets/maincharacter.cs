using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class maincharacter : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 1f;
    public Animator animator;
    public float Xaxis, Yaxis;

    
    void Start()
    {
        //animator = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        Cursor.visible = false;
        Xaxis = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        Yaxis = Input.GetAxis("Mouse X");
        transform.Translate(0, 0, Xaxis); // 0,0,1
        transform.Rotate(0, Yaxis, 0);
        if (Xaxis != 0)
        {
            animator.SetBool("isWalking", true);
        }
        else
        {
            animator.SetBool("isWalking", false);
        }
        if(Input.GetMouseButton(0))
        {
            animator.SetBool("isFire",true);
        }
        else
        {
            animator.SetBool("isFire",false); 
            
        }
        
    }
}
