using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Deck : MonoBehaviour
{
    private List<int> cardIds = new List<int>();
    public string deckCode;
    public Card blank;
    public Player player;
    public GameController gamecontr;
    void Start()
    {
        initiate(deckCode, player);
    }
    public void drawCard()
    {
        if (cardIds.Count > 0)
        {
            Card drawn = Instantiate(blank);
            drawn.transform.position = this.transform.position + new Vector3(0.5f, 0.5f, 0f);
            drawn.initiate(cardIds[0], player);
            Debug.Log(cardIds[0]);
            cardIds.RemoveAt(0);
            drawn.gameController = gamecontr;
        }
    }

    public void initiate(string dCode, Player newPl)
    {
        deckCode = dCode;
        player = newPl;
        buildDeck(dCode);
    }

    public void buildDeck(string dCode)
    {
        int num;
        int cardNo = 0;
        int run;
        int numCards;
        foreach(var c in dCode)
        {
            num = (int) c;
            num = num - 48;
            run = 0;
            while (run <= 2)
            {
                numCards = num & 0b_11;
                for (int i = numCards; i > 0; i--)
                {
                    cardIds.Add(cardNo);
                }
                
                run++;
                cardNo++;
                num = num >> 2;
                
                
            }
        }
    }

}
