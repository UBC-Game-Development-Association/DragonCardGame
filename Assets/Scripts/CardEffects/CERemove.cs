using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CERemove : ICardEffect
{
    public void activeEffect(GameController controller, List<Target> targetList)
    {
        foreach(Target t in targetList)
        {
            //@TODO check for null
            Card card = t.gameObject.GetComponent<Card>();
            card.remove();
        }
    }
    
    private List<List<string>> targetList = new List<List<string>>();

    public List<List<string>> neededTargets()
    {
        List<string> target = new List<string>();
        target.Add("bug");
        
        targetList.Add(target);

        return targetList;
    }
}
