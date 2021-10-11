using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DefaultNamespace;
public static class BoardRules
{ 
    public static Zone getZone(Vector3 position)
    { 
        Zone zone;
        if (position.y > -1.6)
        { 
            zone = Zone.board;
        }
        else
        { 
            zone = Zone.hand;
        }

        return zone;
        }
    }