using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : NetworkBehaviour
{
    public float velocity = 6;

    // Update is called once per frame
    void FixedUpdate()
    {   
        if(IsOwner){
            Move();
        }
    }

    private void Move(){
        Vector3 movement = new Vector3();
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        movement.x = horizontal;
        movement.z = vertical;

        movement=movement*velocity*Time.fixedDeltaTime;

        transform.position +=movement;
        SubmitPositionRequestServerRpc(movement);
    }

    [Rpc(SendTo.Server)]
    void SubmitPositionRequestServerRpc(Vector3 movement){
        transform.position +=movement;
    }

}
