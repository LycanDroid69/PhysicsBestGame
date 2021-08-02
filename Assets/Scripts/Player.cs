using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speedMovement;
    public float speedRotation;
    private Animator animPlayer;
    public float animSpeedX, animSpeedY;
    Rigidbody rbPlayer;
    public float forceJump = 8f;
    bool stateJump;
    bool stateGame;
    // Start is called before the first frame update
    void Start()
    {
        animPlayer = GetComponent<Animator>();
        rbPlayer = GetComponent<Rigidbody>();
        stateJump = false;
        stateGame = true;
    }

    // Update is called once per frame
    void Update()
    {
        movementPlayer();
    }

    private void FixedUpdate()
    {
        FallingPlayer();
    }

    void movementPlayer()
    {
        if (stateGame)
        {
            float x = Input.GetAxis("Horizontal");
            float y = Input.GetAxis("Vertical");
            transform.Rotate(0, x * Time.deltaTime * speedRotation, 0);
            transform.Translate(0, 0, y * Time.deltaTime * speedMovement);

            animPlayer.SetFloat("VelX", x * animSpeedX);
            animPlayer.SetFloat("VelY", y * animSpeedY);
        }
        else
        {
            animPlayer.SetFloat("VelX", 0);
            animPlayer.SetFloat("VelY", 0);
        }

    }

    public void SetStateJump(bool value)
    {
        this.stateJump = value;
    }

    public void Jump()
    {
        jumpingPlayer();
    }

    public void jumpingPlayer()
    {
        if (stateJump)
        {
            animPlayer.SetBool("Jump", true);
            rbPlayer.AddForce(new Vector3(0, forceJump, 0), ForceMode.Impulse);
            animPlayer.SetBool("Floor", true);
        }
        else
        {
            FallingPlayer();
        }
    }

    public void FallingPlayer()
    {
        if (!stateJump)
        {
            animPlayer.SetBool("Floor", false);
            animPlayer.SetBool("Jump", false);
        }
        else
        {
            animPlayer.SetBool("Floor", true);
        }

    }
}
