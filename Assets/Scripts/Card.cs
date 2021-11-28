using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using DefaultNamespace;
using UnityEditor;
using UnityEngine;
using UnityEngine.U2D.IK;

public class Card : MonoBehaviour
{
    private Vector3 newPos;
    private Vector3 mousePos;
    public Material[] materials;
    private Camera cam;
    public Hand hand;
    public Player player;
    public Zone zone;

    public int id;
    
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        setPlayer(player);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void initiate(int cardId, Player newPl)
    {
        id = cardId;
        player = newPl;
        GameObject cardMesh = transform.Find("Card").gameObject;
        Renderer rend = cardMesh.GetComponent<Renderer>();
        rend.material = materials[1];
    }
    public void setPlayer(Player newPl)
    {
        player = newPl;
        hand = player.hand;
        hand.addCard(this);
    }

    private void OnMouseDown()
    {
        
    }
    private void OnMouseDrag()
    {
        if (player.isClient)
       {
            newPos = Input.mousePosition;
            newPos = cam.ScreenToWorldPoint(new Vector3(newPos.x, newPos.y));

            transform.position = new Vector3(newPos.x, newPos.y, -0.34f);
        }
        
    }
    private void OnMouseOver () 
    {

    }
    private void OnMouseUp()
    {
        Zone newZone = BoardRules.getZone(transform.position);
        if (newZone != zone)
        {
            zone = newZone;
            if (zone == Zone.hand)
            {
                hand.addCard(this);
            }
        }
        
        hand.setCardPos();
        
    }

}
