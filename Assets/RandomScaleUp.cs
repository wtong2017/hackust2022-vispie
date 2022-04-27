using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomScaleUp : MonoBehaviour
{

    Vector3 initScale;
    // Start is called before the first frame update
    void Start()
    {
        initScale = transform.localScale;
        transform.localScale = Vector3.zero;
        StartCoroutine(WaitToGrow(Random.value * 5));
    }

    IEnumerator WaitToGrow(float time) {
        yield return new WaitForSeconds(time);
        while (transform.localScale.x < initScale.x) {
            yield return new WaitForFixedUpdate();
            transform.localScale = Vector3.Lerp(transform.localScale, initScale, Time.deltaTime);
        }
    }
}
