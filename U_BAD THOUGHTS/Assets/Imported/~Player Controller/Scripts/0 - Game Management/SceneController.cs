using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneController: MonoBehaviour
{
    public void LoadScene(Transform location, string id, string old)
    {
        StartCoroutine(SwitchScenes(location, id, old));

        //SceneManager.LoadScene(id, LoadSceneMode.Additive);

        //foreach (GameObject g in SceneManager.GetActiveScene().GetRootGameObjects())
        //{
        //    g.SetActive(false);
        //}

        //foreach (GameObject g in SceneManager.GetSceneByName("A").GetRootGameObjects())
        //{
        //    g.SetActive(true);
        //}
    }

    IEnumerator SwitchScenes(Transform location, string id, string old)
    {
        // Lock Player Interaction //
        References.selection.canInteract = false;

        // Pause Game //
        References.PauseGame();
        yield return new WaitForSecondsRealtime(1f);

        // Load New Scene //
        AsyncOperation load = SceneManager.LoadSceneAsync(id, LoadSceneMode.Additive);
        References.inspectController.ShowInfo("");

        // Move Player //
        References.player.transform.position = new Vector3 (location.position.x, location.position.y, location.position.z);
        References.player.transform.rotation = location.rotation;

        // Unload Old Scene //
        SceneManager.UnloadSceneAsync(old);

        // Wait while scene loads //
        yield return new WaitForSecondsRealtime(1f);

        // Resume Game //
        References.ResumeGame();

        // Unlock Player Interaction //
        References.selection.canInteract = true;
    }
}
