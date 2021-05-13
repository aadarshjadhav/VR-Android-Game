 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] Transform Target1;
    [SerializeField] Transform Target2;
    [SerializeField] Transform Target3;
    [SerializeField] Transform Target4;

    [SerializeField] int CurrentTarget = 1; 
           
    private Transform TargetPosition;
    private bool Contact = false;
    private int LastTarget = 1;
    // Start is called before the first frame update
    void Start()
    {
        TargetPosition = Target1;
        //GetComponent<NavMeshAgent>().destination = TargetPosition.position;
        MoveTowardsTarget();
        LastTarget = CurrentTarget;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("EnemeyTarget"))
        {
            if (Contact == false)
            {

                Contact = true;


                CurrentTarget = Random.Range(1, 5);
                if (CurrentTarget == LastTarget)
                {
                    TryAgain();
                }
                else
                {
                    MoveTowardsTarget();
                }
               
                
                

            }

        }
    }
    void TryAgain()
    {
        if(LastTarget==1)
        {
            CurrentTarget = LastTarget + 1;
        }
        else if(LastTarget>1)
        {
            CurrentTarget = LastTarget - 1;
        }
        MoveTowardsTarget();
    }

    void MoveTowardsTarget()
    {
        if(CurrentTarget==1)
        {
            TargetPosition = Target1;
        }
        if (CurrentTarget == 2)
        {
            TargetPosition = Target2;
        }
        if (CurrentTarget == 3)
        {
            TargetPosition = Target3;
        }
        if (CurrentTarget == 4)
        {
            TargetPosition = Target4;
        }
        GetComponent<NavMeshAgent>().destination = TargetPosition.position;
        LastTarget = CurrentTarget;
        Contact = false;

    }
}
