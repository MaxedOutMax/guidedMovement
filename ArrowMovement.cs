using System.Collections;           // what we are using for references
using System.Collections.Generic;   // what we are using for references
using UnityEngine;                  // using Unity 

public class Path1 : MonoBehaviour  // class Name [Path1 can be anything]
{

    GameObject pointB = new GameObject();       // defining pointB as a GameObject, but also saying it will be a new gameobject
    GameObject cameraloc = new GameObject();    // same as above [pointB and cameraloc can be any name]
  


    IEnumerator Start()                         // IEnumerators are used for loops and to make clones
    {
        yield return new WaitForSeconds(0.0f);                          // if you want any delay change (0.0f)
        pointB = GameObject.FindGameObjectWithTag("destination");       // pointB (new GameObject) will have same characteristics as any gameobject with the tag destination. Can change destination to any tag you want.
        cameraloc = (GameObject.FindGameObjectWithTag("MainCamera"));   // same as above.

        while (true)                            // as long as this is true... do this
        {
            yield return StartCoroutine(E1(transform, new Vector3(cameraloc.transform.position.x, 0.2f, cameraloc.transform.position.z), pointB.transform.position));   // Coroutine is to repeat something. Saying to repeat E1 below.
        }
    }

    void Update()                               // check for the following every frame
    {
        pointB = GameObject.FindGameObjectWithTag("destination");       // we want to keep updating the characteristics of pointB with comparison to tag destination because it will be changing in some form (position, scale, etc)
        cameraloc = (GameObject.FindGameObjectWithTag("MainCamera"));   // same as above.
    }

    IEnumerator E1(Transform thisTransform, Vector3 start, Vector3 end) // defining E1 with paramaters of Transform, Vector3, Vector3. thisTranform, start, end are just names you can change to define these references
    {
        var i = 0.0f;                           // defining our loop initially as i = 0.0f [i and 0.0f can be whatever you want)
        while (i < 1.0f)                        // as long as these parameters ( i < 1.0f) are true, do the following. Anything in paranthesis can be changed for your usage
        {
            i += Time.deltaTime * 0.5f;                             // we are increasing i by the time of game multiplied by 0.5f or whatever you want
            thisTransform.LookAt(end);                              // during this loop thisTransform or whatever assigned to it will look at the second Vector3 (or end) defined
            thisTransform.position = Vector3.Lerp(start, end, i);   // during this loop thisTransform will Lerp or move linearly from start to end across i time

            yield return null;                  // end of loop. but will keep looping when i < 1.0f
        }
    }
}


