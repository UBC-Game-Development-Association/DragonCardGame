using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public List<Player> players = new List<Player>();
    // Game State: enum
    // Player1 Turn -> Player2 Turn -> repeat
    // Cards played this turn
    
    // Contamination Index
    
    // Start is called before the first frame update
    void Start()
    {
        
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
