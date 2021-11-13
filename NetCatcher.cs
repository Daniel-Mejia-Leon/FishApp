using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetCatcher : MonoBehaviour
{
    public GameObject parentBone;
    public AnimToFalse toCatch;
    public List<GameObject> fishesCatched = new List<GameObject>();
    public List<Transform> fishesParents = new List<Transform>();
    public List<Quaternion> fishesRotations = new List<Quaternion>();

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        


    }


    private void OnTriggerEnter(Collider collision)
    {


        if (collision.CompareTag("Fish") && toCatch.ableToCatch)
        {
            GameObject fishCatched = collision.gameObject;
            Debug.Log("Fish Detected");
            //ableToCatch = false;
            fishCatched.transform.parent.GetComponent<Animator>().enabled = false;
            fishesParents.Add(fishCatched.transform.parent);
            fishesRotations.Add(fishCatched.transform.rotation);
            fishCatched.transform.parent = parentBone.transform;
            fishCatched.GetComponent<Animator>().speed = 0f;
            fishesCatched.Add(fishCatched);
            //Debug.Log(fishesParents.Count);
        }

        else if (collision.CompareTag("Breaker"))
        {
            Debug.Log("shark Detected");
            toCatch.ableToCatch = false;
            for (int i = 0; i < fishesCatched.Count; i++)
            {
                fishesCatched[i].transform.parent = fishesParents[i];
                fishesCatched[i].transform.rotation = fishesRotations[i];
                //fishesCatched[i].transform.position = new Vector3(0, 0, 0);
                fishesCatched[i].GetComponent<Animator>().speed = 2f;
                fishesParents[i].transform.GetComponent<Animator>().speed = 1.4f;
                fishesParents[i].GetComponent<Animator>().enabled = true;
                //fishesCatched[i].transform.localScale = new Vector3(1, 1, 1);
            }

            fishesParents.Clear();
            fishesCatched.Clear();
            fishesRotations.Clear();
        }
    }


}
