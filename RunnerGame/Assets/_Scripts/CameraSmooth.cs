using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSmooth : MonoBehaviour
{
    public static CameraSmooth instance;

    [HideInInspector] public bool stopCamera;

    [SerializeField] private Transform m_Target;
    [SerializeField] private float mHeight;
    [SerializeField] private float mDistance;
    [SerializeField] private float mAngle;
    [SerializeField] private float mSmooth;
    [SerializeField] private float appendDistance;
    [SerializeField] private float rotationSpeed = 5;
    [SerializeField] private bool valuesChangePermission = true;

    private Vector3 refVelocity;
    private Vector3 worldPosition;
    private Vector3 rotatedVector;
    private Vector3 flatTargetPosition;
    private Vector3 finalPosition;
    private float firstAngle;
    private float targetHeight;
    private float targetDistance;
    private float targetAngle;
    private float targetSmooth;
    private bool changeTargetBuild;

    private void MakeInstance()
    {
        if (instance == null)
            instance = this;
    }

    private void Awake()
    {
        MakeInstance();
        ChangeCameraValue(mHeight, mDistance, mAngle, mSmooth);
        CameraControl();
        firstAngle = mAngle;
    }

    private void FixedUpdate()
    {
        if (stopCamera)
        {
            return;
        }
        if (valuesChangePermission)
        {
            mHeight = Mathf.Lerp(mHeight, targetHeight, Time.fixedDeltaTime * 2);
            mDistance = Mathf.Lerp(mDistance, targetDistance, Time.fixedDeltaTime * 2);
            if (changeTargetBuild)
            {
                mAngle = Mathf.LerpAngle(mAngle, targetAngle, Time.fixedDeltaTime);
            }
            else
            {
                mAngle = Mathf.LerpAngle(mAngle, targetAngle, Time.fixedDeltaTime * 2);
            }
            mSmooth = Mathf.LerpAngle(mSmooth, targetSmooth, Time.fixedDeltaTime * 2);
        }
        CameraControl();
    }

    public void ChangeTargetBuild(Transform newTarget)
    {
        StartCoroutine(ChangeTargetBuildAction(newTarget));
    }

    private IEnumerator ChangeTargetBuildAction(Transform newTarget)
    {
        yield return new WaitForSeconds(0.01f);
        changeTargetBuild = true;
        m_Target = newTarget;
        ChangeCameraValue(9, 16, 10, mSmooth);
    }

    public void ChangeCameraValue(float newHeight, float newDistance, float newAngle, float newSmooth)
    {
        targetHeight = newHeight;
        targetDistance = newDistance;
        targetAngle = newAngle;
        targetSmooth = newSmooth;
    }

    private void CameraControl()
    {
        if (!m_Target)
        {
            return;
        }
        worldPosition = (Vector3.forward * -mDistance) + (Vector3.up * mHeight);
        rotatedVector = Quaternion.AngleAxis(mAngle, Vector3.up) * worldPosition;
        if (changeTargetBuild)
        {
            flatTargetPosition = Vector3.Lerp(flatTargetPosition, m_Target.position, Time.deltaTime / 0.5f);
        }
        else
        {
            flatTargetPosition = m_Target.position + new Vector3(transform.forward.x, 0, transform.forward.z).normalized * appendDistance;
        }
        finalPosition = flatTargetPosition + rotatedVector;
        transform.position = Vector3.SmoothDamp(transform.position, finalPosition, ref refVelocity, mSmooth);
        //transform.LookAt(flatTargetPosition);
        if (changeTargetBuild)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(flatTargetPosition - transform.position), Time.fixedDeltaTime * rotationSpeed * 3);
        }
        else
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(flatTargetPosition - transform.position), Time.fixedDeltaTime * rotationSpeed);
        }
    }
}
