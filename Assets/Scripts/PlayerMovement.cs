using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float Speed;
    [SerializeField] private Animator animator;
    void Update()
    {
        transform.position += Vector3.forward * (Time.deltaTime * Speed);

        if (Input.GetKeyDown(KeyCode.A))
        {
            animator.SetTrigger("1");
        }
    }
}
