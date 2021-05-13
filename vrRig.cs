using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class VRMap
{
    public Transform vrTarget;
    public Transform rigTarget;
    public Vector3 trackingPositionOffSet;
    public Vector3 trackingRotationOffSet; 

    public void Map()
    {
        rigTarget.position = vrTarget.TransformPoint(trackingPositionOffSet);
        rigTarget.rotation = vrTarget.rotation*Quaternion.Euler(trackingRotationOffSet);

    }
}
public class vrRig : MonoBehaviour
{
    public VRMap head;
    public Transform headConstraint;
    public Vector3 headBodyoffset;      //this calculate the difference between head and th body;

    // Start is called before the first frame update
    void Start()
    {
        headBodyoffset = transform.position - headConstraint.position;
         
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = headConstraint.position + headBodyoffset;
        transform.forward = Vector3.ProjectOnPlane(headConstraint.up,Vector3.up).normalized;
        head.Map();
    }
}
