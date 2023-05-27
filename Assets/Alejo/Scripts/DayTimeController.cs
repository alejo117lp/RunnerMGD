using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayTimeController : MonoBehaviour
{
    [Header("Sky Sprites")]
    [SerializeField] SpriteRenderer skyRenderer;
    [SerializeField] Sprite daySkay;
    [SerializeField] Sprite nightSkay;

    [Header("Box Sprites")]
    [SerializeField] GameObject box;
    [SerializeField] Sprite dayBox;
    [SerializeField] Sprite nightBox;

    [Header("Trees Sprites")]
    [SerializeField] GameObject trees;
    [SerializeField] Sprite[] treesOnDay;
    [SerializeField] Sprite[] treesOnNight;

    [Header("Ground Sprites")]
    [SerializeField] GameObject ground;
    [SerializeField] Sprite dayGround;
    [SerializeField] Sprite nightGround;

    SpriteRenderer boxRenderer;
    SpriteRenderer[] treesRenderer;
    SpriteRenderer[] groundRenderer;
    Transform[] groundTransform;
    Transform[] treesTransform;
    Transform boxTransform;
    BoxCollider2D boxCollider;

    private void Awake() {
        treesRenderer = trees.GetComponentsInChildren<SpriteRenderer>();
        groundRenderer= ground.GetComponentsInChildren<SpriteRenderer>();
        groundTransform = ground.GetComponentsInChildren<Transform>();
        treesTransform = trees.GetComponentsInChildren<Transform>();
        boxRenderer = box.GetComponent<SpriteRenderer>();
        boxTransform = box.GetComponent<Transform>();
        boxCollider= box.GetComponent<BoxCollider2D>();

        int random = Random.Range(0, 2); // Night = 0, Day = 1.

        if(random == 0) {
            for(int i = 0; i < treesRenderer.Length; i++) {
                treesRenderer[i].sprite = treesOnNight[i];
                treesTransform[i + 1].position = new Vector3(treesTransform[i + 1].position.x,
                   0.8f, treesTransform[i + 1].position.z);
            }

            for (int i = 0; i < groundRenderer.Length; i++) {
                groundRenderer[i].sprite = nightGround;
                groundTransform[i+1].position = new Vector3(groundTransform[i+1].position.x, 
                    -3.97f, groundTransform[i + 1].position.z);
                groundTransform[i + 1].localScale = new Vector3(groundTransform[i + 1].localScale.x,
                    -3.3f, groundTransform[i + 1].localScale.z);
            }

            boxTransform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
            boxCollider.size = new Vector2(2.7f, 2.7f);
            skyRenderer.sprite = nightSkay;
            boxRenderer.sprite = nightBox;
        }

        else {
            for (int i = 0; i < treesRenderer.Length; i++) {
                treesRenderer[i].sprite = treesOnDay[i];
            }

            for (int i = 0; i < groundRenderer.Length; i++) {
                groundRenderer[i].sprite = dayGround;
            }

            skyRenderer.sprite = daySkay;
            boxRenderer.sprite = dayBox;
            boxTransform.localScale = new Vector3(1f, 1f, 1f);
            boxCollider.size = new Vector2(1.4f, 1.4f);
        }
    }
}
