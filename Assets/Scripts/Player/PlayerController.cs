using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
public class PlayerController : MonoBehaviour
{
    private CharacterController characterController;
    [SerializeField] private bool isGrounded = false;
    public float speed = 5;
    public int health = 3;
    float gravityScale = 2f;
    [SerializeField] private float gravity=0;
    public LayerMask layerMask;
    [SerializeField] private Image boostImg;

    int jump_count = 2;
    int av_jumps = 0;
    bool boosting = false;
    float boostPow = 1;
    Vector3 boostMove;
    bool fallShake = true;
    float x = 0;
    float y = 0;
    public float av_boost = 100;
    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        av_boost = PlayerStats.instance.boost_max_power;
    }
    IEnumerator Boost()
    {
        av_boost -= 25;
        gravity = 0;
        boosting = true;
        boostPow = PlayerStats.instance.boost_power;
        yield return new WaitForSeconds(PlayerStats.instance.boost_capacity);
        boostPow = 1;
        boosting = false;
    }
    private void OnTriggerStay(Collider other)
    {
        if(other.transform.tag=="JumpPad")
        {
            gravity = 150;
        }
    }
    public void TakeDamage()
    {
        health--;
    }
    public void ResetHealth()
    {
        health = PlayerStats.instance.health;
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
        boostImg.fillAmount = av_boost / PlayerStats.instance.boost_max_power;
        Vector3 move = Vector3.zero;
        if (!boosting)
        {
            x = Input.GetAxisRaw("Horizontal") * speed;
            y = Input.GetAxisRaw("Vertical") * speed;
        }
        move = transform.forward * y * boostPow + transform.right * x * boostPow + transform.up*gravity;
        characterController.Move(move* boostPow * Time.deltaTime);
       
        if (Input.GetKeyDown(KeyCode.LeftShift)&&!boosting&&av_boost>25)
            StartCoroutine(Boost());
        if (Input.GetKeyDown(KeyCode.Space) && av_jumps>0)
            Jump();
        if (Input.GetKeyDown(KeyCode.LeftControl)&&gravity<-20)
            gravity = -150;
        CheckForGround();
    }
    void Fall()
    {
        gravity -= gravityScale;
        gravity = Mathf.Clamp(gravity, -150, 100);
        
    }
    private void FixedUpdate()
    {
        av_boost += PlayerStats.instance.boost_reload / 10;
        av_boost = Mathf.Clamp(av_boost, 0, PlayerStats.instance.boost_max_power);
        if(!boosting)
            Fall();
    }
}
