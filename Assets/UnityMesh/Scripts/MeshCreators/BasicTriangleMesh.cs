using UnityEngine;

public class BasicTriangleMesh : MeshCreatorBase
{
    override protected void CreateMesh()
    {
        mesh = new Mesh();
        var vertices = new[]
        {
            new Vector3(-1f,0,0),
            new Vector3(1f,0,0),
            new Vector3(0,Mathf.Sqrt(2f),0),
        };
        var triangles = new[]
        {
            0,2,1,
        };
        mesh.vertices = vertices;
        mesh.triangles = triangles;
    }
}