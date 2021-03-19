using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class voxelRenderer : MonoBehaviour
{
    public MeshRenderer meshRenderer;
    public MeshFilter meshFilter;

    int vertexIndex = 0;
    List<Vector3> vertices = new List<Vector3>();
    List<int> triangles = new List<int>();
    List<Vector2> uv = new List<Vector2>();
    void Start()
    {
        for (int y = 0; y < 5; y++)
        {
            for (int x = 0; x < 5; x++)
            {
                for (int z = 0; z < 5; z++)
                {
                    addVoxelData(new Vector3(x,y,z));
                }
            }
        }
        createMesh();
    }

    void addVoxelData(Vector3 pos)
    {
        for (int p = 0; p < 6; p++)
        {
            for (int i = 0; i < 6; i++)
            {
                int triangleIndex = VoxelData.tris[p, i];
                vertices.Add(VoxelData.verts[triangleIndex]+pos);
                triangles.Add(vertexIndex);
                uv.Add(VoxelData.uvs[i]);
                vertexIndex++;
            }
        }
    }

    void createMesh()
    {
        Mesh mesh = new Mesh();
        
        mesh.vertices = vertices.ToArray();
        mesh.triangles = triangles.ToArray();
        mesh.uv = uv.ToArray();
        
        mesh.RecalculateNormals();
        
        meshFilter.mesh = mesh;
    }

}
