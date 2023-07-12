using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController characterController;
    [SerializeField] private bool isGrounded = false;
    public float speed = 5;
    float gravityScale = 2f;
    [SerializeField] private float gravity=0;
    public LayerMask layerMask;

    int jump_count = 2;
    int av_jumps = 0;

    float boostPow = 0;

    bool fallShake = true;
    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>(); 
    }
    void Boost()
    {
        gravity = 0;
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        float z = 0;
        boostPow += PlayerStats.instance.boost_power/100;
        boostPow = Mathf.Clamp(boostPow, 0, PlayerStats.instance.boost_max_power);

        if (Input.GetKey(KeyCode.Space))
            z = 1;
        else
            z = 0;

        Vector3 boostMove = Camera.main.transform.forward * y * boostPow + transform.right * x * boostPow + transform.up*z*boostPow;
        characterController.Move(boostMove * Time.deltaTime);
    }
    void CheckForGround()
    {
        RaycastHit hit;
        isGrounded = Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out hit, 4.7f, layerMask);
        if (isGrounded && !Input.GetKeyDown(KeyCode.Space))
        {
            av_jumps = jump_count;
            if(fallShake)
            {
                fallShake = false;
                if(gravity < -60)
                    Camera.main.GetComponent<CameraShake>().shakeDuration = 0.2f;
            }
            gravity = Mathf.Clamp(gravity, 0, 1000);
        }
        else
        {
            fallShake = true;
        }
    }
    void Jump()
    {
        gravity = PlayerStats.instance.jump_power;
        av_jumps--;
        
    } 
    void UpdateStats()
    {
        speed = PlayerStats.instance.speed;
        jump_count = PlayerStats.instance.jump_count;
    }
    // Update is called once per frame
    void Update()
    {
        UpdateStats();

        float x = Input.GetAxisRaw("Horizontal")* speed;
        float y = Input.GetAxisRaw("Vertical") * speed;

        Vector3 move = transform.forward * y + transform.right * x + transform.up*gravity;
        characterController.Move(move * Time.deltaTime);
        if(Input.GetKey(KeyCode.LeftShift))
            Boost();
        else
            boostPow -= 1f;
        if (Input.GetKeyDown(KeyCode.Space) && av_jumps>0)
            Jump();
        CheckForGround();
    }
    private void FixedUpdate()
    {
        gravity -= gravityScale;
        gravity = Mathf.Clamp(gravity, -150, 100);
    }
}
