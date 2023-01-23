using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [Header("Controls")]
    [Range(1, 10)][SerializeField] private int _horizontalSensibility = 5;
    [Range(1, 10)][SerializeField] private int _verticalSensibility = 5;
    [Range(1, 2)][SerializeField] private float _mouseSensibility = 1.5f;
    [Range(1, 10)][SerializeField] private int _boostFactor = 2;

    private const float ACCELERATION_RATE = 3;
    private const float BOOST_ACCELERATION_RATE = 2;
    private float _boostAcceleration;
    private float yPos;
    private float _xAngle;
    private float _yAngle;

    private void Start()
    {
        if (Camera.main.transform.localEulerAngles.x > 180)
        {
            _xAngle = 360 - Camera.main.transform.localEulerAngles.x;
        }
        else
        {
            _xAngle = -Camera.main.transform.localEulerAngles.x;
        }
        _yAngle = Camera.main.transform.eulerAngles.y;
    }

    void Update()
    {
        MoveCamera();
        RotateCamera();
    }

    private void MoveCamera()
    {
        float boost = 1;
        if (Input.GetKey(KeyCode.LeftShift))
        {
            boost *= _boostFactor + _boostAcceleration * BOOST_ACCELERATION_RATE;
            _boostAcceleration += Time.deltaTime;
        }
        else
        {
            _boostAcceleration = 0;
        }

        float zPos = Input.GetAxis("Vertical") * _horizontalSensibility * boost * Time.deltaTime;
        float xPos = Input.GetAxis("Horizontal") * _horizontalSensibility * boost * Time.deltaTime;

        if (Input.GetKey(KeyCode.E))
        {
            yPos += Time.deltaTime * ACCELERATION_RATE;
            yPos = Mathf.Clamp(yPos, 0, 1);
        }
        else if (Input.GetKey(KeyCode.Q))
        {
            yPos -= Time.deltaTime * ACCELERATION_RATE;
            yPos = Mathf.Clamp(yPos, -1, 0);
        }
        else
        {
            if (yPos > 0)
            {
                yPos -= Time.deltaTime * ACCELERATION_RATE;
                yPos = Mathf.Clamp(yPos, 0, 1);
            }
            else
            {
                yPos += Time.deltaTime * ACCELERATION_RATE;
                yPos = Mathf.Clamp(yPos, -1, 0);
            }
        }
        Camera.main.transform.Translate(new Vector3(xPos, yPos * _verticalSensibility * boost * Time.deltaTime, zPos), Space.Self);
    }

    private void RotateCamera()
    {
        if (Input.GetKey(KeyCode.Mouse1))
        {
            _xAngle += Input.GetAxisRaw("Mouse Y") * _mouseSensibility;
            _xAngle = Mathf.Clamp(_xAngle, -90, 90);
            _yAngle += Input.GetAxisRaw("Mouse X") * _mouseSensibility;

            Camera.main.transform.eulerAngles = new Vector3(-_xAngle, _yAngle, 0f);
        }
    }
}
