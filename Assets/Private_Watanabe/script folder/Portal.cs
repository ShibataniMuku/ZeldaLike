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

    //[SerializeField] private CircleCollider2D circleCollider2D = null;


    // Start is called before the first frame update
    void Start()
    {
        this.sprite_renderer = this.gameObject.GetComponent<SpriteRenderer>();
        //this.circleCollider2D = this.gameObject.GetComponent<CircleCollider2D>();

        bool did_clear_stage = DataManager.dataManager.getDidClearStage(this.stage_number);

        if (did_clear_stage)
        {
            this.sprite_renderer.sprite = this.open_sprite;
        }
        else
        {
            this.sprite_renderer.sprite = this.close_sprite;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        bool did_clear_stage = DataManager.dataManager.getDidClearStage(this.stage_number);

        if (collision.gameObject.CompareTag("Player") && did_clear_stage)
        {
            Debug.Log("ok");
            AudioManager.instance_AudioManager.StopBGM();
            SceneManager.LoadScene(this.scene_name);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        
    }
}
