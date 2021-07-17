using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
    public float movespeed = 5f;

    public Rigidbody2D rb;

    public float DashSpeed;
    public float DashTime;
    private int Direction;
    public float StartDashTime;
    private void Start()
    {
        DashTime = StartDashTime;
    }
    


    Vector2 movement;

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        if (Direction == 0)
        {
            if (Input.GetKeyDown(KeyCode.A)){
                Direction = 1;
            } else if (Input.GetKeyDown(KeyCode.D)){
                Direction = 2;
            } else if (Input.GetKeyDown(KeyCode.W)){
                Direction = 3;
            } else if (Input.GetKeyDown(KeyCode.S)){
                Direction = 4;
            }
        }
        else {
            if (DashTime <= 0){
                Direction = 0;
                DashTime = StartDashTime;
                rb.velocity = Vector2.zero;
            } else {
                DashTime -= Time.deltaTime;

                if (Direction == 1){
                    rb.velocity = Vector2.left * DashSpeed;
                } else if (Direction == 2){
                    rb.velocity = Vector2.right * DashSpeed;
                } else if (Direction == 3){
                    rb.velocity = Vector2.up * DashSpeed;
                } else if(Direction == 4){
                    rb.velocity = Vector2.down * DashSpeed;
                }
            }
        }

    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * movespeed * Time.fixedDeltaTime);
    }


}
