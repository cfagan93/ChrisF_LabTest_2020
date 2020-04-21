using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    public Transform target;
    public List<GameObject> greenlights = new List<GameObject>();
    public float speed;
    public bool findnewtarget = false;
    void Start()
    {
        newtarget();
    }

    void newtarget()
    {
        findnewtarget = false;        
        greenlights.Clear();
        foreach (GameObject item in GameObject.FindGameObjectsWithTag ("trafficlight"))
        {
            if (item.GetComponent<Lights>().colour == "green")
            {
                greenlights.Add(item);
            }
        }
        int next = Random.Range(0, greenlights.Count);
        target = greenlights[next].transform;
        findnewtarget = true;
    }
    void Update()
    {
     if (target.GetComponent<Lights>().colour == "green" && target != null)
        {
            float move = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, target.position, move);
            transform.LookAt(target.position);
            if (Vector3.Distance(transform.position, target.position) < 0.01f)
            {
                if (findnewtarget == true)
                {
                    newtarget();
                }
            }
        }
        else { 
            if (findnewtarget == true)
            {
                newtarget();
            }

        }
    }
}
