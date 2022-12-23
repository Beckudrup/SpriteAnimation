using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem; //Library som lader visual studio kende commands til unities nye "l�kkre" input system


public class playerMovement : MonoBehaviour
{

    private Vector2 movement; //En vector2 som gemmer movement'en fra vores gut
    private Rigidbody2D myBody; //En rigid body vi kan kode til at flytte 
    private Animator myAnimator; //Laver en plads i koden til vores animator
    [SerializeField] private int speed = 5; //S�tter en speed som unity kan se pga [SerializeField]

    private void Awake() //k�re en gang n�r noget specielt sker i det her tilf�lde er det bare n�r programmet starter
    {
        myBody = GetComponent<Rigidbody2D>(); //Vi giver vores myBody rigidbody2d componentet fra unity s� vi kan �ndre dens v�rdiger i koden s� vores gut kan bev�ge sig
        myAnimator = GetComponent<Animator>(); //Vi giver vores myAnimator Animator componentet fra unity s� vi kan �ndre dens v�rdiger i koden s� vores gut kan bev�ge sig
    }

    private void OnMovement(InputValue value)
    {
        movement = value.Get<Vector2>();
        //^^Vores vector tal som vi f�r af at bev�ge os med inputsystemet som beskriver movement'en af vores gut bliver nu sat lig movement'en s� vi kan g�re klar til at rykke vores gut 

        //Tjekker om gutten bev�ger sig og s�tter walking tril true hvis den g�r og s�tter walking til false hvis den ikke g�r, dette har betydning for vores animator og dens skifts fra idle og moving
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
    private void FixedUpdate() //Det er update men det k�re p� et bedre interval n�r det kommer til animationer og rigidbody
    {
        myBody.velocity = movement * speed; 
        //Vores guts movement bliver sat lig den movement vi f�r fra inputsystemet ganget med den speed vi definerede i starten
    }
}
