using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental;
using UnityEngine;
using DefaultNamespace;

public class Hand
{
    private List<Card> cards = new List<Card>();
    public Player owner;
    public Vector3 rotation;
    public Vector3 area;
    public Zone selfZone;
    
    public Hand()
    {
    }
    public void setCardPos()
    {
        Card targCard;
        for (var i = 0; i < cards.Count; i++)
        {
            targCard = cards[i];
            Zone zone = targCard.zone;
            if (zone != selfZone)
            {
                cards.Remove(targCard);
            }
        }
        float start = (cards.Count - 1) / 2f * -1.35f;
        for(var i = 0; i < cards.Count; i++)
        {
            targCard = cards[i];
            targCard.transform.position = new Vector3((i * 1.35f) + start + area.x, area.y, area.z);
            

        }
    }

    public void addCard(Card newCard)
    {
        cards.Add(newCard);
        //newCard.transform.Rotate(rotation);
    }

    
}
