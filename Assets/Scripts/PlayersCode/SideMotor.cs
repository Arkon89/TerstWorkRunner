using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideMotor : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _bort;
    [SerializeField] private TouchPanel _touchPanel;
    private float _horizontal;

    private bool _letRun = true;


    private void FixedUpdate()
    {
#if UNITY_ANDROID
        if (!_touchPanel)
            Debug.Log($"Для скрипта SideMotor на объекте {gameObject.name } не назначен объект TouchPanel");
        else
        {
            _horizontal = _touchPanel.GetHorizontal();
            Debug.Log("_horizontal = " + _horizontal);
            //_horizontal = Mathf.Clamp(_horizontal, -1f, 1f);
            _horizontal /= 100f;
        }
#endif

        // #if UNITY_EDITOR
        //         _horizontal = Input.GetAxis("Horizontal");
        // #endif
        if (_horizontal != 0f)
        {
            // if (CheckGround())
            // {
            //     Move();
            // }
            Move();
        }
    }


    private bool CheckGround()
    {
        Vector3 newPosition = transform.position;

        newPosition.x += Normalise(_horizontal) * _bort;

        if (Physics.Raycast(newPosition, Vector3.down, out RaycastHit hitInfo))
        {
            if (hitInfo.collider.gameObject.TryGetComponent<Road>(out Road road))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }
    }


    private void Move()
    {
        Vector3 direction = transform.position + transform.right * _horizontal;
        Vector3 newPosition = Vector3.Lerp(transform.position, direction, _moveSpeed);
        transform.position = newPosition;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.TryGetComponent<TurnTrigger>(out TurnTrigger turnTrigger))
        {
            _letRun = false;
        }

        if (other.TryGetComponent<StrateEnterTrigger>(out StrateEnterTrigger strateEnterTrigger))
        {
            _letRun = true;
        }
    }

    private float Normalise(float volume)
    {
        if (volume > 0f)
            return 1f;
        else
            return -1f;
    }
}
