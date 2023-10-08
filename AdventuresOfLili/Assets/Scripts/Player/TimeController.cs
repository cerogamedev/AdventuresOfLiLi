using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeController : MonoBehaviour
{
    public static float gravity = -100;
    public struct RecordedData
    {
        public Vector2 pos;
        public Vector2 vel;
    }
    RecordedData[,] recordedData;
    int recordMax = 100000;
    int recordCount;
    int recordIndex;
    bool wasSteppingBack = false;

    TimeControlled[] timeObjects;
    private void Awake()
    {
        timeObjects = GameObject.FindObjectsOfType<TimeControlled>();
        recordedData = new RecordedData[timeObjects.Length, recordMax];
    }

    // Update is called once per frame
    void Update()
    {
        bool pause = Input.GetKey(KeyCode.UpArrow);
        bool stepBack = Input.GetKey(KeyCode.LeftArrow);
        bool stepForward = Input.GetKey(KeyCode.RightArrow);

        if (stepBack)
        {
            wasSteppingBack = true;
            if (recordIndex>0)
            {
                recordIndex--;
                for (int objectIndex = 0; objectIndex < timeObjects.Length; objectIndex++)
                {
                    TimeControlled timeObject = timeObjects[objectIndex];
                    RecordedData data = recordedData[objectIndex, recordIndex];
                    timeObject.transform.position = data.pos;
                    timeObject.velocity = data.vel;
                }
            }
        }
        else if (pause && stepForward)
        {

        }
        else if (!pause && !stepBack)
        {
            if (wasSteppingBack)
            {
                recordCount = recordIndex;
                wasSteppingBack = false;
            }
            for (int objectIndex=0; objectIndex < timeObjects.Length; objectIndex++)
            {
                TimeControlled timeObject = timeObjects[objectIndex];
                RecordedData data = new RecordedData();
                data.pos = timeObject.transform.position;
                data.vel = timeObject.velocity;
                recordedData[objectIndex, recordCount] = data;
            }
            recordCount++;
            recordIndex = recordCount;
            foreach(TimeControlled TimeObject in timeObjects)
            {
                TimeObject.TimeUpdate();
            }
        }
    }
}
