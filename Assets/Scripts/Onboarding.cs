using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Onboarding : MonoBehaviour
{
    public string levelname;
   
    public Image start;
    public Image message1;
    public Image message2;
    public Image message3;

    public GameObject canvas;

    // Start is called before the first frame update
    void Start()
    {
        start.gameObject.SetActive(true);
        message1.gameObject.SetActive(false);
        message2.gameObject.SetActive(false);
        message3.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (start.gameObject.activeInHierarchy)
            {
                start.gameObject.SetActive(false);
                message1.gameObject.SetActive(true);

            }
               
            else if (message1.gameObject.activeInHierarchy)
            {
                message1.gameObject.SetActive(false);
                message2.gameObject.SetActive(true);
            }
            else if(message2.gameObject.activeInHierarchy)
            {
                message2.gameObject.SetActive(false);
                message3.gameObject.SetActive(true);

                //this.Invoke("setTimeOut", 4.0f);
            }
            else
            {
                setTimeOut();
            }

        }
    }
    

    private void setTimeOut()
    {
        
        Destroy(canvas);
        SceneManager.LoadScene(levelname);//levelname为我们要切换到的场景
    }
}
