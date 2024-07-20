using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject target;
    public Vector2[] minBounds;
    public Vector2[] maxBounds;
    
    public float smoothTime = 0.3f;
    private Vector3 velocity = Vector3.zero;
    private void Update()
    {
        if (target == null)
        {
            target = GameObject.FindGameObjectWithTag("PlayerA");
            if (target == null)
            {
                return;
            }
        }
    }
    void LateUpdate()
    {
        if (target != null)
        {
            
            Vector3 targetPosition = target.transform.position;

            // Giới hạn tọa độ của camera trong phạm vi minBounds và maxBounds
            targetPosition.x = Mathf.Clamp(targetPosition.x, minBounds[0].x, maxBounds[0].x);
            targetPosition.y = Mathf.Clamp(targetPosition.y, minBounds[0].y, maxBounds[0].y);
            targetPosition.z = transform.position.z; // Giữ nguyên tọa độ z của camera

            // Dịch chuyển camera mềm mại đến vị trí mới
            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
        }
    }
}
