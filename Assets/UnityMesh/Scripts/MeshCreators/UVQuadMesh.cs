using UnityEngine;

public class UVQuadMesh : MeshCreatorBase
{
    override protected void CreateMesh()
    {
        mesh = new Mesh();
        var vertices = new[]
        {
            new Vector3(-1f, 0, 0),
            new Vector3( 1f, 0, 0),
            new Vector3( 1f,2f, 0),
            new Vector3(-1f,2f, 0),
        };
        var uv = new[]
        {
            new Vector2( 0, 0),
            new Vector2(1f, 0),
            new Vector2(1f,1f),
            new Vector2( 0,1f),
        };
        var triangles = new[]
        {
            0,2,1,
            0,3,2,
        };
        mesh.vertices = vertices;
        mesh.uv = uv;
        mesh.triangles = triangles;
        mesh.RecalculateNormals();
        mesh.RecalculateBounds();
    }
}
