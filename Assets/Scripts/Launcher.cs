using UnityEngine;
using Photon.Pun;
using Cinemachine;
using System.Collections.Generic;
using UnityEngine.UIElements;

public class Launcher : MonoBehaviourPunCallbacks
{
    private int numObjetosDestruidos = 0;
    public PhotonView _pj1Prefab, _pj2Prefab;
    public Transform _spawnPointPj1, _spawnPointPj2;
    public Camera _cameraPj1, _cameraPj2;

    public GameObject GameController;
    public GameObject items;

    public PhotonView[] _items;
    public PhotonView _portal;

    void Start()
    {
        GameController.SetActive(false);
        PhotonNetwork.ConnectUsingSettings();
        GameObject borders = GameObject.Find("Borders");
        PolygonCollider2D polygonCollider = borders.GetComponent<PolygonCollider2D>();
    }

    public void Update()
    {
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

            Debug.Log("Instanciando Player 1");
        }
        else
        {
            player = PhotonNetwork.Instantiate(_pj2Prefab.name, _spawnPointPj2.position, _spawnPointPj2.rotation);
            _cameraPj1.enabled = false;
            _cameraPj2.enabled = true;

            Debug.Log("Instanciando Player 2");

        }
        player.GetComponentInChildren<CinemachineVirtualCamera>().GetComponent<CinemachineConfiner2D>().m_BoundingShape2D = GameObject.Find("Borders").GetComponent<PolygonCollider2D>();

        if (GameController != null && PhotonNetwork.CountOfPlayers == 2)
        {
            GameController.SetActive(true);

            for (int i = 0; i < _items.Length; i++)
            {
                PhotonNetwork.Instantiate(_items[i].name, _items[i].GetComponent<Transform>().position, _items[i].GetComponent<Transform>().rotation);
            }
        }
    }
}
