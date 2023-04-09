using UnityEngine;

public class Rotation : MonoBehaviour
{
    [SerializeField] float rotationSpeed;
    [SerializeField] GameObject rotationCenter;
    void Update()
    {
        transform.RotateAround(rotationCenter.transform.position, new Vector3(0, 0, 1), rotationSpeed * Time.deltaTime);
    }
}
