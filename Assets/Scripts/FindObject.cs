using UnityEngine;
using System.Collections;

//used to select object using raycasting. The hover keyword is used to trigger the moving ahead. The word keyword is used to display the translations of the object in english and spanish.
public class FindObject : MonoBehaviour {
    private Vector3 initialPosition;
    private GameObject[] objects;
    public GameObject sphere;
    public Color sphereC;
    //public AudioSource bg;
    // Use this for initialization
    void Start () {

    }

    // Update is called once per frame
    void Update () {
        GameObject castObj = null;
        Vector3 fwd = transform.TransformDirection(Vector3.forward);
        RaycastHit hit;
        if (Physics.Raycast(transform.position, fwd, out hit))
        {
            castObj = hit.transform.gameObject;
            Debug.Log(castObj);
            if (castObj!=null && castObj.tag=="lang")
            {
                //sphere.transform.GetComponent<Renderer>().material.color = Color.red;
                castObj.GetComponent<Hover>().hover = true;
                if (Input.GetMouseButtonDown(0))
                {
                    castObj.GetComponent<Hover>().word = true;
                    //bg.Play();

                }
            }     
            if(castObj.tag!="lang")
            {

                objects = GameObject.FindGameObjectsWithTag("lang");
                foreach (GameObject obj in objects)
                {
                    obj.GetComponent<Hover>().hover = false;
                }
            }
           
        }
        else
        {

            objects = GameObject.FindGameObjectsWithTag("lang");
            foreach (GameObject obj in objects)
            {
                obj.GetComponent<Hover>().hover = false;
            }
        }

    }
}
