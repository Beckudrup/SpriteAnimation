using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem; //Library som lader visual studio kende commands til unities nye "l�kkre" input system


public class playerMovement : MonoBehaviour
{

    private Vector2 movement; //En vector2 som gemmer movement'en fra vores gut
    private Rigidbody2D myBody; //En rigid body vi kan kode til at flytte 
    private Animator myAnimator;
    [SerializeField] private int speed = 5; //S�tter en speed

    private void Awake() //k�re en gang n�r noget specielt sker i det her tilf�lde er det bare n�r programmet starter
    {
        myBody = GetComponent<Rigidbody2D>(); //Vi giver vores myBody rigidbody2d componentet fra unity s� vi kan �ndre dens v�rdiger i koden s� vores gut kan bev�ge sig
        myAnimator = GetComponent<Animator>();
    }

    private void OnMovement(InputValue value)
    {
        movement = value.Get<Vector2>();
        //^^Vores vector tal som vi f�r af at bev�ge os med inputsystemet som beskriver movement'en af vores gut bliver nu sat lig movement'en s� vi kan g�re klar til at rykke vores gut 

        if (movement.x != 0 || movement.y != 0)
        {
            myAnimator.SetFloat("x", movement.x);
            myAnimator.SetFloat("y", movement.y);
            myAnimator.SetBool("IsMoving", true);
        }
        else
        {
            myAnimator.SetBool("IsMoving", false);
        }
    }
    private void FixedUpdate()
    {
        myBody.velocity = movement * speed; //Vores guts movement bliver sat lig den movement vi f�r fra inputsystemet ganget med den speed vi definerede i starten
    }
}
