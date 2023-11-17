using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace nishigami
{
    public class CameraController : MonoBehaviour
    {
        [SerializeField] public GameObject Player;

        [Header("Ž‹–ì")] public float z = -10;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (Player == null) { return; }

            Vector3 playerpos = Player.transform.position;

            transform.position = new Vector3(playerpos.x, playerpos.y, z);
        }
    }
}


