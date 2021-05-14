using System;
using System.Collections;
using UnityEngine;


public class TouchController : MonoBehaviour
{
    public static TouchController Instance;
    public bool isTouch = false;
    
    [SerializeField] private float tickTime = 0.1f;
    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        StartCoroutine(TickTouchRoutine());
    }

    private IEnumerator TickTouchRoutine()
    {
        while (true)
        {
            if (Input.GetMouseButton(0))
            {
                isTouch = true;
            }
            
            yield return new WaitForSeconds(tickTime);
        }
    }
}