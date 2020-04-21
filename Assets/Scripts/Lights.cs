using System.Collections;
using UnityEngine;

public class Lights : MonoBehaviour
{
    public Material red;
    public Material yellow;
    public Material green;
    public string colour;

    // Start is called before the first frame update
    void Awake()
    {
        int colour = Random.Range(0, 3);
        if (colour == 0)
        {
           
            StartCoroutine("ColourGreen");
        }
        if (colour == 1)
        {

            StartCoroutine("ColourYellow");
        }
        if (colour == 2)
        {
            StartCoroutine("ColourRed");
        }
    }

    IEnumerator ColourRed()
    {
        gameObject.GetComponent<MeshRenderer>().material = red;
        colour = "red";
        int wait = Random.Range(5, 11);
        yield return new WaitForSeconds(wait);
        StartCoroutine("ColourGreen");
    }
    IEnumerator ColourYellow ()
    {
        gameObject.GetComponent<MeshRenderer>().material = yellow;
        colour = "yellow";
        yield return new WaitForSeconds(4);
        StartCoroutine("ColourRed");
    }
    IEnumerator ColourGreen ()
    {
        gameObject.GetComponent<MeshRenderer>().material = green;
        colour = "green";
        int wait = Random.Range(5, 11);
        yield return new WaitForSeconds(wait);
        StartCoroutine("ColourYellow");
    }
    
}
