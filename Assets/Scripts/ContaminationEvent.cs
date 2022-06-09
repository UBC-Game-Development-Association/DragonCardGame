using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class ContaminationEvent : MonoBehaviour
{
    private GameController gameController;
    private int id;
    private int level;
    public GameObject effectPrefab;
    void Start()
    {
        level = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void initialize(int newId, GameController controller)
    {
        id = newId;
        gameController = controller;
    }

    public void contaminate()
    {
        level++;
        GameObject effectObj = Instantiate(effectPrefab);
        Effect thisEffect = effectObj.GetComponent<Effect>();
        //thisEffect.initialize(id + level, gameController);
    }
    

}
