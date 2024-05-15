using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Launcher : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    public PhotonView playerPrefab; // Jugador que se va a instanciar 
    public Transform spawnPoint;

    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    
    public override void OnConnectedToMaster()
    {
        Debug.Log("Nos hemos conectado al master");
        PhotonNetwork.JoinRandomOrCreateRoom();

    }
    // Funcion que instancia el prefab de un jugador cuando se realiza una conexion al master
    public override void OnJoinedRoom()
    {
        PhotonNetwork.Instantiate(playerPrefab.name, spawnPoint.position, spawnPoint.rotation);
    }
}
