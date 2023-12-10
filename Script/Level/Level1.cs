using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1 : MonoBehaviour
{
    public Animator openDoor;

    // Update is called once per frame
    void Update()
    {
        // Check the number of child objects
        int childCount = transform.childCount;

        if(childCount == 0)
        {
            openDoor.Play("Scene");
        }
    }
}
