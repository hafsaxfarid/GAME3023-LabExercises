using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField]
    [Range(0, 10)]
    float moveSpeed = 3;

    //[SerializeField]
    private Rigidbody2D playerRB;

    [Header("Animation")]
    public PlayerAnimationState playerAnimationState;

    [Header("Enemy Encounter")]
    public LayerMask encounterLayer;
    //public bool enemyEncountered = false;

    private Animator playerAnimationController;
    private string animationState = "AnimationState";

    private void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
        playerAnimationController = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        if(GameManager.gmInstance.state == GameState.FreeRoam)
        {
            MovePlayer();
        }
        else
        {
            Debug.Log("In Battle");
        }
    }

    private void MovePlayer()
    {
        float inputX = Input.GetAxisRaw("Horizontal");
        float inputY = Input.GetAxisRaw("Vertical");

        if (inputX > 0) // moving right
        {
            playerAnimationController.SetInteger(animationState, (int)PlayerAnimationState.WALK_RIGHT);
            playerAnimationState = PlayerAnimationState.WALK_RIGHT;
        }
        else if (inputX < 0) // moving left
        {
            playerAnimationController.SetInteger(animationState, (int)PlayerAnimationState.WALK_LEFT);
            playerAnimationState = PlayerAnimationState.WALK_LEFT;
        }
        else if (inputY > 0) // moving up
        {
            playerAnimationController.SetInteger(animationState, (int)PlayerAnimationState.WALK_UP);
            playerAnimationState = PlayerAnimationState.WALK_UP;
        }
        else if (inputY < 0) // moving down
        {
            playerAnimationController.SetInteger(animationState, (int)PlayerAnimationState.WALK_DOWN);
            playerAnimationState = PlayerAnimationState.WALK_DOWN;
        }
        else // idle when not moving
        {
            playerAnimationController.SetInteger(animationState, (int)PlayerAnimationState.IDLE);
            playerAnimationState = PlayerAnimationState.IDLE;
        }
     
        playerRB.velocity = new Vector3(inputX, inputY, 0) * moveSpeed;
        CheckEncounter();
    }

    private void CheckEncounter()
    {
        if (Physics2D.OverlapCircle(transform.position, 0.03f, encounterLayer) != null)
        {
            if (Random.Range(1, 101) <= 10)
            {
                //Debug.Log("Enemy Encounter!");
                AudioManager.amInstance.CrossFade(TrackID.Battle, 1f);
                GameManager.gmInstance.state = GameState.BattleMode;
            }
        }
    }
}
