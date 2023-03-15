using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Tilemaps;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private Rigidbody rb;
    
    private Vector3 movement;
    private PlayerStateManager playerStateManager;
    private bool hasPlayerStateManager = true;
    public bool inversed;
    
    private Animator animator;
    private int isRunningHash;

    // Start is called before the first frame update
    void Start()
    {
        // Find the Player State Manager
        if ((playerStateManager = FindObjectOfType<PlayerStateManager>()) == null)
        {
            Debug.LogWarning("Cannot find object of type PlayerStateManager!");
            hasPlayerStateManager = false;
        }
        
        animator = GetComponent<Animator>();
        isRunningHash = Animator.StringToHash("isRunning");
    }

    // Update is called once per frame
    void Update()
    {
        if (inversed)
        {
            movement.x = -Input.GetAxisRaw("Vertical");
            movement.z = Input.GetAxisRaw("Horizontal");
        }
        else
        {
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.z = Input.GetAxisRaw("Vertical");
        }
    }

    void FixedUpdate()
    {
        // Used to stop the player during cinematic, dialogs, menu, ...
        if (hasPlayerStateManager && playerStateManager.PlayerState != PlayerState.PLAYING)
        {
            animator.SetBool(isRunningHash, false);
            return;
        }
        
        rb.MovePosition(rb.position + movement * (moveSpeed * Time.fixedDeltaTime));
        if (!movement.Equals(Vector3.zero))
        {
            transform.rotation = Quaternion.LookRotation(movement);
            animator.SetBool(isRunningHash, true);
        }
        else 
            animator.SetBool(isRunningHash, false);
    }
}
