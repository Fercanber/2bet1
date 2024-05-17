using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Cinemachine;
using UnityEngine.UI;
using Org.BouncyCastle.Crypto.Macs;

public class Launcher : MonoBehaviourPunCallbacks
{
    private bool gameStarted = false;
    private int numJugadoresConectados = 0;

    public PhotonView _pj1Prefab, _pj2Prefab;
    public Transform _spawnPointPj1, _spawnPointPj2;
    public Camera _cameraPj1, _cameraPj2;

    public GameObject GameController;

    
    void Start()
    {
        GameController.SetActive(false);
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
        if(numJugadoresConectados < 2)
        {
            GameObject player;
            if (SelectCharacterController.instance.isPj1Selected())
            {
                player = PhotonNetwork.Instantiate(_pj1Prefab.name, _spawnPointPj1.position, _spawnPointPj1.rotation);
                _cameraPj1.enabled = true;
                _cameraPj2.enabled = false;

                numJugadoresConectados++;
            }
            else
            {
                player = PhotonNetwork.Instantiate(_pj2Prefab.name, _spawnPointPj2.position, _spawnPointPj2.rotation);
                _cameraPj1.enabled = false;
                _cameraPj2.enabled = true;

                numJugadoresConectados++;
            }
            player.GetComponentInChildren<CinemachineVirtualCamera>().GetComponent<CinemachineConfiner2D>().m_BoundingShape2D = GameObject.Find("Borders").GetComponent<PolygonCollider2D>();
        }
        else
        {
            if (!gameStarted)
            {
                GameController.SetActive(true);
                gameStarted = true;
            }
        }
    }
}
