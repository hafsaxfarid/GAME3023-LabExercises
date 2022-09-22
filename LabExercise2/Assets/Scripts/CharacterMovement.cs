using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField]
    Rigidbody2D playerRB;

    [SerializeField]
    [Range(0, 10)]
    float moveSpeed = 3;
    
    void Start()
    {
            
    }
    
    void Update()
    {
        float inputX = Input.GetAxisRaw("Horizontal");
        float inputY = Input.GetAxisRaw("Vertical");

        playerRB.velocity = new Vector3(inputX, inputY, 0) * moveSpeed;
    }
}
