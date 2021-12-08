using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckView : MonoBehaviour
{

    public List<CardPanel> cards;

    public GameObject panelPrefab;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void drawDeckList()
    {
        GameObject currentPanel;
        for (int i = 0; i < cards.Count; i++)
        {
            currentPanel = Instantiate(panelPrefab, this.transform);
            currentPanel.transform.position = new Vector3();
        }
    }
    
    bool addCard(CardPanel newCard)
    {
        if (cards.Count < 40)
        {
            cards.Add(newCard);
            //Resort List
            //Redraw List
            return true;
        }
        else
        {
            return false;
        }
    }
    
}
