using UnityEngine;

public class ArmController : MonoBehaviour
{public Transform ikTarget;
    public float moveSpeed = 2f;
    public float depthSpeed = 2f;
    public float sensitivity = 0.01f;
    private Vector3 targetPosition;
    private Camera cam;
    public Transform player;   

   
    void Start()
    {
        cam = Camera.main;
        targetPosition = ikTarget.localPosition;
    }

    void Update()
    {
        if (!MethodManager.isClawMethod) return;
        
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");
        float depth = Input.GetAxis("Vertical");
    }
}
