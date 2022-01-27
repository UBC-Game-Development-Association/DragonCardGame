using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class Board : MonoBehaviour
{
    private Hand ZoneAH = new Hand();
    private Hand ZoneBH = new Hand();

    // Start is called before the first frame update
    void Start()
    {
        //ZoneAH.area = Boardrules.zonahArea
        ZoneAH.area = new Vector3(-3f,-1f, -0.34f);
        ZoneBH.area = new Vector3(3f,-1f, -0.34f);
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
