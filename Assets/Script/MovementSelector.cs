using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class MovementSelector : NetworkBehaviour
{
    public PlayerMovementServer serverMode;
    public PlayerMovementRewind rewindMode;
    public PlayerMovementClient clientMode;
    void OnGUI()
    {
        if(IsOwner){
        GUILayout.BeginArea(new Rect(10, 10, 300, 300));

        if (GUILayout.Button("Server")) Server();
        if (GUILayout.Button("Rewind")) Rewind();
        if (GUILayout.Button("Client")) Client();

        GUILayout.EndArea();
        }
    }
        
    private void Server(){
        serverMode.enabled = true;
        rewindMode.enabled = false;
        clientMode.enabled = false;
    }
    private void Rewind(){
        rewindMode.enabled = true;
        serverMode.enabled = false;
        clientMode.enabled = false;
    }
    private void Client(){
        clientMode.enabled = true;
        rewindMode.enabled = false;
        serverMode.enabled = false;
    }
}
