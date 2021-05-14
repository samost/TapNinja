using UnityEngine;
using BzKovSoft.ObjectSlicer;
using System.Diagnostics;
using System;
using Debug = UnityEngine.Debug;

public class SlicerController : MonoBehaviour
{
    int _sliceId = 0;
    public Transform target;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            ++_sliceId;

            foreach (Transform target in gameObject.transform)
            {
                IBzSliceable sliceable = target.GetComponentInParent<IBzSliceable>();
                IBzSliceableAsync sliceableA = target.GetComponentInParent<IBzSliceableAsync>();

                Plane plane = new Plane(target.right, target.position);
                if (sliceable != null)
                    sliceable.Slice(plane);
                if (sliceableA != null)
                    sliceableA.Slice(plane, 0, null);
            }
        }
    }
}