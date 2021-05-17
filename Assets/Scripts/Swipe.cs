using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using Random = UnityEngine.Random;


[Serializable] public class UnityEventString:UnityEvent<List<string>> {}
[Serializable] public class CompleteArrow:UnityEvent {}

[Serializable] public class StartAnimation:UnityEvent {}
public class Swipe : MonoBehaviour
{
    [SerializeField] private List<String> swipesType;
    
    [SerializeField] private int _countSwipe = 5;
    
    private List<string> _currentSwipeSequence;

    public UnityEventString UpdateUI;
    public CompleteArrow CompleteArrow;
    public StartAnimation Attack;

    private bool _isSlow = false;
    private void Start()
    {
        _currentSwipeSequence = new List<string>();
        UpdateSequence();
    }

    private void UpdateSequence()
    {
        for (int i = 0; i < _countSwipe; i++)
        {
            _currentSwipeSequence.Add(swipesType[Random.Range(0, swipesType.Count)]);
        }
        
        UpdateUI.Invoke(_currentSwipeSequence);
    }

    public void CheckSwipe(string swipeType)
    {
        
        if (swipeType == _currentSwipeSequence.Last())
        {
            if (!_isSlow)
            {
                _isSlow = true;
                StartCoroutine(SetSlowMotionRoutine());
            }
            
            _currentSwipeSequence.RemoveAt(_currentSwipeSequence.Count - 1);
            CompleteArrow.Invoke();
            
            if (_currentSwipeSequence.Count == 0)
            {
                Attack.Invoke();
                Invoke("UpdateSequence", 2.5f);
                _isSlow = false;
            }
        }
    }

    private IEnumerator SetSlowMotionRoutine()
    {
        while (_isSlow)
        {
            Time.timeScale = 0.2f;
            yield return null;
        }

        Time.timeScale = 1f;
    }
    
    
}
