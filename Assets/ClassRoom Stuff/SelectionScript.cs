using UnityEngine;
using System.Collections;

public class SelectionScript : MonoBehaviour
{
    //used to move the object a little bit in the front, to show it's been selected(ish)
    // Use this for initialization
    public bool hover;
    //private GameObject currentlySelected;
    public Vector3 orig;
    private GameObject Camera = GameObject.Find("Main Camera");
    void Start()
    {
        orig = transform.position;
        hover = true;
    }
    void OnEnable()
    {
        hover = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (hover)
        {
            transform.position = Vector3.MoveTowards(transform.position, Camera.transform.position, 0.2f);
            hover = false;
        }
    }
}
