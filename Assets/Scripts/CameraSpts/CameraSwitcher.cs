using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{
    [SerializeField] private Camera _planningViewCamera;
    [SerializeField] private Camera _freeCamera;

    public static Camera ActiveCamera { get ; private set; }

    PlanningViewCameraCtrl _planningViewCameraCtrl;
    FreeCameraCtrl _freeCameraCtrl;
    void Start()
    {
        _freeCamera.gameObject.SetActive(false);
        ActiveCamera = _planningViewCamera;

        _planningViewCameraCtrl = gameObject.GetComponent<PlanningViewCameraCtrl>();
        _freeCameraCtrl = gameObject.GetComponent<FreeCameraCtrl>();
    }

    public void SwitchCameras()
    {
        //from PlanningView to FreeCamera
        if (_planningViewCamera.gameObject.activeSelf)
        {
            _freeCameraCtrl.HideUiElements(false);
            _freeCamera.gameObject.SetActive(true);
            ActiveCamera = _planningViewCamera;

            _planningViewCamera.gameObject.SetActive(false);
            _planningViewCameraCtrl.CloseMenus();
        }
        else //from FreeCamera to PlanningView
        {
            _planningViewCamera.gameObject.SetActive(true);
            ActiveCamera = _planningViewCamera;

            _freeCameraCtrl.HideUiElements(true);
            _freeCamera.gameObject.SetActive(false);
        }
    }

}
