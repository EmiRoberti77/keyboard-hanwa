using System;
using System.Collections.Generic;
using System.Text;

namespace CommaBoard.Store.Class
{
    public class Camera
    {
        
        public Guid id { get; set; }                        //  Camera unique id
        public Guid parentId { get; set; }                  //  Unique id of the server hosting the camera
        public string name { get; set; }                    //  Camera name
        public string url { get; set; }                     //  Camera IP address
        public Guid typeId { get; set; }                    //  Unique id of the camera type
        public string mac { get; set; }                     //  Camera MAC address.
        public string physicalId { get; set; }              //  Camera unique identifier
        public bool manuallyAdded { get; set; }             //  Whether the user added the camera manually
        public string model { get; set; }                   //  Camera model.
        public string groupId { get; set; }                 //  Internal group identifier
        public string groupName { get; set; }               //  Group name.This name can be changed by users.
        public string statusFlags { get; set; }             //  Usually this field is zero.Non-zero value indicates that the camera is causing a lot of network issues. Values:
        public string vendor { get; set; }                  //  Camera manufacturer.
        public string userDefinedGroupName { get; set; }    //  Name of the user-defined camera group.
        public bool scheduleEnabled { get; set; }           //  Whether recording to the archive is enabled for the camera
        public bool licenseUsed { get; set; }               //  Whether the license is used for the camera
        public string motionType { get; set; }              //  Type of motion detection method
        public string motionMask { get; set; }              //   List of motion detection areas and their sensitivity
        public ScheduledTask[] scheduledTasks { get; set; } //  List of scheduleTask objects which define the camera recording schedule
        public bool audioEnabled { get; set; }              //  Whether audio is enabled on the camera
        public bool disableDualStreaming { get; set; }      //  false Turn off dual streaming  true Enable dual streaming if it supported by the camera
        public string dewarpingParams { get; set; }         //  Image dewarping parameters
        public int minArchiveDays { get; set; }             //   Minimum number of days to keep the archive for
        public int maxArchiveDays { get; set; }             //   Maximum number of days to keep the archive for
        public Guid preferredServerId { get; set; }         //  Unique id of a server which has the highest priority of hosting the camera for failover (if the current server fails)
        public string failoverPriority { get; set; }        //  Priority for the Camera to be moved to another Server for failover(if the current Server fails)  (Enum)
        public string logicalId { get; set; }               //  
        public int recordBeforeMotionSec { get; set; }      //  The number of seconds before a motion event to record the video for
        public int recordAfterMotionSec { get; set; }       //  The number of seconds after a motion event to record the video for
        public string status { get; set; }                  //  Camera status (enum)  Values:  Offline   Online  Recording  Unauthorized
        public CameraParam[] addParams { get; set; }        //  List of additional parameters for the camera. This list can contain such information as full ONVIF URL, camera maximum FPS, etc

    }

    public class ScheduledTask
    {
        public int startTime { get; set; }                  //  Time of day when the backup starts(in seconds passed from 00:00:00
        public int endTime { get; set; }                    //  Time of day when the backup ends(in seconds passed from 00:00:00)
        public string recordingType { get; set; }           //  Enum   RT_Always Record always. RT_MotionOnly Record only when the motion is detected. RT_Never Never record.   
        public int dayOfWeek { get; set; }                  //  1 Monday to 7 Sunday
        public string streamQuality { get; set; }           //  Quality of the recording.Values: lowest low normal high highest preset undefined
        public int fps { get; set; }                        //  Frames per second (integer).
        public int bitrateKbps { get; set; }                //  

    }

    public class CameraParam
    {
        public string value { get; set; }
        public string name { get; set; }
    }

}
