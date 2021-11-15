using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMov : MonoBehaviour
{
    [SerializeField] private LayerMask platformlayerMask;
    [SerializeField] private LayerMask Walls;
    [Header ("MOVEMENT")]
    public float speed;
    private float SmoothSpeed = 0.05f;
    Vector3 velocity = Vector3.zero;

    [Header("JUMP")]
    public float jumpHeight;

    private float jumpRechargeTime = 0f;

    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;

    private Rigidbody2D rg;
    private CapsuleCollider2D Collider2D;
    [Header("AMMO")]
    public GameObject balls;

    [HideInInspector]
    public bool dead;

    public GameObject PlayerWall;

    public Animator Animator;

    private void Start()
    {
        rg = GetComponent<Rigidbody2D>();
        Collider2D = GetComponent<CapsuleCollider2D>();
    }
    private void FixedUpdate()
    {
        Movement();
        Jump();
    }
    private void Update()
    {
        Disparo();
        SomeWallBehind();
    }
    void PowerWall()
    {

        if (Input.GetKeyDown(KeyCode.E))
        {
            PlayerWall.transform.position = transform.position;
            PlayerWall.SetActive(true);
            gameObject.SetActive(false);
            FindObjectOfType<CinemachineSwitcher>().SwithCamera();
        }
    }
    void Movement()
    {
    

        float HorizontalInput = Input.GetAxis("Horizontal");
        Vector3 movement = new Vector2(HorizontalInput * speed, rg.velocity.y);
        rg.velocity = Vector3.SmoothDamp(rg.velocity, movement, ref velocity, SmoothSpeed * Time.deltaTime);
        Flip(HorizontalInput);

        if (rg.velocity != Vector2.zero)
        {
            Debug.Log("movimiento");
            Animator.SetBool("correr", true);
            Animator.SetBool("Salta", false);
        }
        else
        {
            Animator.SetBool("correr", false);
        }


    }
    void Flip(float rotinput)
    {
        Quaternion Rotflip = transform.rotation;
        if (rotinput < 0) Rotflip.y = 180;
        else if(rotinput > 0 ) Rotflip.y = 0;
        transform.rotation = Rotflip;
    }
    void Jump()
    {
        float JumpInput = Input.GetAxis("Jump");

        if (Time.time >= jumpRechargeTime && CheckGround())
        {
         

            Vector2 Jump = new Vector2(0, jumpHeight * JumpInput);
            rg.AddForce(Jump,ForceMode2D.Impulse);
            jumpRechargeTime = Time.time + 0.2f; // One second until the next jump
        }
        else if (rg.velocity.y < 0)
        {
            rg.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }else if(rg.velocity.y >0 && JumpInput == 0)
        {
            rg.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier * Time.deltaTime);
        }
       

    }
    void SomeWallBehind()
    {
        // Cast a ray straight down.
        RaycastHit2D hit = Physics2D.Raycast(Collider2D.bounds.center, transform.TransformDirection(Vector2.up),0.25f, Walls);

        // If it hits something...
        if (hit.collider != null )
        {
            Debug.Log(hit.transform.name);
            PowerWall();
        }
    }
    bool CheckGround()
    {
       

        float extraHeightText = 0.1f;
        RaycastHit2D raycast = Physics2D.Raycast(Collider2D.bounds.center, Vector2.down, Collider2D.bounds.extents.y + extraHeightText, platformlayerMask);
        Debug.DrawRay(Collider2D.bounds.center, Vector2.down * (Collider2D.bounds.extents.y + extraHeightText));
        return raycast.collider != null;
    }

    void Disparo()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(balls, transform.position, transform.rotation);
        }
    }
}
