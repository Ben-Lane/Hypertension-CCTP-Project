using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputHandler : MonoBehaviour
{
    // Start is called before the first frame update

    [Header("Input Action Asset")]
    [SerializeField] private InputActionAsset playerInputs;

    private string IAmapName = "DefaultInteractions";
    private string actionName = "PlayerJump";

    private InputAction jumpAction;
    public bool JumpTriggered { get; private set; }

    public static InputHandler Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        jumpAction = playerInputs.FindActionMap(IAmapName).FindAction(actionName);
        RegisterInputs();
    }

    private void RegisterInputs()
    {
        jumpAction.performed += context => JumpTriggered = true;
        jumpAction.canceled += context => JumpTriggered = false;
    }

    private void OnEnable()
    {
        jumpAction.Enable();
    }

    private void OnDisable()
    {
        jumpAction.Disable();
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
