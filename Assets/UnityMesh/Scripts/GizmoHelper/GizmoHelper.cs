using UnityEngine;
using System.Collections;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class GizmoHelper
{
    static Mesh arrow { get { if (_arrow == null) _arrow = BuildArrow(); return _arrow; } }
    static Mesh _arrow;
    static Mesh BuildArrow()
    {
        var mesh = new Mesh();
        var vertices = new[]
        {
            new Vector3(-.5f,-.5f,-1f),
            new Vector3( .5f,-.5f,-1f),
            new Vector3( .5f, .5f,-1f),
            new Vector3(-.5f, .5f,-1f),
            new Vector3( 0, 0, 1f),
        };
        var triangles = new[]
        {
            0,1,4,
            1,2,4,
            2,3,4,
            3,0,4,

            1,0,2,
            2,0,3,
        };
        mesh.vertices = vertices;
        mesh.normals = vertices;
        mesh.triangles = triangles;
        return mesh;
    }
    public static void DrawArrow(Vector3 from, Vector3 to, float arrowRate = 0.5f)
    {
        var vec = to - from;
        Gizmos.DrawLine(from, from + vec * (1f - arrowRate));
        from = from + vec * (1f - arrowRate);
        var pos = (from + to) * 0.5f;
        var rot = Quaternion.LookRotation(to - from);
        var scl = (to - from).magnitude * 0.5f * Vector3.one;
        Gizmos.DrawMesh(arrow, pos, rot, scl);
    }
    public static void DrawMeshInfo(Mesh mesh, Matrix4x4 matrix)
    {
        Gizmos.matrix = matrix;
        var vertices = mesh.vertices;
        var normals = mesh.normals;
        var triangles = mesh.triangles;
        for (var i = 0; i < mesh.vertexCount; i++)
        {
            Gizmos.color = Color.black;
            Gizmos.DrawCube(vertices[i], Vector3.one * 0.05f);
#if UNITY_EDITOR
            Handles.matrix = matrix;
            Handles.Label(vertices[i], i + vertices[i].ToString());
            Handles.matrix = Matrix4x4.identity;
#endif
        }
        for (var i = 0; i < triangles.Length / 3; i++)
        {
            var idx0 = triangles[i * 3 + 0];
            var idx1 = triangles[i * 3 + 1];
            var idx2 = triangles[i * 3 + 2];
            var v0 = vertices[idx0];
            var v1 = vertices[idx1];
            var v2 = vertices[idx2];

            var center = (v0 + v1 + v2) / 3;
            var normal = Vector3.zero;
            var autoCalculateNoml = false;

            if (idx2 < normals.Length)
                normal = (normals[idx0] + normals[idx0] + normals[idx0]) / 3;
            else
            {
                autoCalculateNoml = true;
                normal = Vector3.Cross(v1 - v0, v2 - v0);
            }
            normal = normal.normalized;

            Gizmos.color = Color.green;
            Gizmos.DrawLine(center + (v0 - center) * 0.7f, center + (v1 - center) * 0.7f);
            Gizmos.DrawLine(center + (v1 - center) * 0.7f, center + (v2 - center) * 0.7f);
            DrawArrow(center + (v2 - center) * 0.7f, center + (v0 - center) * 0.7f);

            Gizmos.color = autoCalculateNoml ? Color.black : new Color(0.5f * normal.x + 0.5f, 0.5f * normal.y + 0.5f, 0.5f * normal.z + 0.5f);
            var triSize = ((v0 - center).magnitude + (v1 - center).magnitude + (v2 - center).magnitude) / 3;
            DrawArrow(center, center + normal * triSize);
        }
    }

}
