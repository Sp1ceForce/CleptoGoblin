using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(GuardFOV))]
public class FOVEditor : Editor
{
    private void OnSceneGUI()
    {
        GuardFOV guardFOV = (GuardFOV)target;

        Handles.color = Color.white;
        Handles.DrawWireArc(guardFOV.transform.position, Vector3.up, Vector3.forward, 360, guardFOV.DetectionRadius);
        Vector3 viewAngle1 = DirFromAngle(guardFOV.transform.eulerAngles.y, -guardFOV.VisionAngle / 2);
        Vector3 viewAngle2 = DirFromAngle(guardFOV.transform.eulerAngles.y, guardFOV.VisionAngle / 2);
        Handles.color = Color.yellow;
        Handles.DrawLine(guardFOV.transform.position, guardFOV.transform.position+ viewAngle1 * guardFOV.DetectionRadius);
        Handles.DrawLine(guardFOV.transform.position, guardFOV.transform.position + viewAngle2 * guardFOV.DetectionRadius);

    }
    private Vector3 DirFromAngle(float eulerY,float angleInDegrees)
    {
        angleInDegrees += eulerY;
        return new Vector3(Mathf.Sin(angleInDegrees * Mathf.Deg2Rad),0,Mathf.Cos(angleInDegrees * Mathf.Deg2Rad));
    }
}
