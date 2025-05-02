using UnityEngine;

public class Move3DSpace : MonoBehaviour
{
    float objPosZ;

    private void Start()
    {
        objPosZ = transform.position.z;
    }

    void OnMouseDrag()
    {
        Vector3 objPos = Camera.main.WorldToScreenPoint(transform.position);

        Vector3 mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, objPos.z);

        transform.position = Camera.main.ScreenToWorldPoint(mousePos);
    }

    private void Update()
    {
        float wheelValue = Input.GetAxis("Mouse ScrollWheel");

        if (wheelValue == 0)
        {
            return;
        }

        objPosZ += wheelValue;

        transform.position = new Vector3(transform.position.x, transform.position.y, objPosZ);
    }
}
