using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMaterialTool : MonoBehaviour
{
    MeshRenderer meshRenderer;
    // Start is called before the first frame update
    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ChangeMat(Material matVariant)
    {
        meshRenderer.material = matVariant;

    }
}
