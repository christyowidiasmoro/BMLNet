# Rage BMLNet [![Build Status](https://travis-ci.org/christyowidiasmoro/BMLNet.svg?branch=master)](https://travis-ci.org/christyowidiasmoro/BMLNet)

# Table of Contents

- [Unity3D Implementation] (#unity3d-implementation)



### Unity Implementation

You need to define the package 

		using AssetPackage;
		using BMLNet;

Inside your class, you need to create variable for RageBMLNet

		RageBMLNet bml = new RageBMLNet();

To parse BML schema from file text

		bml.ParseFromFile("assets/BML.xml");
		
To parse BML schema from string 

        bml.ParseFromString(System.IO.File.ReadAllText("assets/BML.xml"));
		
In order to monitor the BML synchronization time, we need to assign the callback

        bml.OnSyncPointCompleted += SyncPointCompleted;
		
And this is the callback for synchronization

		void SyncPointCompleted(string behaviorID, string eventName)
		{
			BMLBlock block = bml.GetBehaviorFromId(behaviorID);
		
			GameObject character = GameObject.Find(block.getCharacterId());
			 if (block is BMLFace)
			{
				BMLFace face = (BMLFace)block;

			}
			else if (block is BMLFaceFacs)
			{
				BMLFaceFacs face = (BMLFaceFacs)block;

			}
			else if (block is BMLFaceLexeme)
			{
				BMLFaceLexeme face = (BMLFaceLexeme)block;

			}
			else if (block is BMLFaceShift)
			{
				BMLFaceShift face = (BMLFaceShift)block;

			}

			else if (block is BMLGaze)
			{
				BMLGaze gaze = (BMLGaze)block;

			}
			else if (block is BMLGazeShift)
			{
				BMLGazeShift gazeShift = (BMLGazeShift)block;

			}

			else if (block is BMLGesture)
			{
				BMLGesture gesture = (BMLGesture)block;

			}
			else if (block is BMLPointing)
			{
				BMLPointing pointing = (BMLPointing)block;

			}

			else if (block is BMLHead)
			{
				BMLHead head = (BMLHead)block;


			}
			else if (block is BMLHeadDirectionShift)
			{
				BMLHeadDirectionShift headDirectionShift = (BMLHeadDirectionShift)block;

			}

			else if (block is BMLLocomotion)
			{
				BMLLocomotion locomotion = (BMLLocomotion)block;

			}

			else if (block is BMLPosture)
			{
				BMLPosture posture = (BMLPosture)block;

			}
			else if (block is BMLPostureShift)
			{
				BMLPostureShift postureShift = (BMLPostureShift)block;

			}
			else if (block is BMLStance)
			{
				BMLStance stance = (BMLStance)block;

			}
			else if (block is BMLPose)
			{
				BMLPose pose = (BMLPose)block;

			}

			else if (block is BMLSpeech)
			{
				BMLSpeech speech = (BMLSpeech)block;

			}
		}
		
If you want to trigger the synchronization point from Unity, you can call this function

        bml.TriggerSyncPoint(behaviorId, eventName);



