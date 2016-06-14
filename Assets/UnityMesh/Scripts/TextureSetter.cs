using UnityEngine;
using System.Collections;

public class TextureSetter : MonoBehaviour
{
    public Texture texture;
    public string propName = "_MainTex";

    public void SetTexture(Material mat) { mat.SetTexture(propName, texture); }
}
