using jKnepel.SimpleUnityNetworking.Managing;
using jKnepel.SimpleUnityNetworking.Networking.ServerDiscovery;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class HololensClientConnection : MonoBehaviour
{
    public bool connect = false;
    public bool checkServers = false;
    public bool checkisConnected = false;
    private NetworkManager networkManager;
    private IPAddress iPAddress;
    private int serverPort;

    private void Start()
    {
        networkManager = GetComponent<NetworkManager>();
    }
    private void Update()
    {
        if (connect) ConnectToServer();
        if (checkServers) DiscoverServers();
        if (checkisConnected) CheckConnection();

    }
    private void DiscoverServers()
    {
        checkServers = false;
        Debug.Log("Servers open: ");
        Debug.Log(networkManager.OpenServers.Count);
        foreach (OpenServer x in networkManager.OpenServers)
        {
            Debug.Log(x.Endpoint.Address.ToString());
            Debug.Log(x.Endpoint.Port.ToString());
        }
        iPAddress = networkManager.OpenServers[0].Endpoint.Address;
        serverPort = networkManager.OpenServers[0].Endpoint.Port;

    }
    private void ConnectToServer()
    {
        connect = false;
        Debug.Log("\n Connecting to srever... \n");
        if(serverPort != null && iPAddress != null)
        {
            networkManager.JoinServer(iPAddress, serverPort);
        }

    }
    private void CheckConnection()
    {
        checkisConnected = false;
        Debug.Log("\n Connection status: \n");
        Debug.Log(networkManager.ConnectionStatus.ToString()) ;

    }

}
