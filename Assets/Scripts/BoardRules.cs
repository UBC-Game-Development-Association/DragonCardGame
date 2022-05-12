using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DefaultNamespace;
using UnityEngine.Animations;

public static class BoardRules
{ 
    //public area zoneaharea = ...
    public static Zone getZone(Vector3 position)
    { 
        Zone zone = Zone.hand;
        
        if (position.y > -1.6 && position.y < 1.6)
        {
            if (position.x <= 0)
            {
                zone = Zone.ZoneA;
            }
            else {
                zone = Zone.ZoneB;
            }
        }
        else
        { 
            zone = Zone.hand;
        }

        return zone;
    }

    private static Boolean isInArea(Vector3 position1, Vector3 position2, float width, float height)
    {

        

        return false;
    }
    
}