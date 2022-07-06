using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using DefaultNamespace;
using UnityEngine;

public class CardZone : Hand
{
        public Hand p2Hand = new Hand();
        public Vector3 areaP2;

        public CardZone(Vector3 newArea, Zone newZone)
        {
                base.area = newArea;
                base.selfZone = newZone;
                areaP2 = new Vector3(base.area.x, base.area.y + 2, base.area.z);
                p2Hand.area = areaP2;
                p2Hand.selfZone = base.selfZone;
        }

        public new void setCardPos()
        {
                base.setCardPos();
                p2Hand.setCardPos();
                
        }
        
        public new void addCard(Card newCard)
        {
                //@TODO card positioning networked
                /*
                if(newCard.player.playerID == 1)
                {
                        base.addCard(newCard);
                }
                else if(newCard.player.playerID == 2)
                {
                        p2Hand.addCard(newCard);
                }
                  */      
                
                //newCard.transform.Rotate(rotation);
        }

}
