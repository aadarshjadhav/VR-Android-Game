 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickups : MonoBehaviour
{
    RaycastHit hit;                                         // raycast  means invisible ray 
    [SerializeField] float Distance = 4.0f;                 //[Serializefield] is just use for showing a private variable's value on Inspector. You can easily change the value like public variable. But None can access this value from another script or places.
    [SerializeField] GameObject Pickupmessage1;
    [SerializeField] GameObject Pickupmessage2;
    [SerializeField] GameObject Pickupmessage3;
    [SerializeField] GameObject Pickupmessage4;

    private float RayDistance;
    private bool Canseepickup1 = false;                         //this one  ensures that if you are looking at the pickup object or not
    private bool Canseepickup2 = false;
    private bool Canseepickup3 = false;
    private bool Canseepickup4 = false;


    // Start is called before the first frame update

    void Start()
    {
        Pickupmessage1.gameObject.SetActive(false);
        Pickupmessage2.gameObject.SetActive(false);
        Pickupmessage3.gameObject.SetActive(false);
        Pickupmessage4.gameObject.SetActive(false);
        RayDistance = Distance;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Physics.Raycast(transform.position, transform.forward, out hit, RayDistance))
        {
            if (hit.transform.tag == "KitchenKey")
            {
                Canseepickup1 = true;
                if (Input.GetKeyDown(KeyCode.E))
                {
                    Destroy(hit.transform.gameObject);
                    Savescript.KitchenKey += 1;
                }
            }
            else if(hit.transform.tag == "BasementKey")
            {
                Canseepickup2 = true;
                if (Input.GetKeyDown(KeyCode.E))
                {
                    Destroy(hit.transform.gameObject);
                    Savescript.BasementKey += 1;
                }
            }
           else if (hit.transform.tag == "KitchenDoor")
            {
                Canseepickup3 = true;
                if (Savescript.KitchenKey == 1)
                {
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        hit.transform.gameObject.SendMessageUpwards("Dooropen");
                    }
                }
               
            }
            else if (hit.transform.tag == "BasementDoor")
            {
                Canseepickup4 = true;
                if (Savescript.BasementKey == 1)
                {
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        hit.transform.gameObject.SendMessageUpwards("Dooropen");
                    }
                }

            }
            else 
            {
                Canseepickup1 = false;
                Canseepickup2 = false;
                Canseepickup3 = false;
                Canseepickup4 = false;
            }
        
        }
        if (Canseepickup2 == true)                           
        {
            Pickupmessage2.gameObject.SetActive(true);
            RayDistance = 1000f;                            //RD IS 1000f so that the pickup message is gone when we look away from the key. also because the else statement at line 33 won't beable to run. 

        }
        if (Canseepickup2 == false)
        {
            Pickupmessage2.gameObject.SetActive(false);
            RayDistance = Distance;                         //RD is reset to default distance
        }
        if (Canseepickup1 == true)
        {
            Pickupmessage1.gameObject.SetActive(true);
            RayDistance = 1000f;                            //RD IS 1000f so that the pickup message is gone when we look away from the key. also because the else statement at line 33 won't beable to run. 

        }
        if (Canseepickup1 == false)
        {
            Pickupmessage1.gameObject.SetActive(false);
            RayDistance = Distance;                         //RD is reset to default distance
        }
        if (Canseepickup3 == true)
        {
            Pickupmessage3.gameObject.SetActive(true);
            RayDistance = 1000f;                            //RD IS 1000f so that the pickup message is gone when we look away from the key. also because the else statement at line 33 won't beable to run. 

        }
        if (Canseepickup3 == false)
        {
            Pickupmessage3.gameObject.SetActive(false);
            RayDistance = Distance;                         //RD is reset to default distance
        }
        if (Canseepickup4 == true)
        {
            Pickupmessage4.gameObject.SetActive(true);
            RayDistance = 1000f;                            //RD IS 1000f so that the pickup message is gone when we look away from the key. also because the else statement at line 33 won't beable to run. 

        }
        if (Canseepickup4 == false)
        {
            Pickupmessage4.gameObject.SetActive(false);
            RayDistance = Distance;                         //RD is reset to default distance
        }
    }
}
