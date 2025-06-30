using UnityEngine;
using UnityEngine.Animations.Rigging;

public class ArmMovement : MonoBehaviour
{
    public float rotationSpeed = 100f;
    public ArmMouseFollow mouseFollowScript;

    void Update()
    {
        if (MethodManager.currentMethodInstance == null) return;
        if (!MethodManager.isClawMethod) return;

        float rotationInput = 0f;
        if (Input.GetKey(KeyCode.Z)) rotationInput = 1f;
        else if (Input.GetKey(KeyCode.X)) rotationInput = -1f;

        if (rotationInput != 0f)
        {
            MethodManager.currentMethodInstance.transform.Rotate(Vector3.up * rotationInput * rotationSpeed * Time.deltaTime);
        }

        if (!mouseFollowScript.trackingEnabled)
        {
            var ik = GetComponent<ChainIKConstraint>();
            if (ik != null) ik.enabled = false;
        }
        else
        {
            var ik = GetComponent<ChainIKConstraint>();
            if (ik != null) ik.enabled = true;
        }
    }
}
