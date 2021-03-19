using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class voxelRenderer : MonoBehaviour
{
    public MeshRenderer meshRenderer;
    public MeshFilter meshFilter;
    // Start is called before the first frame update
    void Start()
    {
        int vertexIndex = 0;
        List<Vector3> vertices = new List<Vector3>();
        List<int> triangles = new List<int>();
        List<Vector2> uv = new List<Vector2>();

        for (int p = 0; p < 6; p++)
        {
            for (int i = 0; i < 6; i++)
            {
                int triangleIndex = VoxelData.tris[p, i];
                vertices.Add(VoxelData.verts[triangleIndex]);
                triangles.Add(vertexIndex);
                uv.Add(VoxelData.uvs[i]);
                vertexIndex++;
            }
        }

        Mesh mesh = new Mesh();
        
        mesh.vertices = vertices.ToArray();
        mesh.triangles = triangles.ToArray();
        mesh.uv = uv.ToArray();
        
        mesh.RecalculateNormals();
        
        meshFilter.mesh = mesh;
    }

}
