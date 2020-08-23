using Mirror;
using UnityEngine;

public class PlayerSetup : NetworkBehaviour
{
  
   public Behaviour[] componetsToDisable;

    Camera sceneCamera;


    // Start is called before the first frame update
    void Start()
    {
       if(!isLocalPlayer)
       {
            for (int i = 0; i < componetsToDisable.Length; i++)
            {
                componetsToDisable[i].enabled = false;
            }
       } else
        {
            sceneCamera = Camera.main;
            if(sceneCamera != null)
            {
                sceneCamera.gameObject.SetActive(false);
            }
            
        }
    }

    void OnDisable()
    {
        if(sceneCamera != null)
        {
            sceneCamera.gameObject.SetActive(true);
        }
    }
}
