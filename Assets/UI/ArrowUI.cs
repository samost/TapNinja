using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class ArrowUI : MonoBehaviour
{
    private List<GameObject> _currentArrowQueue;


    private void Start()
    {
        _currentArrowQueue = new List<GameObject>();
    }

    public void UpdateUIArrow(List<String> typeSwipe)
    {
        int num = typeSwipe.Count - 1;
        foreach (Transform uiArrows in transform)
        {
            
            foreach (Transform uiArrow in uiArrows.transform)
            {
                if (uiArrow.CompareTag(typeSwipe[num]))
                {
                    uiArrow.gameObject.SetActive(true);
                   _currentArrowQueue.Add(uiArrow.gameObject);
                }
            }
            num--;
        }
    }

    public void CompleteArrow()
    {
        _currentArrowQueue[0].SetActive(false);
        _currentArrowQueue.RemoveAt(0);
    }
}