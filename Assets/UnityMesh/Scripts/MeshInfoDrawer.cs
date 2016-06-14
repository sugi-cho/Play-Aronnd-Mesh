using UnityEngine;
using System.Collections;

public class MeshInfoDrawer : MonoBehaviour
{

    void OnDrawGizmos()
    {
        var filter = GetComponent<MeshFilter>();
        if (filter == null) return;
        var mesh = filter.sharedMesh;
        if (mesh == null) return;

        GizmoHelper.DrawMeshInfo(mesh, transform.localToWorldMatrix);
    }
}
