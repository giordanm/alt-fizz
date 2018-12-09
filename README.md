# alt-fizz
Alternate physics VR project

VERSION OF UNITY
2018.2.15f1


VERSION OF PLAYMAKER
PlayMaker 1.9.0 was used to control the level and to transition between scenes


ASSETS
Bow and Arrow asset came from FusedVR’s youtube channel’s GitHub:  bit.ly/1TrAigV 

~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

GUIDE TO SETTING UP A SCENE TO HAVE A BOW

“Level” is a template scene, meaning you can use it as a basis for creating new scenes. It already contains the bow and a first person character.

Special Controller & Special Bow
Both need to be in scene in order to use them.

Setting up Special Controller:
Go to RightHandAnchor
String Attach Point = SpecialBow -> Bow -> main -> string
Arrow Start Point = SpecialBow -> Bow -> main -> StringStart -> ArrowStart
String Start Point = SpecialBow -> Bow -> main -> StringStart
DO NOT PUT ANYTHING INTO CURRENT ARROW

Setting up Special Bow:
Go to Special Bow, scroll down to Hand Magic (Script)
Hand = SpecialController -> OVRCameraRig -> TrackingSpace -> LocalAvatar ->hand_left
Otherhand = SpecialController -> OVRCameraRig -> TrackingSpace -> LocalAvatar ->hand_right
Arrowthing = SpecialController -> OVRCameraRig -> TrackingSpace -> RightHandAnchor

The various arrow prefabs are essentially done, you’re never going to manually put them in the scene. If you want an object to spawn them, you’ll need to create a script for them (name it something along the line of arrow_Spawner), have a public gameObject thingToSpawn, set it to the desired arrow prefab, and have the object at some point call Instantiate(thingToSpawn);

~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

PLAYMAKER STATE MACHINE

Progress through the level is controlled by a PlayMaker state machine, attached to an invisible plane. Most levels use a linear series of states to represent the activation of a series of switches, which are scripted to send the “buttonpressed” event to the state machine when given conditions are met i.e. ‘button is touched by fire.” When all objectives in a level are completed, the state machine activates the level exit gameobject, allowing the player to proceed to the next level. Playmaker actions were also used to transition between scenes.

~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

ARISTOTLE'S SCRIPT, SCENE BY SCENE

MAIN MENU ( “DEMOTitle” is the name of this scene in Unity)
No script

LEVEL 1 - target practice (“ArrowTutorial”)
“Hello, dear pupil. I am Aristotle. Welcome to the Aristotelian Physics Lab, where you will learn how we perceived physics in MY day!”
> Bow and arrow appears
“For our experiments, I have given you a bow and arrow. Look at the image on the wall to learn how to grab and use it. Now try to hit the targets on the floor by shooting them from afar! When you’ve turned all three targets green, you can proceed to the next level.”
> Player grabs arrow and hits targets on floor
“Wonderful! Let go of the bow and grab the “next level” box floating somewhere around you.”

LEVEL 2 - the hole (“StarWars”)
> Bow and arrow appear
“For this level, grab the bow and arrow again, and try to shoot the target at the bottom of that hole!”
> 5 second buffer
“Ahh, I’ve realized I’ve given you the regular physics arrow. While holding the bow, press X to change to an Aristotelian physics arrow! Their projectile motion will seem a bit strange to you, but should be effective for shooting the target in that hole.”
“In MY day, everything in the world was composed of four elements: earth, water, air, and fire. The light brown arrow you are holding is composed of Aristotelian earth. Its horizontal motion decays more quickly than in regular physics, because Aristotelian earth is eager to move downwards, towards the center of the world. You will learn about the other three elements soon.
> Player shoots the target in the hole
“Great job! Grab the “next level” box floating somewhere around you.

LEVEL 3 - one button (“FirstLevel”)
“In front of you, there are some buttons that have been activated by dropping Aristotelian earth onto them. Use an Aristotelian earth arrow to change that final box to earth. The box is currently filled with Aristotelian fire! Fire rises away from the center of the world, that’s why its stuck on the roof. Change it to earth, and it will fall towards the center of the world and activate the final button!
> Done
“Superb! Now join me at the next level.”

LEVEL 4 - 4 buttons (“Room2”)
“So now you know earth is the most dense Aristotelian element, and fire is the least dense. I will now introduce the final elements. There are 4 Aristotelian air boxes floating around you. Air is more dense than fire and less dense than water and earth -- it just stays in place when surrounded by air. Water is less dense than earth, but will fall towards the center of the world, just like earth. Press X to change your arrow elements and match the boxes to their corresponding buttons!”
> Player shoots the boxes and they fall/rise onto corresponding buttons
“By Athens! You did it! Follow me to the next level by grabbing the box that appeared somewhere in the room.”
> Player grabs teleporter

LEVEL 5 - walls (“Room 2 copy”)
“This level is a little tricky. I’ll leave you to figure it out!”
> They hit the final box
“You did it! I knew I could believe in you! Now grab the “next level” box.
Level 6 - carpet ride (“CarpetRide”)
“Hmm, you’ve got to use your noodle for this level! Good luck!”
> Player finds next level box

LEVEL 7 - island (“Island”)
“Great job! You’ve finished all of my experiments. Now enjoy your vacation on Aristotle’s private island! Feel free to play around!

~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

OTHER NOTES

We have implemented a "fail safe" / “panic button” to be used if you somehow get stuck in an unwinnable state. It’s not described in the image that we have posted on the wall of each room, but it should be added. You have to pull both triggers on the top of the oculus hand controls for several seconds and it will take you to the main menu.
