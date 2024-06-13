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

    [SerializeField] AnimationCurve animCurcved;
    [SerializeField] float time;

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
        surfaceWalk();
    }

    private void playerMove()
    {
        moveDir.x = Input.GetAxis("Horizontal");
        moveDir.z = Input.GetAxis("Vertical");

        moveDir = transform.TransformDirection(moveDir);

        player.MovePosition(this.gameObject.transform.position + moveDir * playerSpeed * Time.deltaTime);
    }

    private void surfaceWalk()
    {
           
        
    }
}
