using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    ToolPlayerController tool;
    InventoryControl inventory;

    [SerializeField] public int currentTool = 0;

    private const string _horizontal = "Horizontal";
    private const string _vertical = "Vertical";

    private float verticalInput;
    private float horizontalInput;
    private float speed = 2;

    private bool facingRight;
    private bool leftMouse;
    private bool isMoving;
    private bool isJumping;

    public Animator animator;
    private Vector3 direction;

    private void Awake()
    {
        tool = GetComponent<ToolPlayerController>();
        inventory = GetComponent<InventoryControl>();
    }
    private void FixedUpdate()
    {
        if (inventory.panelInventory.activeInHierarchy == false 
            && inventory.panelPauseGame.activeInHierarchy == false)
        {
            GetInput();
            Move();
            Jump();
            Attack();
            Cut();
            Dig();
            Watering();
        }
    }

    private void AnimateMovement(Vector3 direction)
    {
        if (animator != null)
        {
            if (direction.magnitude > 0)
            {
                animator.SetBool("isMoving", true);
                animator.SetFloat(_horizontal, direction.x);
                animator.SetFloat(_vertical, direction.y);
                Attack();
                Cut();
            }
            else
                animator.SetBool("isMoving", false);
        }
        if (facingRight) { transform.localScale = new Vector2(6, 6); }
        else if (!facingRight) { transform.localScale = new Vector2(-6, 6); }

    }

    private void GetInput()
    {
        horizontalInput = Input.GetAxis(_horizontal);
        verticalInput = Input.GetAxis(_vertical);

        isJumping = Input.GetKeyDown(KeyCode.Space);
        leftMouse = Input.GetMouseButtonDown(0);

        //if (Input.GetKeyDown(KeyCode.Alpha1)) { currentTool = 1; }
        //else if (Input.GetKeyDown(KeyCode.Alpha2)) { currentTool = 2; }
        //else if (Input.GetKeyDown(KeyCode.Alpha3)) { currentTool = 3; }
        //else if (Input.GetKeyDown(KeyCode.Alpha4)) { currentTool = 4; }
    }
    private void Move()
    {
        direction = new Vector3(horizontalInput, verticalInput);
        AnimateMovement(direction);
        transform.position += direction * speed * Time.deltaTime;

        if (Input.GetAxisRaw(_horizontal) > 0.5) { facingRight = true; }
        if (Input.GetAxisRaw(_horizontal) < -0.5) { facingRight = false; }
    }
    private void Jump()
    {
        if (isJumping) animator.SetBool("isJumping", true);
        else animator.SetBool("isJumping", false);
    }
    private void Attack()
    {
        if (currentTool == 1 && leftMouse) animator.SetBool("isAttack", true);
        else animator.SetBool("isAttack", false);
    }
    private void Cut()
    {
        if (currentTool == 2 && leftMouse) 
        { 
            animator.SetBool("isCut", true);
            tool.UseTool();
        }
        else animator.SetBool("isCut", false);
    }
    private void Dig()
    {
        if (currentTool == 3 && leftMouse) animator.SetBool("isDig", true);
        else animator.SetBool("isDig", false);
    }
    private void Watering()
    {
        if (currentTool == 4 && Input.GetMouseButton(0)) animator.SetBool("isWatering", true);
        else animator.SetBool("isWatering", false);
    }

}
