using UnityEngine;
using System.Collections;

//raycasting of the sphere
public class Ray : MonoBehaviour
{
    public GameObject point;
    private GameObject orig;
    private GameObject[] ccObjects;
    //public Material Select, noSelect;

    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 100.0f))
        {
            point.transform.position = new Vector3(hit.point.x, hit.point.y, hit.point.z);
            /*if (hit.transform.gameObject.tag == "lang")
            {
                point.GetComponent<Renderer>().material = Select;
            }
            else
            {
                point.GetComponent<Renderer>().material = noSelect;
            }*/
        }
        /*else
        {
            point.GetComponent<Renderer>().material = noSelect;
        }*/
    }
}