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

    private bool[,,] voxelBoundsMapping = new bool[VoxelData.debugCubeSize,VoxelData.debugCubeSize,VoxelData.debugCubeSize];
    void Start()
    {
        calculateVoxelMapping();
        createVoxelMeshData();
        createMesh();
    }

    void calculateVoxelMapping()
    {
        for (int y = 0; y < VoxelData.debugCubeSize; y++) { for (int x = 0; x < VoxelData.debugCubeSize; x++) { for (int z = 0; z < VoxelData.debugCubeSize; z++)
            {
                voxelBoundsMapping[x, y, z] = true;
            }
        } }
    }

    void addVoxelData(Vector3 pos)
    {
        for (int p = 0; p < 6; p++)
        {
            if (!checkVoxel(pos + VoxelData.faceChecks[p]))
            {
                for (int i = 0; i < 6; i++)
                {
                    int triangleIndex = VoxelData.tris[p, i];
                    vertices.Add(VoxelData.verts[triangleIndex] + pos);
                    triangles.Add(vertexIndex);
                    uv.Add(VoxelData.uvs[i]);
                    vertexIndex++;
                }
            }
        }
    }

    void createVoxelMeshData()
    {
        for (int y = 0; y < VoxelData.debugCubeSize; y++) { for (int x = 0; x < VoxelData.debugCubeSize; x++) { for (int z = 0; z < VoxelData.debugCubeSize; z++)
            {
                addVoxelData(new Vector3(x,y,z));
            }
        } }
    }

    bool checkVoxel(Vector3 pos)
    {
        int x = Mathf.FloorToInt(pos.x);
        int y = Mathf.FloorToInt(pos.y);
        int z = Mathf.FloorToInt(pos.z);
        if (x < 0 || x > VoxelData.debugCubeSize - 1 || y < 0 || y > VoxelData.debugCubeSize-1 || z < 0 || z > VoxelData.debugCubeSize-1){ return false; }
        return voxelBoundsMapping[x, y, z];
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
