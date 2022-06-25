using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine;

public class CardNetworkManager : NetworkManager
{
    public GameController gameController;
    public string deckCode;
    // Start is called before the first frame update
    public override void OnServerAddPlayer(NetworkConnection conn)
    {
        //@TODO Give player a position to complement which is p1/p2 
        GameObject player = Instantiate(playerPrefab);
        NetworkIdentity iden = player.GetComponent<NetworkIdentity>();
        NetworkServer.AddPlayerForConnection(conn, player);
        gameController.registerPlayer(iden.connectionToClient, player, deckCode);

    }
}