using Unity.Netcode;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovementClient : NetworkBehaviour
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

        transform.position +=movement;
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
