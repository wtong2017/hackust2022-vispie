using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeController : MonoBehaviour
{
    public int Life { get; private set; }
    public GameObject treeBody;
    public ParticleSystem leafParticleSystem;

    Renderer treeBodyRenderer;
    private Material _mat;
    private int fullLife;
    Color originalColor;
    public float currentSize = 0.3f;
    public float targetSize = 0.9f;
    public float timeGrow = 3f; // in seconds

    public void Initialize(PlayerController player, int treeCost) {
        Life = treeCost;
        fullLife = treeCost;

        if (treeBody != null && treeBody.TryGetComponent(out treeBodyRenderer)) {
            _mat = treeBodyRenderer.material;
            originalColor = _mat.GetColor("_BaseColor");
        }
        transform.localScale = Vector3.one * currentSize;
        StartCoroutine(Decay(player));
    }

    private void Update() {
        currentSize = Mathf.Lerp(currentSize, targetSize, Time.deltaTime / timeGrow);
        transform.localScale = Vector3.one * currentSize;
        if (_mat != null) {
            Color targetColor = Color.Lerp(originalColor, new Color(0.6f, 0.52f, 0.04f), (fullLife - Life) / (float)fullLife);
            _mat.SetColor("_BaseColor", Color.Lerp(_mat.GetColor("_BaseColor"), targetColor, Time.deltaTime));
        }
    }

    IEnumerator Decay(PlayerController player) {
        while (Life > 0) {
            yield return new WaitForSeconds(1);

            // consume one score from player to keep the plant alive
            if (!player.TryDeductPoints(1)) {
                // activate the particle system
                if (leafParticleSystem != null) {
                    leafParticleSystem.Play();
                }

                // if not enough points, we reduce its life
                Life--;
            }
        }

        Destroy(gameObject);
    }
}
