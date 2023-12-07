using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InternalPipe : MonoBehaviour
{
    public float diametreExterieur = 0.3f; // Diamètre extérieur du tuyau en mètres
    public float diametreInterieur = 0.25f; // Diamètre intérieur du tuyau en mètres
    public float longueur = 1.0f; // Longueur du tuyau en mètres
    public int segments = 32; // Nombre de segments pour le cylindre

    void Start()
    {
        CreerMeshTuyau();
    }

    void CreerMeshTuyau()
    {
        MeshFilter meshFilter = gameObject.GetComponent<MeshFilter>();
        if (meshFilter == null)
        {
            meshFilter = gameObject.AddComponent<MeshFilter>();
        }

        Mesh mesh = new Mesh();
        meshFilter.mesh = mesh;

        Vector3[] vertices = new Vector3[segments * 4];
        int[] triangles = new int[segments * 12];

        float angleIncrement = 2f * Mathf.PI / segments;
        float currentAngle = 0f;

        // Créer les vertices pour le tuyau extérieur
        for (int i = 0; i <= segments; i++)
        {
            float xOuter = Mathf.Cos(currentAngle) * diametreExterieur * 0.5f;
            float zOuter = Mathf.Sin(currentAngle) * diametreExterieur * 0.5f;
            float xInner = Mathf.Cos(currentAngle) * diametreInterieur * 0.5f;
            float zInner = Mathf.Sin(currentAngle) * diametreInterieur * 0.5f;

            vertices[i] = new Vector3(xOuter, 0f, zOuter);
            vertices[i + segments + 1] = new Vector3(xOuter, longueur, zOuter);
            vertices[i + segments * 2 + 2] = new Vector3(xInner, 0f, zInner);
            vertices[i + segments * 3 + 3] = new Vector3(xInner, longueur, zInner);

            currentAngle += angleIncrement;
        }

        // Créer les triangles pour le tuyau extérieur
        for (int i = 0, ti = 0; i < segments; i++, ti += 6)
        {
            triangles[ti] = i;
            triangles[ti + 1] = i + segments + 1;
            triangles[ti + 2] = i + 1;

            triangles[ti + 3] = i + 1;
            triangles[ti + 4] = i + segments + 1;
            triangles[ti + 5] = i + segments + 2;
        }

        // Créer les triangles pour le tuyau intérieur
        for (int i = 0, ti = segments * 6; i < segments; i++, ti += 6)
        {
            triangles[ti] = i + segments * 2 + 2;
            triangles[ti + 1] = i + segments * 3 + 3;
            triangles[ti + 2] = i + segments * 2 + 3;

            triangles[ti + 3] = i + segments * 2 + 3;
            triangles[ti + 4] = i + segments * 3 + 3;
            triangles[ti + 5] = i + segments * 3 + 2;
        }

        mesh.vertices = vertices;
        mesh.triangles = triangles;

        // Recalculer les normales pour une meilleure apparence
        mesh.RecalculateNormals();
    }
}
