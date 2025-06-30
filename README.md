# mouse-controlled-gripper



https://github.com/user-attachments/assets/6cfe71ad-86a9-4697-afaf-c8438bc473b8

Overview
This project demonstrates a functional simulation of a mechanical robotic arm controlled via Inverse Kinematics (IK) in Unity. The arm is capable of dynamically reaching toward a target position in 3D space while respecting joint constraints and physical structure.

The system is built using Unity's animation and physics framework, with a custom IK solver for precise end-effector positioning. It supports interactive control through UI sliders or programmatic input, making it ideal for prototyping robotics behavior, educational visualization, or simulation of robotic grasping.

Features
Fully rigged mechanical arm with articulated joints

Real-time IK solver for end-effector targeting

Joint rotation limits to mimic real robotic constraints

UI interface for testing arm position, rotation, and reach

Modular architecture for easy expansion or replacement of components

Technologies
Unity Engine (C#)

Custom Inverse Kinematics (CCD or FABRIK-style implementation)

UI Toolkit for control interface

Rigidbody-based joint simulation (optional)

Use Cases
Robotics simulation and testing

Educational demos on kinematics

Game mechanics (e.g., robotic puzzles or grabbers)

Industrial UI prototyping
