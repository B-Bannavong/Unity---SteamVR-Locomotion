using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class PlayerController : MonoBehaviour
{
    public Transform playerCenter;
    public CharacterController character;
    public SteamVR_Action_Vector2 touchPadInput; 
    public float speed = 5;
    private CharacterController characterController;
    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    private void Update()
    {
        characterController.height = Mathf.Max(characterController.radius, Player.instance.hmdTransform.localPosition.y);
        characterController.center = new Vector3(Player.instance.hmdTransform.localPosition.x, (characterController.height / 2), Player.instance.hmdTransform.localPosition.z);

        Vector3 direction = Player.instance.hmdTransform.TransformDirection(new Vector3(touchPadInput.axis.x, 0, touchPadInput.axis.y));
        character.center = new Vector3(playerCenter.localPosition.x, 1.03f, playerCenter.localPosition.z);
        characterController.Move(speed * Time.deltaTime * Vector3.ProjectOnPlane(direction, Vector3.up) - new Vector3(0, 9.81f, 0)*Time.deltaTime);
    }
}
