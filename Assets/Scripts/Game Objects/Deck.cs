using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Deck
{
    private List<int> cardIds = new List<int>();
    public string deckCode;
    public Card blank;
    public GameController gamecontr;
    public Hand hand = new Hand();

    public Deck(string nDeckCode)
    {
          initiate(nDeckCode);
    }

    public int drawCard()
    {
        if (cardIds.Count > 0)
        {

            Debug.Log(cardIds[0]);
            int selectCard = cardIds[0];
            cardIds.RemoveAt(0);
            return selectCard;
        }
        //@TODO GAMEOVER! NO Cards left! or something like that
        return 0;
    }

    public void initiate(string dCode)
    {
        deckCode = dCode;
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
