using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    [SerializeField] float playerSpeed;
    [SerializeField] float playerRunSpeed;
    [SerializeField] Rigidbody player;
    [SerializeField] GameObject wallCheck; 
    [SerializeField] float runTime;

    Vector3 moveDir;

    void Start()
    {
       
    }

    void Update()
    {
        //climbWall();
    }

    private void FixedUpdate()
    {
        playerMove();
    }

    private void playerMove()
    {
        moveDir.x = Input.GetAxis("Horizontal");
        moveDir.z = Input.GetAxis("Vertical");

        moveDir = transform.TransformDirection(moveDir);

        player.MovePosition(this.gameObject.transform.position + moveDir * playerSpeed * Time.deltaTime);
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
