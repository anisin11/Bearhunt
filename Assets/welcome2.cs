using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class welcome2 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Invoke("sceneSwitch", 5f);
    }
    void sceneSwitch()
    {
        SceneManager.LoadScene(3);
    }
}
