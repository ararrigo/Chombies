﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SortingObjectLayer : MonoBehaviour
{
    private SpriteRenderer sprite;

    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        sprite.sortingOrder = Mathf.RoundToInt(transform.position.y * -10f);
    }
}
