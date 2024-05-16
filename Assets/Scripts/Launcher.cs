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
    public Camera _cameraPj1, _cameraPj2;

    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
        GameObject borders = GameObject.Find("Borders");
        PolygonCollider2D polygonCollider = borders.GetComponent<PolygonCollider2D>();
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("Nos hemos conectado al master");
        PhotonNetwork.JoinRandomOrCreateRoom();
    }

    // Funcion que instancia el prefab de un jugador cuando se realiza una conexion al master
    public override void OnJoinedRoom()
    {
        GameObject player;
        if (SelectCharacterController.instance.isPj1Selected())
        {
            player = PhotonNetwork.Instantiate(_pj1Prefab.name, _spawnPointPj1.position, _spawnPointPj1.rotation);
            _cameraPj1.enabled = true;
            _cameraPj2.enabled = false;
        }
        else {
            player =  PhotonNetwork.Instantiate(_pj2Prefab.name, _spawnPointPj2.position, _spawnPointPj2.rotation);
            _cameraPj1.enabled = false;
            _cameraPj2.enabled = true;
        }
        player.GetComponentInChildren<CinemachineVirtualCamera>().GetComponent<CinemachineConfiner2D>().m_BoundingShape2D = GameObject.Find("Borders").GetComponent<PolygonCollider2D>();
    }
}
