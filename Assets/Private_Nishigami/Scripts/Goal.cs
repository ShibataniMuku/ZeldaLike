using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour
{
    bool is_activated = false;

    [SerializeField] private int stage_number = 0;

    private SpriteRenderer sprite_renderer = null;
    [SerializeField] private Sprite open_sprite = null;
    [SerializeField] private Sprite close_sprite = null;

    [SerializeField] private GoalUIManager goal_ui_manager = null;


    // Start is called before the first frame update
    void Start()
    {
        this.sprite_renderer = this.gameObject.GetComponent<SpriteRenderer>();

        this.sprite_renderer.sprite = this.close_sprite;

        this.goal_ui_manager = GameObject.FindWithTag("GoalUIManager").GetComponent<GoalUIManager>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" && !is_activated)
        {
            Debug.Log("“ž’B");
            is_activated = true;
            this.sprite_renderer.sprite = this.open_sprite;

            this.goal_ui_manager.viewPivot();

            DataManager.dataManager.setDidClearStage(this.stage_number, true);
        }
    }
}
