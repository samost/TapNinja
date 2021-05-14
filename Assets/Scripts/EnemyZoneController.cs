using System.Collections;
using UnityEngine;

public class EnemyZoneController : MonoBehaviour
{
    private static int _countTouch;
    
    private void OnTriggerEnter(Collider other)
    {
        StartCoroutine(GetCountTouchCount());
    }

    private void OnTriggerExit(Collider other)
    {
        StopCoroutine(GetCountTouchCount());
    }

    private IEnumerator GetCountTouchCount()
    {
        if (TouchController.Instance.isTouch)
        {
            _countTouch++;
            
            yield return null;
        }
        
    }
}
