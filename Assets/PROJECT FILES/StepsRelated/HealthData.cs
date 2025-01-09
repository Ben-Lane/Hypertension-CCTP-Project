using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Android;
using UnityEngine.Android;


public class HealthData : MonoBehaviour
{
    [SerializeField] public TMP_Text Output;

    private void Awake()
    {
        // This will prompt the user for permission to use this device
#if PLATFORM_ANDROID
        if (!Permission.HasUserAuthorizedPermission("android.permission.ACTIVITY_RECOGNITION"))
        {
            Permission.RequestUserPermission("android.permission.ACTIVITY_RECOGNITION");
        }
#endif
    }

    private void OnDestroy()
    {
        // Just cleans up any devices that were added, Unity editor seems to hold on to them
        Stack<Type> TypesToRemove = new(new[] 
        { 
            typeof(AndroidStepCounter), 
            typeof(StepCounter),
            typeof(Accelerometer) 
        });

        while(TypesToRemove.Count > 0)
        {
            InputDevice toRemove = InputSystem.GetDevice(TypesToRemove.Peek());
            if(toRemove == null)
            {
                TypesToRemove.Pop();
                continue;
            }

            InputSystem.RemoveDevice(toRemove);
        }
    }

    void Start()
    {
        InputSystem.AddDevice<StepCounter>();
        if(StepCounter.current != null)
        {
            InputSystem.EnableDevice(StepCounter.current);
            StepCounter.current.MakeCurrent();
            print("Step counter device found!");
        }
        else
        {
            Debug.LogError("Failed to add StepCounter device");
        }
    }

    void Update()
    {
        StepCounter targetCounter = StepCounter.current;

        if (targetCounter != null)
        {
            if (targetCounter.stepCounter != null)
            {
                Output.text = "Steps: " + targetCounter.stepCounter.ReadValue().ToString();
                print(targetCounter.stepCounter.ReadValue().ToString());
            }
            else
            {
                Output.text = "StepCounter.current.stepCounter is null";
            }
        }
        else
        {
            Output.text = "StepCounter.current is null";
        }
    }
}