using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyIt : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

     void destroy()
    {
        Destroy(transform.parent.gameObject, 0f);
    }
}
