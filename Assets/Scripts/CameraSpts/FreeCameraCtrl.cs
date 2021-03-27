using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class FreeCameraCtrl : MonoBehaviour
{
    [SerializeField] private FixedJoystick joystick;
    [SerializeField] private GameObject FreeCameraUiParentObj;
    [SerializeField] private float RotationSpeed;
    [SerializeField] private GameObject FreeCameraParent;
    [SerializeField] private float MinFOV = 45;
    [SerializeField] private float MaxFOV = 75;
    [SerializeField] private float ZoomSpeed = 1;
    [SerializeField] private Camera _freeCamera;

    //hiding and showing UI Elements when switching to and from the other cameras
    public void HideUiElements(bool hidden)
    {
        if (hidden)
        {
            FreeCameraUiParentObj.SetActive(false);
        }
        else
        {
            FreeCameraUiParentObj.SetActive(true);
        }
        
    }

    //Camera Movement Controls
    public void TakeInput()
    {
        Vector3 joystickDirection = new Vector3(joystick.Direction.x, joystick.Direction.y,0 );
        //joystickDirection = FreeCameraParent.transform.TransformDirection(joystickDirection);
        joystickDirection.z = joystickDirection.y;
        joystickDirection.y = 0;

        FreeCameraParent.transform.Translate(joystickDirection, Space.Self);


        if (Input.touchCount > 0)
        {
            if (!EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))
            {
                if (Input.touchCount == 1)
                {
                    Touch touch = Input.GetTouch(0);
                    if (touch.phase == TouchPhase.Moved)
                    {
                        Vector2 vector2 = touch.deltaPosition;
                        Vector3 vector3 = new Vector3(0, vector2.x);
                        vector3 *= -1;
                        FreeCameraParent.transform.Rotate(vector3 * Time.deltaTime * RotationSpeed, Space.Self);
                    }
                }
                else if(Input.touchCount >= 2)
                {
                    Touch FirstTouch = Input.GetTouch(0);
                    Touch SecondTouch = Input.GetTouch(1);

                    Vector2 FirstPrevTouchPos = FirstTouch.position - FirstTouch.deltaPosition;
                    Vector2 SecondPrevTouchPos = SecondTouch.position - SecondTouch.deltaPosition;

                    float prevDistance = Vector2.Distance(FirstPrevTouchPos, SecondPrevTouchPos);
                    float currentDistance = Vector2.Distance(FirstTouch.position, SecondTouch.position);

                    float difference = currentDistance - prevDistance;
                    difference = -difference * ZoomSpeed;
                    float FOV = _freeCamera.fieldOfView;
                    FOV += difference;
                    FOV = Mathf.Clamp(FOV, MinFOV, MaxFOV);
                    _freeCamera.fieldOfView = FOV;
                }
            }
        }
        

    }

    private void Update()
    {
        TakeInput();
    }

}
