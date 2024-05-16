using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Cinemachine;
using UnityEngine.UI;

public class Launcher : MonoBehaviourPunCallbacks
{
    public PhotonView _pj1Prefab, _pj2Prefab;
    public Transform _spawnPointPj1, _spawnPointPj2;

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
        if (SelectCharacterController.instance.isPj1Selected()) PhotonNetwork.Instantiate(_pj1Prefab.name, _spawnPointPj1.position, _spawnPointPj1.rotation);
        else PhotonNetwork.Instantiate(_pj2Prefab.name, _spawnPointPj2.position, _spawnPointPj2.rotation); 
    }
}
