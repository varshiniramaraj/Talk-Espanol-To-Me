using UnityEngine;
using System.Collections;

//hover keyword causes it to move ahead, words keyword allows it to be enabled and see the meaning and look at the camera
public class Hover : MonoBehaviour {
    public Vector3 initPosition;
    public bool hover;
    public bool word;
    public GameObject camera1;
	// Use this for initialization
	void Start () {
        initPosition = transform.position;
        camera1 = GameObject.Find("Main Camera");
       // foreach(Transform child in transform)
       foreach(Transform child in transform)
        {
            if(child.tag=="words")
            {
                child.GetComponentInChildren<Renderer>().enabled = false;
            }
            
        }
        word = false;
        hover = false;
	}
	
	// Update is called once per frame
	void Update () {
	    if(hover)
        {
            //transform.position = new Vector3(initPosition.x, initPosition.y + 0.1f, initPosition.z);
            transform.position = Vector3.MoveTowards(initPosition,camera1.transform.position,0.1f);
            if(word)
            {
                foreach (Transform child in transform)
                {
                    if (child.tag == "words")
                    {
                        child.GetComponentInChildren<Renderer>().enabled = true;
                        child.LookAt(2 * child.position - camera1.transform.position);
                    }
                    
                }
            }
            
        }
        else
        {
            word = false;
            transform.position = new Vector3(initPosition.x, initPosition.y, initPosition.z);
            if(!word)
            {
                //Debug.Log("here" + word);
                foreach (Transform child in transform)
                {
                    if (child.tag == "words")
                    {
                        child.GetComponentInChildren<Renderer>().enabled = false;
                    }
                }
            }
            
        }
    }
}
