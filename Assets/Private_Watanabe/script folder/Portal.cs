using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    [SerializeField] private int stage_number = 0;
    [SerializeField] private string scene_name = "";
    private SpriteRenderer sprite_renderer = null;
    [SerializeField] private Sprite open_sprite = null;
    [SerializeField] private Sprite close_sprite = null;


    // Start is called before the first frame update
    void Start()
    {
        this.sprite_renderer = this.gameObject.GetComponent<SpriteRenderer>();

        bool did_clear_stage = DataManager.dataManager.getDidClearStage(this.stage_number);

        this.sprite_renderer.sprite = (did_clear_stage) ? this.open_sprite : this.close_sprite;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("ok");
            SceneManager.LoadScene(this.scene_name);
        }
    }
}
