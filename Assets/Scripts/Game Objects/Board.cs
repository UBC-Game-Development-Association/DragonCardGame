using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class Board : MonoBehaviour
{
    private CardZone ZoneAH = new CardZone(new Vector3(-3f,-1f, -0.34f), Zone.ZoneA);
    private CardZone ZoneBH = new CardZone(new Vector3(3f,-1f, -0.34f), Zone.ZoneB);

    // Start is called before the first frame update
    void Start()
    {
        //ZoneAH.area = Boardrules.zonahArea
        //ZoneAH.area = new Vector3(-3f,-1f, -0.34f);
        //ZoneAH.selfZone = Zone.ZoneA;
        //ZoneBH.area = new Vector3(3f,-1f, -0.34f);
        //ZoneBH.selfZone = Zone.ZoneB;
    }

    public void cardDropped(Card newCard, Zone newzone)
    {
        if (newzone == Zone.ZoneA)
        {
            ZoneAH.addCard(newCard);
            
        }
        else if (newzone == Zone.ZoneB)
        {
            ZoneBH.addCard(newCard);
                       
        }
    }

    public void setCardPositions()
    {
        ZoneAH.setCardPos();
        ZoneBH.setCardPos(); 
    }
}
