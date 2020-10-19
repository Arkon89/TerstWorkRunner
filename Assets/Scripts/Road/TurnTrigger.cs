using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnTrigger : MonoBehaviour
{
    [SerializeField] private float _angle;
    [SerializeField] private Transform _turnCenter;
    public float GetAngle()
    {
        return _angle;
    }

    public Vector3 GetCentrOfRotation()
    {
        return _turnCenter.position;
    }
}
