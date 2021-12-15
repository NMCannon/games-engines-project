using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateTerrain : MonoBehaviour
{

    int heightScale = 20;
    float detailScale = 20.0f;

    // Start is called before the first frame update
    void Start()
    {
        Mesh mesh = this.GetComponent <MeshFilter>().mesh;
        Vector3[] vertices = mesh.vertices;
        // For each vertices, lift the y value using perlin noise function
        for(int v = 0; v < vertices.Length; v++)
        {
            // Use plane position as offset for perlin noise function
            vertices[v].y = Mathf.PerlinNoise((vertices[v].x + this.transform.position.x) / detailScale,
                                                (vertices[v].z + this.transform.position.z) / detailScale) * heightScale;
        }

        // Set vertices back on mesh
        mesh.vertices = vertices;
        // Update the normals and bounds of the mesh
        mesh.RecalculateBounds();
        mesh.RecalculateNormals();
        // Add mesh collider
        this.gameObject.AddComponent<MeshCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
