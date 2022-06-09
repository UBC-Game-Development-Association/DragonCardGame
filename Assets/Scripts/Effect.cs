using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect : MonoBehaviour
{
    public int id;

    public GameController gameController;

    public ICardEffect cardEffect;
    /*
     *  Startup with an ID
     *  Get GameController
     *  wait to be executed
     *
     * (also to do, effect is made when card played)
     */
    public List<Target> targets;
    public void initialize(List<Target> targetList, ICardEffect effect, GameController controller)
    {
        targets = targetList;
        cardEffect = effect;
        gameController = controller;
        controller.effectWaiting(this);
    }

    public void execute()
    {
        cardEffect.activeEffect(gameController, targets);
    }

}
