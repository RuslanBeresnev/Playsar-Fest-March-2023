using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private Rect levelBound;
    [SerializeField] private float smoothness = 5f;

    private Rect cameraBound;

    private void Awake()
    {
        Vector3 cameraPosition = Camera.main.transform.position;
        float cameraHeight = 2f * Camera.main.orthographicSize;
        float cameraWidth = cameraHeight * Camera.main.aspect;

        cameraBound = new Rect(cameraPosition.x, cameraPosition.y, cameraWidth, cameraHeight);

    }

    private void FixedUpdate()
    {
        FollowTarget();
    }

    private void FollowTarget()
    {
        Vector3 targetPosition = target.position;
        Vector3 cameraPosition = transform.position;
        Vector3 delta = targetPosition - cameraPosition;
        float x = cameraPosition.x + delta.x;
        float y = cameraPosition.y + delta.y;
        Vector3 newPosition = Vector3.Lerp(cameraPosition, new Vector3(x, y, cameraPosition.z), Time.fixedDeltaTime * smoothness);
        transform.position = newPosition;
    }

    //private void OnDrawGizmosSelected()
    //{
    //    Gizmos.color = Color.green;
    //    Gizmos.DrawWireCube(levelBound.center, levelBound.size);
    //}

    //public Vector3 Clamp(Vector3 position)
    //{
    //    position.x = Mathf.Clamp(position.x, levelBound.xMin + cameraBound.width / 2f, levelBound.xMax - cameraBound.width / 2f);
    //    position.y = Mathf.Clamp(position.y, levelBound.yMin + cameraBound.height / 2f, levelBound.yMax - cameraBound.height / 2f);
    //    return position;
    //}
}
