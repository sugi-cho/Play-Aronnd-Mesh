using UnityEngine;

public class CubeMesh : MeshCreatorBase
{

    protected override void CreateMesh()
    {
        mesh = new Mesh();
        var vertices = new[]
        {
            new Vector3(-1f,-1f,-1f),
            new Vector3(-1f, 1f,-1f),
            new Vector3(-1f, 1f, 1f),
            new Vector3(-1f,-1f, 1f),

            new Vector3(-1f,-1f,-1f),
            new Vector3( 1f,-1f,-1f),
            new Vector3( 1f,-1f, 1f),
            new Vector3(-1f,-1f, 1f),

            new Vector3(-1f,-1f,-1f),
            new Vector3( 1f,-1f,-1f),
            new Vector3( 1f, 1f,-1f),
            new Vector3(-1f, 1f,-1f),

            new Vector3( 1f,-1f,-1f),
            new Vector3( 1f, 1f,-1f),
            new Vector3( 1f, 1f, 1f),
            new Vector3( 1f,-1f, 1f),

            new Vector3(-1f, 1f,-1f),
            new Vector3( 1f, 1f,-1f),
            new Vector3( 1f, 1f, 1f),
            new Vector3(-1f, 1f, 1f),

            new Vector3(-1f,-1f, 1f),
            new Vector3( 1f,-1f, 1f),
            new Vector3( 1f, 1f, 1f),
            new Vector3(-1f, 1f, 1f),
        };
        var triangles = new[]
        {
            0,2,1,      0,3,2,
            4,5,6,      4,6,7,
            8,10,9,     8,11,10,
            12,13,14,   12,14,15,
            16,18,17,   16,19,18,
            20,21,22,   20,22,23,
        };
        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.RecalculateNormals();
    }
}
