using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField]
    [Range(0, 10)]
    float moveSpeed = 1;
    
    void Start()
    {
            
    }
    
    void Update()
    {
        float inputX = Input.GetAxisRaw("Horizontal");
        float inputY = Input.GetAxisRaw("Vertical");

        Vector3 currentPosition = transform.position;

        transform.position = currentPosition + new Vector3(inputX, inputY, 0) * moveSpeed * Time.deltaTime;
    }
}
