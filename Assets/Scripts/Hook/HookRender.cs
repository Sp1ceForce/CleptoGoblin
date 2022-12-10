using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookRender : MonoBehaviour
{
    [SerializeField] private GameObject shootPoint;
    [SerializeField] private float drawSpeed;
    [SerializeField] private LineRenderer lineRenderer;
    [SerializeField] private GameObject hook;
    [SerializeField] private float returnHookTime = 0.5f;

    private bool isDrawing = false;
    private bool isReturn = false;

    private Vector3 targetGrabPosition;
    private Vector3 currentGrabPosition;
    public void DrawRope(Vector3 grabPosition)
    {
        isDrawing = true;
        isReturn = false;
        lineRenderer.positionCount = 2;

        targetGrabPosition = grabPosition;
        currentGrabPosition = shootPoint.transform.position;
        hook.SetActive(true);

    }

    private void LateUpdate()
    {
        if (isDrawing)
        {
            currentGrabPosition = Vector3.Lerp(currentGrabPosition,
            targetGrabPosition, Time.deltaTime * drawSpeed);

            lineRenderer.SetPosition(0, shootPoint.transform.position);
            lineRenderer.SetPosition(1, currentGrabPosition);
            hook.transform.position = currentGrabPosition;
        }
        if (isReturn)
        {
            currentGrabPosition = Vector3.Lerp(currentGrabPosition,
            targetGrabPosition, Time.deltaTime * drawSpeed);

            lineRenderer.SetPosition(0, shootPoint.transform.position);
            lineRenderer.SetPosition(1, currentGrabPosition);
            hook.transform.position = currentGrabPosition;
        }

    }
    public void ReturnRope()
    {
        isDrawing = false;
        isReturn = true;
        lineRenderer.positionCount = 2;
        targetGrabPosition = transform.position;
        currentGrabPosition = hook.transform.position;

        StartCoroutine(Disable());
    }
    IEnumerator Disable()
    {
        yield return new WaitForSeconds(returnHookTime);
        isDrawing = false;
        isReturn = false;
        lineRenderer.positionCount = 0;
        hook.SetActive(false);

    }
}
