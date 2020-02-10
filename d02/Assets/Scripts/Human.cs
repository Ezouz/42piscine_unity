// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class Human : MonoBehaviour
// {
//     public PlayerMovement script;
//     void Start()
//     {
        
//     }

//     void Update()
//     {
//         if (inTeam)
//         {
//             script.source.PlayOneShot(selected[Random.Range(0, 6)], 1f);
//             inTeam = false;
//         }
//         if (moveOrder)
//         {
//             script.calculateCoef();
//             script.anim.SetBool("moving", true);
//             script.source.PlayOneShot(acknowledge[Random.Range(0, 4)], 1f);
//             script.moving = true;
//             moveOrder = false;
//         }
        
//     }
// }
