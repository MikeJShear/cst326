using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;




public class EnemyMovement : MonoBehaviour
{
    public float invaderSpeed = .25f;
    private bool moveInvaderRight = true; // alternates between true and false

     


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        


         if(moveInvaderRight) // when moveInvaderRight true
         {
            transform.Translate(new Vector3(1*Time.deltaTime,0,0)); //moveInvaderRight 
         }

         if(moveInvaderRight == false)  // when moveInvaderRight false
         {
            transform.Translate(new Vector3(-1*Time.deltaTime,0,0)); // move invader left
         }
        
    }

    void OnTriggerEnter(Collider other)
    {
            if(other.gameObject.CompareTag("Left Wall"))
            {
                Debug.Log("Left Wall"); //debug
                moveInvaderRight = true;  // moveInvaderRight true (change Direction)
                // transform.Translate(new Vector3(0,-1,0)); // moves enemy down
                transform.Translate(new Vector3(0, -1, 0)); // moves enemy down
            }
        
            if(other.gameObject.CompareTag("Right Wall"))
            {
                Debug.Log(" Right Wall"); //debug
                moveInvaderRight = false; // moveInvaderRight false (change Direction)
                // transform.Translate(new Vector3(0,-1,0)); // moves enemy down
                transform.Translate(new Vector3(0, -1, 0)); // moves enemy down
            }

    }
}
