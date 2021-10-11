using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor.UI;
using UnityEngine;

public class Deck : MonoBehaviour
{
    private List<int> cardIds = new List<int>();
    public string deckCode;
    public Card blank;
    public Player player;
    
    public void drawCard()
    {
        if (cardIds.Count > 0)
        {
            Card drawn = Instantiate(blank, this.transform);
            drawn.initiate(cardIds[0], player);
            cardIds.RemoveAt(0);
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
            run = 0;
            num = (int) c;
            num = num - 48;

            while (run <= 31)
            {
                numCards = num & 0b_11;
                for (int i = numCards; i > 0; i++)
                {
                    cardIds.Append(cardNo);
                }

                run++;
                cardNo++;
                num = num << 2;
            }
        }
    }

}
