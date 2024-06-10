using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    CharacterController cController;

    [SerializeField] float playerSpeed;
    [SerializeField] float playerRunSpeed;
    [SerializeField] GameObject player;
    [SerializeField] float runTime;

    Vector3 moveDir;

    void Start()
    {
        cController = GetComponent<CharacterController>();
    }

    void Update()
    {
        playerMove();
    }

    private void playerMove()
    {
        moveDir = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));

        cController.Move(transform.rotation * moveDir * playerSpeed * Time.deltaTime);
    }
}
