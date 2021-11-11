using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public Animator transition;
    public float transitionTime = 1f;
    public GameObject player;
    public Transform roomGroup;

    public void LoadNextLevel() {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

    public void LoadGameScene() {
        StartCoroutine(LoadLevel(1));
    }

    IEnumerator LoadLevel(int levelIndex) {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(levelIndex);
    }

    public void nextRoom(int oldRoom, int newRoom) {
        if (oldRoom == 0) {
            if (newRoom == 1) {
                goToNextRoom(0, 1, 2);
            }
        }
        if (oldRoom == 1) {
            if (newRoom == 0) {
                goToNextRoom(1, 0, 2);
            }
            if (newRoom == 2) {
                goToNextRoom(1, 2, 2);
            }
        }
        if (oldRoom == 2) {
            if (newRoom == 1) {
                goToNextRoom(2, 1, 3);
            }
            if (newRoom == 3) {
                goToNextRoom(2, 3, 2);
            }
            if (newRoom == 4) {
                goToNextRoom(2, 4, 2);
            }
        }
        if (oldRoom == 3) {
            if (newRoom == 2) {
                goToNextRoom(3, 2, 3);
            }
            if (newRoom == 5) {
                goToNextRoom(3, 5, 2);
            }
        }
        if (oldRoom == 4) {
            if (newRoom == 2) {
                goToNextRoom(4, 2, 4);
            }
            if (newRoom == 6) {
                goToNextRoom(4, 6, 2);
            }
        }
        if (oldRoom == 5) {
            if (newRoom == 3) {
                goToNextRoom(5, 3, 3);
            }
        }
        if (oldRoom == 6) {
            if (newRoom == 4) {
                goToNextRoom(6, 4, 3);
            }
            if (newRoom == 7) {
                goToNextRoom(6, 7, 2);
            }
        }
        if (oldRoom == 7) {
            if (newRoom == 6) {
                goToNextRoom(7, 6, 3);
            }
            if (newRoom == 8) {
                goToNextRoom(7, 8, 2);
            }
        }
        if (oldRoom == 8) {
            if (newRoom == 7) {
                goToNextRoom(8, 7, 3);
            }
            if (newRoom == 9) {
                goToNextRoom(8, 9, 2);
            }
        }
        if (oldRoom == 9) {
            if (newRoom == 8) {
                goToNextRoom(9, 8, 3);
            }
        }
    }

    private void goToNextRoom(int oldRoom, int newRoom, int doorNum) {
        GameObject.FindGameObjectWithTag("GameController").GetComponent<AudioManager>().Play("Door2");
        player.transform.position = new Vector2(roomGroup.GetChild(newRoom).GetChild(doorNum).transform.position.x, player.transform.position.y);
        roomGroup.GetChild(newRoom).gameObject.SetActive(true);
        roomGroup.GetChild(oldRoom).gameObject.SetActive(false);
    }


}
