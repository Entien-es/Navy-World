using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour, IDataPersistence
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
    private bool isDash;
    private bool isJumping;

    public Animator animator;
    private Vector3 direction;
    private SpriteRenderer sprRender;

    [SerializeField] AudioSource playerSrc;
    [SerializeField] AudioSource playerSFX;

    public AudioClip move;
    public AudioClip dash;
    public AudioClip jump;

    public AudioClip attack;
    public AudioClip axe;
    public AudioClip dig;
    public AudioClip seed;
    public AudioClip pickaxe;
    public AudioClip watering;

    private void Awake()
    {
        tool = GetComponent<ToolPlayerController>();
        inventory = GetComponent<InventoryControl>();
        sprRender = GetComponent<SpriteRenderer>();
        item.Name = "Sword";
    }

    [Obsolete]
    private void FixedUpdate()
    {
        if (inventory.panelInventory.activeInHierarchy == false 
            && inventory.panelPauseGame.activeInHierarchy == false)
        {
            try
            {
                item = toolbar.GetItem;
                GetInput();
                Move();
                Dash();
                Jump();
                Attack();
                Cut();
                Pickaxe();
                Dig();
                Watering();
                inventory.panelToolbar.active = false;
                inventory.panelToolbar.active = true;
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
                SRC(playerSrc, move);
            }
            else { animator.SetBool("isMoving", false); }
        }
        sprRender.flipX = !facingRight;
    }

    private void GetInput()
    {
        horizontalInput = Input.GetAxis(_horizontal);
        verticalInput = Input.GetAxis(_vertical);

        isDash = Input.GetKey(KeyCode.LeftShift);
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
    private void Dash()
    {
        if (isDash)
        {
            speed = 4;
            animator.SetBool("isDash", true);
            SRC(playerSrc, dash);
        }
        else 
        { 
            speed = 2;
            animator.SetBool("isDash", false); 
        }
    }
    private void Jump()
    {
        if (isJumping)
        {
            animator.SetBool("isJumping", true);
            SRC(playerSrc, jump);
        }
        else animator.SetBool("isJumping", false);
    }
    private void Attack()
    {
        if (item.Name == "Sword" && leftMouse)
        {
            animator.SetBool("isAttack", true);
            SFX(playerSFX, attack);
        }
        else animator.SetBool("isAttack", false);
    }
    private void Cut()
    {
        if (item.Name == "Axe" && leftMouse)
        { 
            animator.SetBool("isCut", true);
            tool.UseTool();
            SFX(playerSFX, axe);
        }
        else animator.SetBool("isCut", false);
    }
    private void Pickaxe()
    {
        if (item.Name == "Pickaxe" && leftMouse)
        {
            animator.SetBool("isMining", true);
            tool.UseTool();
            SFX(playerSFX, pickaxe);
        }
        else animator.SetBool("isMining", false);
    }

    [Obsolete]
    private void Dig()
    {
        tool.SelectedTile();
        tool.CanSelectCheck();
        tool.Marker();

        if (item.Name == "Plow" && leftMouse)
        {
            animator.SetBool("isDig", true);
            tool.UseToolGrid();
            SFX(playerSFX, dig);
        } 
        else animator.SetBool("isDig", false);
        if (item.Name == "Seeds" && leftMouse)
        {
            animator.SetBool("doSomething", true);
            tool.UseToolGrid();
            SFX(playerSFX, seed);
        }
        else animator.SetBool("doSomething", false);
    }
    private void Watering()
    {
        if (item.Name == "Water" && leftMouse)
        {
            animator.SetBool("isWatering", true);
            SFX(playerSFX, watering);
        }
        else
        {
            animator.SetBool("isWatering", false);
        }
    }
    private void SRC(AudioSource src, AudioClip clip)
    {
        src.clip = clip;
        if (!src.isPlaying) { src.PlayOneShot(clip); }
    }
    private void SFX(AudioSource src, AudioClip clip)
    {
        src.clip = clip;
        if (!src.isPlaying) { src.PlayOneShot(clip); }
    }
    public void LoadData(GameData data)
    {
        transform.position = data.playerPosition;
    }

    public void SaveData(ref GameData data)
    {
        data.playerPosition = transform.position;
    }
}
