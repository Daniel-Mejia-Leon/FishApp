using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckTouch : MonoBehaviour
{
    public GameObject Net;
    public bool fingerOn;
    public GameManager pauseBool;

    void Start()
    {
        Net.GetComponent<Animator>().enabled = false;
        fingerOn = true;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(Input.touchCount);
        if (Input.touchCount > 0f && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.touches[0].position);
            RaycastHit hit;

            //Debug.DrawRay(ray.origin, ray.direction * 100, Color.yellow, 100f);

            if (Physics.Raycast(ray, out hit))
            {
                //Debug.Log(hit.transform.tag);

                if (hit.transform.tag == "Pause")
                {
                    if (!pauseBool.paused)
                    {
                        pauseBool.paused = true;

                    }

                    else if (pauseBool.paused)
                    {
                        pauseBool.paused = false;

                    }
                }

                else if (hit.transform.tag != "Pause" && hit.collider == null || hit.transform.tag != "Pause" && hit.collider != null)
                {
                    Debug.Log(hit.transform.name);
                    Net.GetComponent<Animator>().enabled = true;
                    //fingerOn = false;
                }
            }


        }
        /*if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began && fingerOn)
            {

                Net.GetComponent<Animator>().enabled = true;
                fingerOn = false;
            }

            if (touch.phase == TouchPhase.Ended)
            {
                fingerOn = true;
            }
        }*/
    }
}
