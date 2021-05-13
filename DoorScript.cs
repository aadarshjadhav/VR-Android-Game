using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    private Animator Animation;
    public bool Isopen=false;
    // Start is called before the first frame update
    void Start()
    {
        Animation = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Dooropen()
    {
        if (Isopen == false)
        {
            Animation.SetTrigger("Open");
            Isopen = true;
        }
        else if (Isopen == true)
        {
            Animation.SetTrigger("Close");
            Isopen = false;
        }


    }
}
