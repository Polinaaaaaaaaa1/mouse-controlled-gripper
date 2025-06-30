using UnityEngine;

public class ArmMouseFollow : MonoBehaviour
{
    public Camera cam;
    public Transform ikTarget;
    public Transform player;
    public float distanceFromPlayer = 2f;
    public Vector3 tipOffset = new Vector3(0, 0, 0.2f);
    public float armMoveSpeed = 3f;
    private float mousePlaneHeightOffset = 1.2f;
    public bool trackingEnabled = false;
    private bool mouseActive = false;

    GameObject currentGrabber = MethodManager.currentMethodInstance;

    void Update()
    {
        if (!MethodManager.isClawMethod) return;
        if (!cam || !ikTarget || !player) return;

        ikTarget.gameObject.layer = LayerMask.NameToLayer("Ignore Raycast");
        // Включение/выключение режима слежения
        if (Input.GetKeyDown(KeyCode.Y))
        {
            trackingEnabled = !trackingEnabled;
            Debug.Log("Tracking toggled: " + trackingEnabled);

            if (player.TryGetComponent<Movement>(out var movement))
                movement.movementEnabled = !trackingEnabled;

            Vector3 localOffset = player.InverseTransformPoint(ikTarget.position);
            mousePlaneHeightOffset = localOffset.y;
        }
        if (trackingEnabled && Input.GetMouseButton(1))
        {
            Vector3 newPos = GetMouseFollowPosition() + GetKeyboardOffset();
            ikTarget.position = newPos;
        }
    }

    void FollowPlayer()
    {
        ikTarget.position = player.position + player.forward * distanceFromPlayer + player.forward * tipOffset.z;
    }

    Vector3 GetMouseFollowPosition()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        Vector3 worldPoint = ray.origin + ray.direction * 5f;
        Vector3 localPoint = player.InverseTransformPoint(worldPoint);
        localPoint.z = distanceFromPlayer;

        if (Vector3.Dot(player.forward, cam.transform.forward) < 0f)
            localPoint.x *= -1;

        Vector3 adjustedWorldPoint = player.TransformPoint(localPoint); 
        Debug.Log("et");
        return adjustedWorldPoint + player.forward * tipOffset.z;
    }

    Vector3 GetKeyboardOffset()
    {
        float moveY = 0f;
        if (Input.GetKey(KeyCode.Space)) moveY = 1f;
        if (Input.GetKey(KeyCode.LeftShift)) moveY = -1f;

        float moveZ = 0f;
        if (Input.GetKey(KeyCode.W)) moveZ = 1f;
        if (Input.GetKey(KeyCode.S)) moveZ = -1f;

        float moveX = 0f;
        if (Input.GetKey(KeyCode.A)) moveX = -1f;
        if (Input.GetKey(KeyCode.D)) moveX = 1f;

        Vector3 moveDir = new Vector3(moveX, moveY, moveZ);
        if (moveDir.magnitude > 1f)
            moveDir.Normalize();

        return player.TransformDirection(moveDir) * armMoveSpeed * Time.deltaTime;
    }
}
