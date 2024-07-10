using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SymbolTracer : MonoBehaviour {

    private SpriteRenderer spriteRenderer;
    private Texture2D texture;
    private Color originalColor;
    private bool isTracing = false;

    public bool tracedSuccessfully = false;

    void Start() {

        spriteRenderer = GetComponent<SpriteRenderer>();
        texture = spriteRenderer.sprite.texture;
        originalColor = Color.red; // Couleur d'origine du symbole

    }

    void Update() {

        if (isTracing) {

            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            if (GetComponent<Collider2D>().OverlapPoint(mousePos))
            {
                ChangeColorAtPosition(mousePos);
            }
            else
            {
                isTracing = false;
            }
        }

        if (Input.GetMouseButtonDown(0)) {

            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (GetComponent<Collider2D>().OverlapPoint(mousePos))
            {
                isTracing = true;
            }
        }

        if (Input.GetMouseButtonUp(0) && isTracing) {

            tracedSuccessfully = true;
            isTracing = false;
            Debug.Log("Symbol traced successfully!");
        }
    }

    void ChangeColorAtPosition(Vector2 position) {

        Vector2 localPos = transform.InverseTransformPoint(position);
        Vector2 pixelPos = new Vector2(
            (localPos.x + 0.5f) * texture.width,
            (localPos.y + 0.5f) * texture.height
        );

        if (pixelPos.x >= 0 && pixelPos.x < texture.width && pixelPos.y >= 0 && pixelPos.y < texture.height)
        {
            texture.SetPixel((int)pixelPos.x, (int)pixelPos.y, Color.green); // Couleur de trace
            texture.Apply();
        }
    }
}
