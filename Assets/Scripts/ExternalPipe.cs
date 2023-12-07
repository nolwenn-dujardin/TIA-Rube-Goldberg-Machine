using UnityEngine;

public class ExternalPipe : MonoBehaviour
{
    public float diametre = 0.3f; // Diamètre du tuyau en mètres
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

        Vector3[] vertices = new Vector3[segments * 2 + 2];
        int[] triangles = new int[segments * 6];

        float angleIncrement = 2f * Mathf.PI / segments;
        float currentAngle = 0f;

        // Créer les vertices
        for (int i = 0; i <= segments; i++)
        {
            float x = Mathf.Cos(currentAngle) * diametre * 0.5f;
            float z = Mathf.Sin(currentAngle) * diametre * 0.5f;

            vertices[i] = new Vector3(x, 0f, z);
            vertices[i + segments + 1] = new Vector3(x, longueur, z);

            currentAngle += angleIncrement;
        }

        // Créer les triangles
        for (int i = 0, ti = 0; i < segments; i++, ti += 6)
        {
            triangles[ti] = i;
            triangles[ti + 1] = i + segments + 1;
            triangles[ti + 2] = i + 1;

            triangles[ti + 3] = i + 1;
            triangles[ti + 4] = i + segments + 1;
            triangles[ti + 5] = i + segments + 2;
        }

        mesh.vertices = vertices;
        mesh.triangles = triangles;

        // Recalculer les normales pour une meilleure apparence
        mesh.RecalculateNormals();
    }
}
