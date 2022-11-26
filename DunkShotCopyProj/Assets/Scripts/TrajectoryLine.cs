using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrajectoryLine : MonoBehaviour
{
    [SerializeField]
    LineRenderer line;

    [SerializeField]
    private int lineSegments=15;

    [SerializeField]
    private int timeOfFlight = 1;

    public void ShowTrajectoryLine(Vector2 startpoint, Vector2 startVelocity)
    {
        float timeStep = (float)timeOfFlight / (float)lineSegments;
        Vector3[] lineRendererPoints = CalculateTrajectoryLine(startpoint, startVelocity, timeStep);
        line.positionCount = lineSegments;
        line.SetPositions(lineRendererPoints);
    }
    public void ClearTrajectory()
    {
        line.positionCount = 0;
        //line.SetPositions(null);
    }
    private Vector3[] CalculateTrajectoryLine(Vector2 startpoint, Vector2 startVelocity, float timeStep)
    {
        Vector3[] lineRendererPoints = new Vector3[lineSegments];
        lineRendererPoints[0] = startpoint;
        for (int i = 1; i < lineSegments; i++)
        {
            float timeOffset = timeStep * i;
            Vector2 progressBeforeGravity = startVelocity * timeOffset;
            Vector2 gravityOffset = Vector2.up * -0.6f * Physics2D.gravity.y * timeOffset * timeOffset;
            Vector2 newPosition = startpoint + progressBeforeGravity - gravityOffset;
            lineRendererPoints[i] = newPosition;
            //print(newPosition);
        }
        return lineRendererPoints;
    }
    
}
