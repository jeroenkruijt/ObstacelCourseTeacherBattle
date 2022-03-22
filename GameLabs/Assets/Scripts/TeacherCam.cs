using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

namespace Scripts
{
    public class TeacherCam : MonoBehaviour
    {
      
    #region Variables
    
    [SerializeField, Tooltip("Pan speed multiplier")]
    private float panSpeed = 2f;
    [SerializeField, Tooltip("Zoom speed multiplier")]
    private float zoomSpeed = 3f;
    [SerializeField, Tooltip("Maximum zoom in FOV value")]
    private float zoomInMax = 40f;
    [SerializeField, Tooltip("Maximum zoom out FOV value")]
    private float zoomOutMax = 90f;

    private CinemachineInputProvider inputProvider;
    private CinemachineVirtualCamera virtualCamera;
    private Transform cameraTransform;

    #endregion Variables

    private void Awake() {
        inputProvider = GetComponent<CinemachineInputProvider>();
        virtualCamera = GetComponent<CinemachineVirtualCamera>();
        cameraTransform = virtualCamera.VirtualCameraGameObject.transform;
    }

    void Update()
    {
        // Get input
        float x = inputProvider.GetAxisValue(0);
        float y = inputProvider.GetAxisValue(1);
        float z = inputProvider.GetAxisValue(2);
        // Call pan and zoom scripts if input not zero
        if (x != 0 || y != 0) {
            PanScreen(x, y);
        }
        if (z != 0) {
            ZoomScreen(z);
        }
    }

    #region Zoom

    
    /// Zooms in or out using Cinemachine Field of View (FOV)
    public void ZoomScreen(float increment) {
        float fov = virtualCamera.m_Lens.FieldOfView;
        float target = Mathf.Clamp(fov + increment, zoomInMax, zoomOutMax);
        virtualCamera.m_Lens.FieldOfView = Mathf.Lerp(fov, target, zoomSpeed * Time.deltaTime);
    }

    #endregion Zoom

    #region pan
    
    ///Vector2 direction to pan in
    public Vector2 PanDirection(float x, float y) {
        Vector2 direction = Vector2.zero;
        if (y >= Screen.height * .95f) {
            direction.y += 1;
        }
        else if (y <= Screen.height * 0.05f) {
            direction.y -= 1;
        }
        if (x >= Screen.width * 0.95f) {
            direction.x += 1;
        }
        else if (x <= Screen.width * 0.05f) {
            direction.x -= 1;
        }
        return direction;
    }

    
    /// Pan the camera depending on the mouse position
    /// Current x mouse position in screen coordinates
    /// Current y mouse position in screen coordinates
    public void PanScreen(float x, float y) {
        Vector2 direction = PanDirection(x, y);
        cameraTransform.position = Vector3.Lerp(cameraTransform.position,
                                                cameraTransform.position + (Vector3)direction,
                                                panSpeed * Time.deltaTime);
    }
    #endregion pan
    }
}
