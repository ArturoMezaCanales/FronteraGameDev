using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    //check for at top of ladder and prevent from going more up (put another collision box at the top or near top)
    //randomize layout


    private float speed = 30.0f;
    private bool onLadder = false;
    private bool onTopLadder = false;
    private Rigidbody myRG;

    public groundCheck GC;
    // Start is called before the first frame update
    void Start()
    {
        myRG = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        float vertical = Input.GetAxisRaw("Vertical");
        float horizontal = Input.GetAxisRaw("Horizontal");

        if(!onLadder)
        {
            gameObject.transform.position += new Vector3(horizontal, 0, 0) * speed * Time.deltaTime;
        }
        else
        {
            if(GC.onGround && onLadder && vertical < 0) //prevents from cliping into ground
            {
                vertical = 0;
            }
            if(onTopLadder && vertical > 0)
            {
                Debug.Log("vertifcal 0 ");
                vertical = 0;
            }

            gameObject.transform.position += new Vector3(horizontal,vertical, 0) * speed * Time.deltaTime;
        }

        if (!GC.onGround && !onLadder) // if in the air
        {
            myRG.useGravity = true;
            myRG.constraints = ~RigidbodyConstraints.FreezePositionY;
            myRG.AddForce(transform.up * -100);
        }
        else if (GC.onGround && !onLadder && Input.GetKeyDown("space")) //ground and not ladder and press space frame one
        {
            myRG.constraints = ~RigidbodyConstraints.FreezePositionY; //remove freeze in position y
            myRG.AddForce(0, 2000, 0, ForceMode.Acceleration); //adds acceleration
        }
        
        else if (onLadder)//if on ladder attach to it
        {
            myRG.constraints = RigidbodyConstraints.FreezeAll;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        
       
        if (other.gameObject.tag == "Ladder")
        {
            onLadder = true;
            myRG.useGravity = false;
        }

        if(other.gameObject.tag == "topLadder")
        {
            onTopLadder = true;
        }
        
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Ladder")
        {
            onLadder = false;
        }

        if (other.gameObject.tag == "topLadder")
        {
            onTopLadder = false;
        }


    }
}
