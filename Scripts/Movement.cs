using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private SpriteRenderer SpriteRenderer;
    public Sprite[] mySprites;
    private int index;
    // Start is called before the first frame update
    void Start()
    {
        SpriteRenderer = GetComponent<SpriteRenderer>();
        StartCoroutine(TurnCoRutine());

    }

    // Update is called once per frame
    void Update()
    {


    }
    IEnumerator TurnCoRutine()
    {
        yield return new WaitForSeconds(0.05f);
        SpriteRenderer.sprite = mySprites[index];
        index++;
        if (index == 5)
        {
            index = 0;

        }
        StartCoroutine(TurnCoRutine());
    }
}
