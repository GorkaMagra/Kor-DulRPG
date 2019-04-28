using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesController : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(this.gameObject.tag.Equals("forestEntry") && "Player".Equals(collision.gameObject.tag))
        {
            SceneManager.LoadScene("Forest");
        }

        if (this.gameObject.tag.Equals("townEntry") && "Player".Equals(collision.gameObject.tag))
        {
            SceneManager.LoadScene("Town");
        }

    }


}
