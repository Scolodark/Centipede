using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    CharacterController cController;

    [SerializeField] float playerSpeed;
    [SerializeField] float playerRunSpeed;
    [SerializeField] GameObject player;
    [SerializeField] GameObject wallCheck; 
    [SerializeField] float runTime;

    Vector3 moveDir;

    void Start()
    {
        cController = GetComponent<CharacterController>();
    }

    void Update()
    {
        playerMove();
        checkGravity();
        climbWall();
    }

    private void checkGravity()
    {
        cController.Move(Physics.gravity * Time.deltaTime);
    }

    private void playerMove()
    {
        moveDir = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));

        cController.Move(transform.rotation * moveDir * playerSpeed * Time.deltaTime);
    }

    private void climbWall()
    {
        RaycastHit hit;
        bool check = false;
        Quaternion rot = Quaternion.Euler(-90, 0, 0);
        
        if(Physics.Raycast(wallCheck.transform.position, Vector3.back, out hit, 0.3f, LayerMask.GetMask("Ground")) && check == false)
        {
            check = true;
            transform.rotation = rot;
            Debug.Log("»Æ¿Œ");
        }

        Debug.DrawRay(wallCheck.transform.position, Vector3.back * 0.3f, Color.red);
    }
}
