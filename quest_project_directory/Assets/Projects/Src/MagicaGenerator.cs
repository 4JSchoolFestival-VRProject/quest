using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MagicaGenerator : MonoBehaviour {

    public GameObject magicaPrefabs;
    float span = 1.0f;
    float delta = 0;
    private RectTransform img_t;
    void Start()
    {
        img_t = gameObject.transform.Find("Canvas").gameObject.transform.Find("Image").gameObject.GetComponent<RectTransform>();
    }
    void Update()
    {
        this.delta += Time.deltaTime;
        if (this.delta > this.span)
        {
            this.delta = 0;
            GameObject item = Instantiate(magicaPrefabs) as GameObject;
            float x = Random.Range(-0.5f, 0.5f);
            float y = Random.Range(0, 10);
            img_t.anchoredPosition = new Vector3(x, y, 0.2f);
            item.transform.position = new Vector3(x, y, 20);
        }
    }

}
