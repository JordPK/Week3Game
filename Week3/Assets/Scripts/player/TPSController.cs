using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TPSController : MonoBehaviour
{
    // Start is called before the first frame update
    public CharacterController controller;
    public Transform cam;
    Animator anim;
    public GameObject ProjectilePrefab;
    public Vector3 offset;
    public float speed = 6f;

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
            GameObject steak = Instantiate(ProjectilePrefab, transform.position + offset, transform.rotation);
            Destroy(steak, 3);
        }
    }
}