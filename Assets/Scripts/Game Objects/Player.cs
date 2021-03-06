using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class Player : MonoBehaviour
{
    //public GameObject deckObj;
    //public GameObject handObj;

    public string deckCode;
    public Deck deck;
    public Hand hand = new Hand();
    public int score = 0;
    public bool isClient;
    public int playerID;
    public Card focused;
    
    // Start is called before the first frame update
    void Start()
    {
        hand.owner = this;
        hand.selfZone = Zone.hand;
        if (playerID == 1)
        {
            hand.area = new Vector3(0, -3.53f, -0.34f);
            hand.rotation = new Vector3(90, 180, 0);
        }
        else if (playerID == 2)
        {
            hand.area = new Vector3(0, 3.85f, -0.34f);
            hand.rotation = new Vector3(90, 180, 180);
        }
        //(@TODO set area based on networked controller later)
        //hand = handObj.GetComponent<Hand>();

       
        isClient = true;
    }
    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            deck.drawCard();
        }
        

        
        /*
         * The below code controls the 'focus' feature where rightclicking on a card makes it bigger
         * It should be moved to a game controller later, it only applies to one player.
         */

        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            Physics.Raycast(ray, out hit);
            if (focused)
            {
                focused.loseFocus();
                focused = null;
            }
            else if (hit.collider.CompareTag("Card"))
            { 
                Card hitCard = hit.collider.gameObject.GetComponent<Card>();
             /*   if (focused && hitCard != focused)
                {
                    focused.loseFocus();
                }
               */ 
                focused = hitCard;
                focused.gainFocus();
            }
        }

        if (Input.GetMouseButton(0) && focused)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            Physics.Raycast(ray, out hit);
            if (hit.collider && hit.collider.CompareTag("Card"))
            { 
                Card hitCard = hit.collider.gameObject.GetComponent<Card>();
                if (hitCard != focused)
                {
                    focused.loseFocus();
                    focused = null;
                }


            }
            else
            {
                focused.loseFocus();
                focused = null;
            }
        }
    }


}
