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
    [SerializeField] SpriteRenderer boxRenderer;
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


    SpriteRenderer[] treesRenderer;
    SpriteRenderer[] groundRenderer;

    private void Awake() {
        treesRenderer = trees.GetComponentsInChildren<SpriteRenderer>();
        groundRenderer= ground.GetComponentsInChildren<SpriteRenderer>();

        int random = Random.Range(0, 2); // Night = 0, Day = 1.

        if(random == 0) {
            for(int i = 0; i < treesRenderer.Length; i++) {
                treesRenderer[i].sprite = treesOnNight[i];
            }

            for (int i = 0; i < groundRenderer.Length; i++) {
                groundRenderer[i].sprite = nightGround;
            }

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
        }
    }
}
