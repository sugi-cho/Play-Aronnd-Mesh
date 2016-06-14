using UnityEngine;

public class CubeMesh_broken : MeshCreatorBase
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
            4,6,5,      4,7,6,
            8,10,9,     8,11,10,
            12,14,13,   12,15,14,
            16,18,17,   16,19,18,
            20,22,21,   20,23,22,
        };
        mesh.vertices = vertices;
        mesh.triangles = triangles;
    }
}
