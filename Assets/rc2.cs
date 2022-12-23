using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class rc2 : MonoBehaviour

{
    // Start is called before the first frame update
    public TMP_Text score;
    public int scores;
    public LayerMask layer;
    public AudioSource m_shootingsound;
    public ParticleSystem flash;
    private Animator animator;
    public ParticleSystem bloodeffect;
    void Start()
    {
        m_shootingsound = GetComponent<AudioSource>();
        scores = 0;
        animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //Ray ray = new Ray(transform.position, transform.TransformDirection(transform.forward));
        Ray ray = new Ray(transform.position, transform.forward);
        if (Physics.Raycast(ray, out RaycastHit hitInfo, 100f, layer, QueryTriggerInteraction.Ignore))
        {
            //Debug.Log("SomethingGot Hit");
            Debug.DrawRay(transform.position, transform.forward * hitInfo.distance, Color.red);
            //Debug.DrawRay(transform.position, transform.TransformDirection(transform.forward) * hitInfo.distance, Color.red);
            if (Input.GetMouseButtonDown(0))
            {
                m_shootingsound.Play();
                //Destroy(hitInfo.collider.gameObject);
                flash.Emit(1);
                //Instantiate(bloodeffect, hitInfo.point, Quaternion.identity);
                bloodeffect.transform.position = hitInfo.point;
                bloodeffect.Emit(4);
                die(hitInfo.transform.gameObject);
                hitInfo.transform.GetComponent<bearmovement>().isbearalive = false;
                if (hitInfo.transform.gameObject.GetComponent<bearmovement>().bearalive)
                {
                    scores += 10;
                    hitInfo.transform.gameObject.GetComponent<bearmovement>().bearalive = false;
                    if (scores >= 100)
                    {

                        StartCoroutine(sceneSwitch());
                    }
                }
            };
        }
        else
        {
            if (Input.GetMouseButtonDown(0))
            {
                flash.Emit(2);
                m_shootingsound.Play();
            }

            Debug.DrawRay(transform.position, transform.forward * 100f, Color.green);
            //Debug.Log("Nothing got hit");


        }
        

    }
    public void die(GameObject bear)
    {
        bear.GetComponent<Animator>().SetBool("Death", true);


        //Invoke("destroy()", 5f);
        StartCoroutine(dess(bear));
    }
    IEnumerator dess(GameObject bear)
    {
        yield return new WaitForSeconds(5f);
        //bearmovement.destroy();
        Destroy(bear);
        score.text = "Score : " + scores;
    }
    IEnumerator sceneSwitch()
    {
        yield return new WaitForSeconds(8f);

        SceneManager.LoadScene(6);
    }

}
