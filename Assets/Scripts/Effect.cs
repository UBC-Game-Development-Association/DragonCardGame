using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect : MonoBehaviour
{
    public int id;

    public GameController gameController;
    
    /*
     *  Startup with an ID
     *  Get GameController
     *  wait to be executed
     *
     * (also to do, effect is made when card played)
     */

    public void initialize(int eId, GameController controller)
    {
        id = eId;
        gameController = controller;
        controller.effectWaiting(this);
    }

    public void execute()
    {
        
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
