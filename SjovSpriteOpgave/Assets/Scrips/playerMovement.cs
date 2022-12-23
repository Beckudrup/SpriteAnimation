using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem; //Library som lader visual studio kende commands til unities nye "lækkre" input system


public class playerMovement : MonoBehaviour
{

    private Vector2 movement; //En vector2 som gemmer movement'en fra vores gut
    private Rigidbody2D myBody; //En rigid body vi kan kode til at flytte 
    private Animator myAnimator; //Laver en plads i koden til vores animator
    [SerializeField] private int speed = 5; //Sætter en speed som unity kan se pga [SerializeField]

    private void Awake() //køre en gang når noget specielt sker i det her tilfælde er det bare når programmet starter
    {
        myBody = GetComponent<Rigidbody2D>(); //Vi giver vores myBody rigidbody2d componentet fra unity så vi kan ændre dens værdiger i koden så vores gut kan bevæge sig
        myAnimator = GetComponent<Animator>(); //Vi giver vores myAnimator Animator componentet fra unity så vi kan ændre dens værdiger i koden så vores gut kan bevæge sig
    }

    private void OnMovement(InputValue value)
    {
        movement = value.Get<Vector2>();
        //^^Vores vector tal som vi får af at bevæge os med inputsystemet som beskriver movement'en af vores gut bliver nu sat lig movement'en så vi kan gøre klar til at rykke vores gut 

        //Tjekker om gutten bevæger sig og sætter walking tril true hvis den gør og sætter walking til false hvis den ikke gør, dette har betydning for vores animator og dens skifts fra idle og moving
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
    private void FixedUpdate() //Det er update men det køre på et bedre interval når det kommer til animationer og rigidbody
    {
        myBody.velocity = movement * speed; 
        //Vores guts movement bliver sat lig den movement vi får fra inputsystemet ganget med den speed vi definerede i starten
    }
}
