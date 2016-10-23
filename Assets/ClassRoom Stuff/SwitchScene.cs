using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

//used to transition from the  first scene to the quiz scene
public class SwitchScene : MonoBehaviour {
    public float start,end;
    bool on = false;
    public GameObject camera1;
	// Use this for initialization
	void Start () {
        start = Time.time;
        GameObject.Find("Plane").GetComponent<Renderer>().enabled = false;
        GameObject.Find("Next").GetComponent<Renderer>().enabled = false;
        camera1 = GameObject.Find("Main Camera");
	}
	
	// Update is called once per frame
	void Update () {
        RaycastHit hit;
	 if(Time.time - start > 30.0f)
        {
            GameObject.Find("Plane").GetComponent<Renderer>().enabled = true;
            GameObject.Find("Next").GetComponent<Renderer>().enabled = true;
            on = true;
        }
        if(on)
        {
            if (Physics.Raycast(camera1.transform.position, camera1.transform.TransformDirection(Vector3.forward), out hit))
            {
                GameObject castObj = hit.transform.gameObject;
                Debug.Log("Reached here?");
                Debug.Log(castObj.name);
                if(castObj.name=="Plane")
                {
                    Debug.Log("Reached here? and here");
                    if(Input.GetMouseButtonDown(0))
                    {
                        SceneManager.LoadScene("Quiz");
                    }
                    
                }
            }

        }

    }
}
