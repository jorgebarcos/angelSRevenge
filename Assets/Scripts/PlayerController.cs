using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float moveSpeed;
    public float jumpForce;
    public float gravityScale = 5f;

    public float rotateSpeed = 5f;

    private Vector3 moveDirection;

    public CharacterController characterController;
    public Camera playerCamera;
    public GameObject playerModel;

    private void Update()
    {
        float yStore = moveDirection.y;
        // Movimiento
        //moveDirection = new Vector3(Input.GetAxisRaw("Horizontal"), 0f , Input.GetAxisRaw("Vertical"));
        moveDirection = (transform.forward * Input.GetAxisRaw("Vertical")) + (transform.right * Input.GetAxisRaw("Horizontal"));
        moveDirection.Normalize();
        moveDirection = moveDirection * moveSpeed;
        moveDirection.y = yStore;

        // Salto
        if (Input.GetButtonDown("Jump"))
        {
            moveDirection.y = jumpForce;
        }

        moveDirection.y += Physics.gravity.y * Time.deltaTime * gravityScale;

        characterController.Move(moveDirection * Time.deltaTime);

        if(Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
        {
            transform.rotation = Quaternion.Euler(0f, playerCamera.transform.rotation.eulerAngles.y, 0f);
            Quaternion newRotation = Quaternion.LookRotation(new Vector3(moveDirection.x, 0f, moveDirection.z));

            playerModel.transform.rotation = Quaternion.Slerp(playerModel.transform.rotation, newRotation, rotateSpeed * Time.deltaTime);
        }

    }
    //public CharacterController player;
    //public float playerSpeed;
    //public float jumpForce;

    //private float horizontalMove;
    //private float verticalMove;
    //// Start is called before the first frame update
    //void Start()
    //{
    //    player = GetComponent<CharacterController>();
    //}

    //// Update is called once per frame
    //void Update()
    //{
    //    PlayerMove();
    //}

    //void PlayerMove()
    //{
    //    horizontalMove = Input.GetAxis("Horizontal");
    //    verticalMove = Input.GetAxis("Vertical");

    //    Vector3 playerInput = new Vector3(horizontalMove, 0, verticalMove);

    //    player.Move(playerInput * playerSpeed * Time.deltaTime);
    //}
}
