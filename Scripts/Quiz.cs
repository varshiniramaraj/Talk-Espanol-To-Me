using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
//used to quiz the user on the words. Similar scene but now you're given a spanish word and you have to click the object accordingly.
public class Quiz : MonoBehaviour {
    GameObject next;
    int stepId;
    string[] names= { "Book", "Printer", "Chair", "Desk" };
    bool correct,isTimeUp,isTimerSet;
    GameObject book, desk, printer, chair;
    GameObject castObj;
    // Use this for initialization
    void Start () {
        GameObject.Find("Plane").GetComponent<Renderer>().enabled = true;
        next = GameObject.Find("Next");
        book = GameObject.Find("Book1");
        desk = GameObject.Find("Tables1");
        printer = GameObject.Find("Printer1");
        chair = GameObject.Find("Chair1");
        next.GetComponent<Renderer>().enabled = true;
        correct = false;
        castObj = null;
        stepId = 0;
        isTimerSet = false;
        isTimeUp = false;
    }

    // Update is called once per frame
    void Update() {
       
        Vector3 fwd = transform.TransformDirection(Vector3.forward);
        RaycastHit hit;
        if (Physics.Raycast(transform.position, fwd, out hit))
        {
            castObj = hit.transform.gameObject;
            if(castObj!=null)
            {
                if(castObj.tag=="lang" && castObj.name == names[stepId])
                {
                    castObj.GetComponent<Hover>().hover = true;
                    if (Input.GetMouseButtonDown(0))
                    {
                        castObj.GetComponent<Hover>().word = true;
                        correct = true;
                        //stepId++;
                    }

                    //need to get all the text meshes
                }
                else if(castObj.tag=="lang" && castObj.name!=names[stepId])
                {
                    foreach(Transform child in transform)
                    {
                        child.GetComponentInChildren<MeshRenderer>().enabled = true;
                    }
                }
            }
            
        }
    }
    void LateUpdate()
    {
        switch(stepId)
        {
            case 0:
                next.GetComponent<TextMesh>().text = "El Libro";
                book.GetComponent<TextMesh>().text = "Yes, you got it right!";
                desk.GetComponent<TextMesh>().text = "No, try again!";
                printer.GetComponent<TextMesh>().text = "No, try again!";
                chair.GetComponent<TextMesh>().text = "No, try again!";
                if(correct)
                {
                    //correct = false;
                    if (!isTimerSet)
                    {
                        isTimerSet = true;
                        isTimeUp = false;
                        StartCoroutine(setTimer(0.8f));
                    }
                    if (isTimeUp)
                    {
                        correct = false;
                        Debug.Log("Reached here");
                        isTimerSet = false;
                        GameObject.Find("Book").GetComponent<MeshRenderer>().enabled = false;
                        castObj.GetComponent<Hover>().hover = false;
                        GameObject.Find("Book1").GetComponent<MeshRenderer>().enabled = true;
                        stepId++;

                    }
                    
                }
                break;
            case 1:
                next.GetComponent<TextMesh>().text = "La impresora";
                //book.GetComponent<TextMesh>().text = "No, try again!";
                desk.GetComponent<TextMesh>().text = "No, try again!";
                printer.GetComponent<TextMesh>().text = "Yes, you got it right!";
                chair.GetComponent<TextMesh>().text = "No, try again!";
                if (correct)
                {
                    
                    if(!isTimerSet)
                    {
                        isTimerSet = true;
                        isTimeUp = false;
                        StartCoroutine(setTimer(0.8f));
                    }
                    if(isTimeUp)
                    {
                        correct = false;
                        isTimerSet = false;
                        GameObject.Find("Printer").GetComponent<MeshRenderer>().enabled = false;
                        castObj.GetComponent<Hover>().hover = false;
                        GameObject.Find("Printer1").GetComponent<MeshRenderer>().enabled = true;
                        stepId++;

                    }
                }
                break;
            case 2:
                next.GetComponent<TextMesh>().text = "La Silla";
                //book.GetComponent<TextMesh>().text = "No, try again!";
                desk.GetComponent<TextMesh>().text = "No, try again!";
                //printer.GetComponent<TextMesh>().text = "No, try again!";
                chair.GetComponent<TextMesh>().text = "Yes, you got it right!";
                if (correct)
                {
                    if (!isTimerSet)
                    {
                        isTimerSet = true;
                        isTimeUp = false;
                        StartCoroutine(setTimer(0.8f));
                    }
                    if (isTimeUp)
                    {
                        correct = false;
                        isTimerSet = false;
                        SceneManager.LoadScene("Editable_Bedroom");
                        stepId++;
                    }

                }
                break;
            case 3:
                next.GetComponent<TextMesh>().text = "El Escritorio";
                //book.GetComponent<TextMesh>().text = "No, try again!";
                desk.GetComponent<TextMesh>().text = "Yes, you got it right! You completed the quiz!";
                printer.GetComponent<TextMesh>().text = "No, try again!";
                //chair.GetComponent<TextMesh>().text = "No, try again!";
               
                break;
        }
        

    }

    IEnumerator setTimer(float time)
    {
        Debug.Log("Reached here as well");
        yield return new WaitForSeconds(time);
        isTimeUp = true;
    }
}
