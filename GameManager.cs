using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private float timer;
    public float remainder;
    public GameObject fish1, fish2, fish3, fish4, fish11, fish31, fish41, shark;
    public bool timerActive, paused;
    public List<GameObject> fishesList = new List<GameObject>();
    public List<int> oneOne = new List<int>();
    

    void Start()
    {
        timer = 0f;
        fishesList.Add(fish1);
        fishesList.Add(fish2);
        fishesList.Add(fish3);
        fishesList.Add(fish4);
        fishesList.Add(fish11);
        fishesList.Add(fish31);
        fishesList.Add(fish41);

        oneOne.Add(-1);
        oneOne.Add(1);
        //float yPos = Mathf.Clamp(Random.Range(0, -1.4f), 0 )
        //Debug.Log(25 % 4);
    }

    // Update is called once per frame
    void Update()
    {

        if (!paused)
        {

            timer += Mathf.Ceil(1f);
            Time.timeScale = 1f;
            //Debug.Log(timer);

            if (timer % remainder == 0f)
            {

                GameObject fishCreated = Instantiate(fishesList[Random.Range(0, 8)], new Vector3(0.25f, Random.Range(0.2f, -1.3f), -1.825195f), Quaternion.identity);
                fishCreated.transform.localScale = new Vector3(oneOne[Random.Range(0, 2)], 1, 1);
                //timerActive = false;
            }

            if (timer % 300 == 0f)
            {
                Instantiate(shark, new Vector3(0.25f, Random.Range(-0.7f, -1f), -1.825195f), Quaternion.identity);
            }
        }

        else if (paused)
        {
            Time.timeScale = 0f;
        }

    }

    public void pauseOn()
    {
        if (!paused)
        {
            paused = true;
            
        }

        else if (paused)
        {
            paused = false;
            
        }
    }
}
