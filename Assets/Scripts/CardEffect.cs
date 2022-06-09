using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Preface all card effect classes with CE

public interface ICardEffect
{
    public void activeEffect(GameController controller, List<Target> targetList);

    public List<List<String>> neededTargets();
}
