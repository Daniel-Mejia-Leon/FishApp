using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimToFalse : MonoBehaviour
{
    public AudioSource catchingSound;
    public bool ableToCatch;

    // Start is called before the first frame update
    void Start()
    {
        //ableToCatch = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void AnimControllerFalse()
    {
        gameObject.GetComponent<Animator>().enabled = false;
    }

    void CatchSound()
    {
        catchingSound.Play();
    }

    void Catch()
    {
        ableToCatch = true;
    }

    void NoCatch()
    {
        ableToCatch = false;
    }
}
