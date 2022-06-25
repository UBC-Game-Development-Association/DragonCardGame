using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class GameController : NetworkBehaviour
{
    //This script now goes on the player to help manage stuff
    public Board board;
    private List<Tuple<NetworkConnectionToClient,GameObject,Deck>> players = new List<Tuple<NetworkConnectionToClient,GameObject,Deck>>();
    public GameObject blankCard;
    public List<Effect> effects = new List<Effect>();
    // Game State: enum
    // Player1 Turn -> Player2 Turn -> repeat
    // Cards played this turn
    
    // Contamination Index
    // Start is called before the first frame update

    void Start()
    {
        
    }

    public void registerPlayer(NetworkConnectionToClient conn, GameObject player, string deckcode)
    {
        Debug.Log(deckcode);
        CmdRegisterPlayer(deckcode, player, conn);
    }
    
    //[Command(requiresAuthority = false)]
    [Command(requiresAuthority = false)]
    public void CmdRegisterPlayer(string deckcode, GameObject player, NetworkConnectionToClient conn)
    {   
        //@TODO figure out strange deckcode bug
        Debug.Log(deckcode);
        Deck pDeck = new Deck("IZ00");
        players.Add(new Tuple<NetworkConnectionToClient, GameObject, Deck>(conn, player, pDeck));
    }

    public void testCardDraw(int num)
    {
        CmdGivePlayerCard(num);
    }
    //@TODO Make this no longer a command later. players can just give themselves cards, but they can activate a command that sees if they can get a card.
    [Command(requiresAuthority = false)]
    public void CmdGivePlayerCard(int PlayerNum)
    {

       
        
        if (PlayerNum > players.Count-1)
        {
            return;
        }
        
        GameObject drawn = Instantiate(blankCard);
        //@TODO Spawn position based on player deck, ect
        drawn.transform.position = this.transform.position + new Vector3(0.5f, 0.5f, 0f);

        
        Card card = drawn.GetComponent<Card>();
        Debug.Log(players);

        
        card.initiate(players[PlayerNum].Item3.drawCard(), players[PlayerNum].Item2.GetComponent<Player>());
        card.gameController = this;
        NetworkServer.Spawn(drawn, players[PlayerNum].Item1);
        
    }
    
    public void effectWaiting(Effect newEffect)
    {
        effects.Add(newEffect);
    }

    public void executeEffects()
    {
        for (int i = effects.Count; i > 0; i--)
        {
            effects[i].execute();
        }

        effects = new List<Effect>();
    }
    
    // Update is called once per frame
    void Update()
    {
        /*
    * Temporary card-flipping code, should be removed.
    * 
    */
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            Physics.Raycast(ray, out hit);

            if (hit.collider.CompareTag("Card"))
            {
                Card hitCard = hit.collider.gameObject.GetComponent<Card>();
               
                hitCard.flipCard();
                
            }
        }
    }
}
