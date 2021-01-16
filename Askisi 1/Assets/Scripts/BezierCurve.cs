using UnityEngine;
using System.Collections.Generic;

// Class that implements the deCasteljau algorithm for
// computing the value of a Bezier curve of arbitrary
// degree
public class BezierCurve
{
    // Calculate value of Bezier curve
    public static Vector3 DeCasteljau(int degree, float u, List<Vector3> controlPoints)
    {
        Vector3 f = new Vector3();
        // Check if order matches the degree of the curve
        if (controlPoints.Count != (degree + 1))
        {
            Debug.Log("The number of control points has to be equal with the degree of the curve plus 1!!!");
            return f;
        }
        // Check degree
        if (degree < 1)
        {
            Debug.Log("Bezier curve has to be at least of degree 1!!!");
            return f;
        }

        List<Vector3> bezierPoints = new List<Vector3>();
        for (int level = degree; level >= 0; level--)
        {
            // Top level of the DeCasteljau pyramid
            if (level == degree)
            {
                for (int i = 0; i <= degree; i++)
                {
                    bezierPoints.Add(controlPoints[i]);
                }
                continue;
            }

            // All the other levels are constructed using their
            // immediate above level
            int lastIdx = bezierPoints.Count;
            int levelIdx = level + 2;
            int idx = lastIdx - levelIdx;
            for (int i = 0; i <= level; i++)
            {
                Vector3 pi = (1 - u) * bezierPoints[idx] + u * bezierPoints[idx + 1];
                bezierPoints.Add(pi);
                ++idx;
            }
        }

        // Return the last element of the pyramid
        int lastElmnt = bezierPoints.Count - 1;
        return bezierPoints[lastElmnt];
    }
}