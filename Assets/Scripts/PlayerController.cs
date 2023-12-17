using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] ToolbarController toolbar;
    [SerializeField] Item item;
    ToolPlayerController tool;
    InventoryControl inventory;

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
    private SpriteRenderer sprRender;

    private void Awake()
    {
        tool = GetComponent<ToolPlayerController>();
        inventory = GetComponent<InventoryControl>();
        sprRender = GetComponent<SpriteRenderer>();
        item.Name = "Sword";
    }
    private void Update()
    {
        if (inventory.panelInventory.activeInHierarchy == false 
            && inventory.panelPauseGame.activeInHierarchy == false)
        {
            try
            {
                item = toolbar.GetItem;
                GetInput();
                Move();
                Jump();
                Attack();
                Cut();
                Pickaxe();
                Dig();
                Watering();
            }
            catch { }
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
            }
            else { animator.SetBool("isMoving", false); }
        }
        sprRender.flipX = !facingRight;
    }

    private void GetInput()
    {
        horizontalInput = Input.GetAxis(_horizontal);
        verticalInput = Input.GetAxis(_vertical);

        isJumping = Input.GetKeyDown(KeyCode.Space);
        leftMouse = Input.GetKeyDown(KeyCode.Mouse0);
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
        if (isJumping)
        {
            animator.SetBool("isJumping", true);
        }
        else animator.SetBool("isJumping", false);
    }
    private void Attack()
    {
        if (item.Name == "Sword" && leftMouse)
        {
            animator.SetBool("isAttack", true);
        }
        else animator.SetBool("isAttack", false);
    }
    private void Cut()
    {
        if (item.Name == "Axe" && leftMouse)
        { 
            animator.SetBool("isCut", true);
            tool.UseTool();
        }
        else animator.SetBool("isCut", false);
    }
    private void Pickaxe()
    {
        if (item.Name == "Pickaxe" && leftMouse)
        {
            animator.SetBool("isMining", true);
            tool.UseTool();
        }
        else animator.SetBool("isMining", false);
    }
    private void Dig()
    {
        tool.SelectedTile();
        tool.CanSelectCheck();
        tool.Marker();
        
        if (item.Name == "Shovel" && leftMouse)
        {
            animator.SetBool("isDig", true);
            tool.UseToolGrid();
        } 
        else animator.SetBool("isDig", false);
    }
    private void Watering()
    {
        if (item.Name == "Water" && leftMouse) animator.SetBool("isWatering", true);
        else animator.SetBool("isWatering", false);
    }

}
