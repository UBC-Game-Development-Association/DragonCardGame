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
    public Material[] numbers;
    private Camera cam;
    public Hand hand;
    public Player player;
    public Zone zone;
    public Vector3 originalPos;
    public int id;

    private bool focused;

    public GameObject effectPrefab;
    public GameController gameController;
    
    // Start is called before the first frame update
    void Start()
    {
        focused = false;
        cam = Camera.main;
        //setPlayer(player);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void initiate(int cardId, Player newPl)
    {
        id = cardId;
        setPlayer(newPl);
        if (player.playerID == 2)
        {
            flipCard();
        }
        GameObject cardMesh = transform.Find("Card").gameObject;
        Renderer rend = cardMesh.GetComponent<Renderer>();
        if (id < 7)
        {
            rend.material = materials[id];
        }
    }
    public void setPlayer(Player newPl)
    {
        player = newPl;
        hand = player.hand;
        hand.addCard(this);
    }

    public void play()
    {
        GameObject effectObject = Instantiate(effectPrefab);
        Effect cardEffect = effectObject.GetComponent<Effect>();
        cardEffect.initialize(id, gameController);
    }

    public void flipCard()
    {
        transform.Rotate(0, 0, 180);
    }
    private void OnMouseDown()
    {
        
    }
    private void OnMouseDrag()
    {
        if (player.isClient && !focused)
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
        if (!focused)
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

    public void gainFocus()
    {
        if (focused == false)
        {
            originalPos = transform.position;
            focused = true;
        }

        transform.position = new Vector3(0.3f, 0.24f, -0.61f);
        transform.localScale = new Vector3(2f, 2f, 2f);
    }

    public void loseFocus()
    {
        transform.position = originalPos;
        transform.localScale = new Vector3(0.6f, 0.6f, 0.6f);
        focused = false;
    }

}
