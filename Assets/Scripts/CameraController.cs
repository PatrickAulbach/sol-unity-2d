using UnityEngine;
using Cinemachine;

public class CameraController : MonoBehaviour
{
    [SerializeField] float movementSpeed;
    [SerializeField] private CinemachineVirtualCamera cinemachineVirtualCamera;
    private const int MAX_CAMERA_DISTANCE = 50;
    private const int MIN_CAMERA_DISTANCE = 3;
    private const int MAX_SCROLL = 50;
    private const int SCROLL_SPEED = 1;
    private const float MAX_CAMERA_DISTANCE_SCALE = 1.5f;
    private const int INITAL_CAMERA_DISTANCE = 10;
    private CinemachineComponentBase cinemachineComponentBase;
    private float cameraDistanceScale;

    void Update()
    {
        if (cinemachineComponentBase == null)
        {
            cinemachineComponentBase = cinemachineVirtualCamera.GetCinemachineComponent(CinemachineCore.Stage.Body);
        }
        
        var scale = (cinemachineComponentBase as CinemachineFramingTransposer).m_CameraDistance / INITAL_CAMERA_DISTANCE;
        cameraDistanceScale = scale <= MAX_CAMERA_DISTANCE_SCALE ? scale : MAX_CAMERA_DISTANCE_SCALE;
        HandleMovement();
        HandleZoom();

    }

    private void HandleZoom()
    {
        var mouseWheelInput = Input.mouseScrollDelta.y;
        
        if (cinemachineComponentBase is CinemachineFramingTransposer)
        {
            if (mouseWheelInput < 0 && (cinemachineComponentBase as CinemachineFramingTransposer).m_CameraDistance > MAX_CAMERA_DISTANCE)
            {
                return;
            }
            else if (mouseWheelInput > 0 && (cinemachineComponentBase as CinemachineFramingTransposer).m_CameraDistance <= MIN_CAMERA_DISTANCE)
            {
                return;
            }
            (cinemachineComponentBase as CinemachineFramingTransposer).m_CameraDistance -= mouseWheelInput * SCROLL_SPEED;
        }
    }

    private void HandleRotation()
    {
        Vector3 rotationVector = new Vector3(0, 0, 0);

        if (Input.GetKey(KeyCode.Q))
        {
            rotationVector.y += 1f;
        }
        if (Input.GetKey(KeyCode.E))
        {
            rotationVector.y -= 1f;
        }

        float rotationSpeed = 100f;

        transform.eulerAngles += rotationVector * rotationSpeed * Time.deltaTime;
    }

    private void HandleMovement()
    {
        Vector3 inputMoveDir = new Vector3(0, 0, 0);

        if (Input.GetKey(KeyCode.W) && transform.position.y < MAX_SCROLL)
        {
            inputMoveDir.y += 1f;
        }
        if (Input.GetKey(KeyCode.S) && transform.position.y > -MAX_SCROLL)
        {
            inputMoveDir.y -= 1f;
        }
        if (Input.GetKey(KeyCode.A) && transform.position.x > -MAX_SCROLL)
        {
            inputMoveDir.x -= 1f;
        }
        if (Input.GetKey(KeyCode.D) && transform.position.x < MAX_SCROLL)
        {
            inputMoveDir.x += 1f;
        }

        Vector3 moveVector = transform.up * inputMoveDir.y * cameraDistanceScale + transform.right * inputMoveDir.x * cameraDistanceScale;
        transform.position += moveVector * movementSpeed * Time.deltaTime;
    }
}
