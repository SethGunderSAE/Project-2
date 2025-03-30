using UnityEngine;
using TMPro;

public class HandleTextttt : MonoBehaviour
{
    public float destroyTime = 1f; // How long before text disappears
    public float floatSpeed = 2f;  // How fast it moves up

    private TextMeshProUGUI textMesh;
    private Color textColor;

    void Awake()
    {
        textMesh = GetComponent<TextMeshProUGUI>();
        textColor = textMesh.color;
    }

    void Update()
    {
        transform.position += new Vector3(0, floatSpeed * Time.deltaTime, 0); // Move up
        textColor.a -= Time.deltaTime / destroyTime; // Fade out
        textMesh.color = textColor;

        if (textColor.a <= 0)
        {
            Destroy(gameObject); // Remove when fully transparent
        }
    }

    public void SetText(string text)
    {
        textMesh.text = text; // Set damage text
    }
}