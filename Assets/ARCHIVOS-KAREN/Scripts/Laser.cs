using UnityEngine;

public class Laser : MonoBehaviour
{ public float laserInterval = 3f;      // Cada cuántos segundos dispara
    public float laserDuration = 0.15f;   // Cuánto dura el láser visible
    public float laserLength = 30f;       // Longitud del láser
    public float laserWidth = 0.05f;      // Grosor del láser
    public Color laserColor = Color.red;  // Color del láser

    private LineRenderer line;
    private float timer = 0f;
    private bool isFiring = false;

    void Start()
    {
        // Crear LineRenderer
        line = gameObject.AddComponent<LineRenderer>();
        line.positionCount = 2;
        line.startWidth = laserWidth;
        line.endWidth = laserWidth;

        // Material unlit simple
        Material mat = new Material(Shader.Find("Unlit/Color"));
        mat.color = laserColor;
        line.material = mat;

        line.enabled = false;
    }

    void Update()
    {
        timer += Time.deltaTime;

        // Cada X segundos → dispara
        if (!isFiring && timer >= laserInterval)
        {
            StartCoroutine(FireLaser());
            timer = 0f;
        }
    }

    private System.Collections.IEnumerator FireLaser()
    {
        isFiring = true;
        line.enabled = true;

        Vector3 start = transform.position;

        // 🔥 Ahora dispara hacia la izquierda (X negativo)
        Vector3 direction = Vector3.left;   // (-1, 0, 0)

        Vector3 end = start + direction * laserLength;

        line.SetPosition(0, start);
        line.SetPosition(1, end);

        yield return new WaitForSeconds(laserDuration);

        line.enabled = false;
        isFiring = false;
    }
}