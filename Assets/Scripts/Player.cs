using System;
using System.Collections;
using System.Collections.Generic;
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
    // Start is called before the first frame update
    void Start()
    {
        hand.owner = this;
        hand.area = new Vector3(0, -4.13f, -0.34f);
        hand.rotation = new Vector3(0,0,0);
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
    }


}
