using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TPSController : MonoBehaviour
{
    // Start is called before the first frame update
    
    [Header("Transforms")]
    public CharacterController controller;
    public Transform cam;
    public Transform hand;
    public GameObject ProjectilePrefab;
    Animator anim;
    public Vector3 offset;
    
    [Header("Speeds")]
    public float speed = 6f;

    Vector3 velocity;
    public float gravity = -9.81f;

    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;
        //set gravity
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        if (direction.magnitude >= 0.1f)
        {

            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDir.normalized * speed * Time.deltaTime);
            anim.SetBool("isWalking", true);
        }
        else
        {
            anim.SetBool("isWalking", false);
        }
        //Launch Projectile
        if (Input.GetKeyDown(KeyCode.F))
        {
            anim.SetTrigger("Throw");
        }

    
    }
    void DelayedProjectile()
    {
        GameObject steak = Instantiate(ProjectilePrefab, hand.position, transform.rotation);
        Destroy(steak, 3);
    }
}