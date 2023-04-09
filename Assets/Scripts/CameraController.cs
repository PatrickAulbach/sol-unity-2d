using UnityEngine;
using Cinemachine;

public class CameraController : MonoBehaviour
{
    [SerializeField] float movementSpeed;
    [SerializeField] private CinemachineVirtualCamera cinemachineVirtualCamera;
    [SerializeField] int maxCameraDistance;
    [SerializeField] int minCameraDistance;
    private const int MAX_SCROLL = 50;
    private CinemachineComponentBase cinemachineComponentBase;

    void Update()
    {
        if (cinemachineComponentBase == null)
        {
            cinemachineComponentBase = cinemachineVirtualCamera.GetCinemachineComponent(CinemachineCore.Stage.Body);
        }
        HandleMovement();
        HandleZoom();
        Debug.Log(cinemachineVirtualCamera.m_Lens.OrthographicSize);

    }

    private void HandleZoom()
    {
        var mouseWheelInput = Input.mouseScrollDelta.y;
        
        if (cinemachineComponentBase is CinemachineFramingTransposer)
        {
            (cinemachineComponentBase as CinemachineFramingTransposer).m_CameraDistance -= mouseWheelInput * 1;
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

        Vector3 moveVector = transform.up * inputMoveDir.y + transform.right * inputMoveDir.x;
        transform.position += moveVector * movementSpeed * Time.deltaTime;
    }
}
