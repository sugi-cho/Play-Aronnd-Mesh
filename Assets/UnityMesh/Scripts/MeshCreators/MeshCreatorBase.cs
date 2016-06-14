using UnityEngine;
using UnityEngine.Events;

public abstract class MeshCreatorBase : MonoBehaviour
{

    public Shader visualizer;
    public MaterialEvent onSetupMaterial;
    [SerializeField]
    protected Mesh mesh;

    MeshFilter mFilter { get { if (_filter == null) { _filter = GetComponent<MeshFilter>(); if (_filter == null) _filter = gameObject.AddComponent<MeshFilter>(); } return _filter; } }
    MeshFilter _filter;
    MeshRenderer mRenderer { get { if (_renderer == null) { _renderer = GetComponent<MeshRenderer>(); if (_renderer == null) _renderer = gameObject.AddComponent<MeshRenderer>(); } return _renderer; } }
    MeshRenderer _renderer;

    // Use this for initialization
    void Start()
    {
        CreateMesh();
        mFilter.mesh = mesh;
        var mat = visualizer == null ? null : new Material(visualizer);
        mRenderer.material = mat;
        if (mat != null)
            onSetupMaterial.Invoke(mat);
    }

    protected virtual void CreateMesh() { }
    [System.Serializable]
    public class MaterialEvent : UnityEvent<Material> { }
}
