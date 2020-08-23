using Mirror;
using UnityEngine;

public class PlayerShoot : NetworkBehaviour
{
    public Camera cam;
    public PlayerWeapon weapon;
    private const string PLAYER_TAG = "Player";

    public LayerMask mask;

    // Start is called before the first frame update
    void Start()
    {
       
    }

   
    
    void Update()
    {


        if(Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    [Client]
    void Shoot ()
    {
        RaycastHit _hit;
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out _hit, weapon.range, mask)) ;
        {
            if(_hit.collider.tag == PLAYER_TAG)
            {
                CmdPlayerShoot(_hit.collider.name);
            }
        }
    }

    [Command]
    void CmdPlayerShoot (string _playerID)
    {
        
    }
}
