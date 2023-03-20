using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Cinemachine;

public class PlayerMovement : MonoBehaviour
{
    private NavMeshAgent nav;
    private Animator anim;
    private Ray ray;
    private RaycastHit hit;

    private float x;
    private float z;
    private float velocitySpeed;

    CinemachineTransposer ct;
    public CinemachineVirtualCamera playerCam;
    private Vector3 position;
    private Vector3 currentPosition;

    public static bool canMove = true;
    public LayerMask moveLayer;

    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        
        ct = playerCam.GetCinemachineComponent<CinemachineTransposer>();
        currentPosition = ct.m_FollowOffset;
    }

    void Update()
    {
        // Calculate velocity speed.
        x = nav.velocity.x;
        z = nav.velocity.z;
        velocitySpeed = x + z;

        // Get mouse postition.
        position = Input.mousePosition;
        ct.m_FollowOffset = currentPosition; // 0, 7.99, -4.19

        // Detect left click and move character.
        if (Input.GetMouseButtonDown(0))
        {
            if (canMove)
            {
                ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out hit, 300, moveLayer))
                {
                    nav.SetDestination(hit.point);
                }
            }   
        }

        // Animate character.
        if (velocitySpeed != 0)
        {
            anim.SetBool("Sprinting", true);
        } else {
            anim.SetBool("Sprinting", false);
        }

        // Detect right click and move camera.
        if (Input.GetMouseButton(1))
        {
            if (position.x != 0 || position.y != 0)
            {
                currentPosition = position / 150;
            }
        }
    }
}
