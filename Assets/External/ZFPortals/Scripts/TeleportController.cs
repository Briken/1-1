using System.Collections.Generic;
using UnityEngine;

namespace ZenFulcrum.Portal {


/**
 * Override this script and attach it to your GameObject to control/be notified of
 * teleports.
 */
public class TeleportController : MonoBehaviour {

        void Start()
        {
            print("starting");
            
        }

	/** 
	 * Called before an object teleports.
	 * Return true to jump, false to not.
	 * May be called multiple times if jump is canceled.
	 */
	public virtual bool BeforeTeleport(Portal portal)
        {
		return true;
	}

	/** 
	 * Called after an object is teleported. 
	 * If your object has internal direction/rotation state, call 
	 * portal.RotateRelativeToDestination (and sometimes TeleportRelativeToDestination)
	 * to update the state to correctly reflect our new location and orientation.
	 */
	public virtual void AfterTeleport(Portal portal)
        {
            //gathering the needed variables
            Vector3 newRot = portal.RotateRelativeToDestination(vp_LocalPlayer.Camera.transform.rotation.eulerAngles);
            Vector3 force = Quaternion.AngleAxis(newRot.y, Vector3.up).eulerAngles;
            float pitch = vp_LocalPlayer.Camera.Pitch;
            float velocity = vp_LocalPlayer.VelocityMagnitude;

            Vector3 norm = Vector3.Normalize(vp_LocalPlayer.Velocity);
            float angle = AngleInDeg(portal.transform.rotation.eulerAngles, portal.destination.parent.rotation.eulerAngles);


            //set camera rotation
            vp_LocalPlayer.Rotation = force;
            vp_LocalPlayer.Camera.Pitch = pitch;


            //calculating entry angle, this needs to equal the exit angle (is actually vice versa)
            //float entry = Vector3.Dot(vp_LocalPlayer.Velocity, portal.transform.rotation.eulerAngles);

            //move player in the right direction
            Vector3 normRot = Vector3.Normalize(Quaternion.AngleAxis(angle, Vector3.up) * vp_LocalPlayer.Velocity);

            //vp_LocalPlayer.EventHandler.Velocity.Set(normRot);
            Vector3 motorThrottle = vp_LocalPlayer.EventHandler.MotorThrottle.Get();
            vp_LocalPlayer.EventHandler.MotorThrottle.Set(normRot * vp_LocalPlayer.EventHandler.MotorThrottle.Get().magnitude);
            //vp_LocalPlayer.Controller.AddForce(normRot);

            //print("Norm = " +norm.x + ", " + norm.y + ", " + norm.z + ";");
            //print("Angle = " + angle);
            //print("NormRot = " + normRot.x + ", " + normRot.y + ", " + normRot.z + ";");


            //vp_LocalPlayer.Move(Quaternion.AngleAxis(force.y, Vector3.up) * vp_LocalPlayer.Velocity);
            //vp_LocalPlayer.Move(new Vector2(force.x, force.y));
            //print(vp_LocalPlayer.VelocityMagnitude);
            //print(force.x);
            //print(force.y);
            //print(force.z);

        }

        //helper functions:
        //This returns the angle in radians
        public static float AngleInRad(Vector3 vec1, Vector3 vec2)
        {
            return Mathf.Atan2(vec2.y - vec1.y, vec2.x - vec1.x);
        }

        //This returns the angle in degrees
        public static float AngleInDeg(Vector3 vec1, Vector3 vec2)
        {
            //print("Angle 1 = " + vec1.y + " , Angle 2 = " + vec2.y);
            return AngleInRad(vec1, vec2) * 180 / Mathf.PI;
        }
    }
}
