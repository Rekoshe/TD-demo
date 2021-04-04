using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PlanningViewCameraCtrl : MonoBehaviour
{
    [SerializeField] private Text _fpsText;
    [SerializeField] private float _hudRefreshRate = 1f;
    [SerializeField] private float CameraPanSpeed;
    [SerializeField] private float ZoomSpeed;
    [SerializeField] private float ZoomMax;
    [SerializeField] private float ZoomMin;
    [SerializeField] private Camera _planningViewCamera;
    [SerializeField] private GameObject TurretSelectionMenu;

    private TurretSpt selectedTurret;
    private TurretMenuController turretMenu;

    private float _timer;

    private void Start()
    {
        turretMenu = gameObject.GetComponent<TurretMenuController>();
    }

    private void Update()
    {
        if (Time.unscaledTime > _timer)
        {
            int fps = (int)(1f / Time.unscaledDeltaTime);
            _fpsText.text = "FPS: " + fps;
            _timer = Time.unscaledTime + _hudRefreshRate;
        }

        TakeInput();
    }

    public void TakeInput()
    {

        // Check if there is a touch
        if (Input.touchCount > 0)
        {
            // Check if finger is over a UI element 
            if (EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))
            {
                
                //so when the user touched the UI(buttons) call your UI methods 
            }
            else
            {
                HandleTouchOutSideUI();
                //so here call the methods you call when your other in-game objects are touched 
            }
        }


        
    }

    private void HandleTouchOutSideUI()
    {
        if (Input.touchCount == 1)
        {
            

            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Moved)
            {
                Vector2 vector2 = touch.deltaPosition;
                Vector3 vector3 = new Vector3(vector2.x, vector2.y);
                vector3 *= -1;
                _planningViewCamera.transform.Translate(vector3 * Time.deltaTime * CameraPanSpeed);
            }
            else if (touch.phase == TouchPhase.Began)
            {
                RaycastHit[] raycasts =
                    Physics.RaycastAll(_planningViewCamera.ScreenToWorldPoint(touch.position),
                    Vector3.down);

                RaycastHit raycastHit = default;

                for (int i = 0; i < raycasts.Length; i++)
                {

                    if (raycasts[i].collider.gameObject.name == "UICollider")
                    {
                        raycastHit = raycasts[i];

                    }
                }

                if (raycastHit.collider != null)
                {
                    selectedTurret = raycastHit.collider.GetComponentInParent<TurretSpt>();
                    turretMenu.SetSelectedTurret(selectedTurret);
                    
                    turretMenu.OpenMenu(true);
                    
                    //Debug.Log(selectedTurret.gameObject.name);
                }
                else
                {
                    turretMenu.OpenMenu(false);
                }


            }


        }
        else if (Input.touchCount >= 2)
        {
            Touch FirstTouch = Input.GetTouch(0);
            Touch SecondTouch = Input.GetTouch(1);

            Vector2 FirstPrevTouchPos = FirstTouch.position - FirstTouch.deltaPosition;
            Vector2 SecondPrevTouchPos = SecondTouch.position - SecondTouch.deltaPosition;

            float prevDistance = Vector2.Distance(FirstPrevTouchPos, SecondPrevTouchPos);
            float currentDistance = Vector2.Distance(FirstTouch.position, SecondTouch.position);

            float difference = currentDistance - prevDistance;
            _planningViewCamera.orthographicSize = Mathf.Clamp(_planningViewCamera.orthographicSize - difference * ZoomSpeed, ZoomMin, ZoomMax);
        }
    }
    public void CloseMenus()
    {
        turretMenu.OpenMenu(false);
    }

    public void OpenTurretSelectionMenu()
    {
        if (TurretSelectionMenu.activeSelf)
        {
            TurretSelectionMenu.SetActive(false);
            return;
        }
        TurretSelectionMenu.SetActive(true);
    }
    
}

