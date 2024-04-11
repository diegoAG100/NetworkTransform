using Unity.Netcode;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovementServer : NetworkBehaviour
{
    public float velocity = 6;
    public float jumpforce = 6;
    private Vector3 movement = new Vector3();

    private Rigidbody rb;

    private void Start(){
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {   
        if(IsOwner){
            Move();
        }
    }

    void Update(){
        if(IsOwner){
            Jump();
        }
    }

    private void Move(){
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        movement.x = horizontal;
        movement.z = vertical;

        movement=movement.normalized*velocity*Time.fixedDeltaTime;
        SubmitPositionRequestServerRpc(movement);
    }

    [Rpc(SendTo.Server)]
    void SubmitPositionRequestServerRpc(Vector3 movement){
        if((transform.position + movement).x>4 || (transform.position + movement).x<-4 || (transform.position + movement).z>4 || (transform.position + movement).z<-4 ){

        }
        else{
            transform.position +=movement;
        }
    }

    private void Jump(){
        if(Input.GetButtonDown("Jump")&&transform.position.y<1.2f){
            SubmitJumpRequestServerRpc();
        }
    }

    [Rpc(SendTo.Server)]
    void SubmitJumpRequestServerRpc(){
        rb.AddForce(Vector3.up*jumpforce,ForceMode.Impulse);
    }

}
