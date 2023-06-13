# Game Basic Information #

## Summary ##

**A paragraph-length pitch for your game.**

## Gameplay Explanation ##

**In this section, explain how the game should be played. Treat this as a manual within a game. It is encouraged to explain the button mappings and the most optimal gameplay strategy.**


**If you did work that should be factored in to your grade that does not fit easily into the proscribed roles, add it here! Please include links to resources and descriptions of game-related material that does not fit into roles here.**

# Main Roles #

Your goal is to relate the work of your role and sub-role in terms of the content of the course. Please look at the role sections below for specific instructions for each role.

Below is a template for you to highlight items of your work. These provide the evidence needed for your work to be evaluated. Try to have at least 4 such descriptions. They will be assessed on the quality of the underlying system and how they are linked to course content. 

*Short Description* - Long description of your work item that includes how it is relevant to topics discussed in class. [link to evidence in your repository](https://github.com/dr-jam/ECS189L/edit/project-description/ProjectDocumentTemplate.md)

Here is an example:  
*Procedural Terrain* - The background of the game consists of procedurally-generated terrain that is produced with Perlin noise. This terrain can be modified by the game at run-time via a call to its script methods. The intent is to allow the player to modify the terrain. This system is based on the component design pattern and the procedural content generation portions of the course. [The PCG terrain generation script](https://github.com/dr-jam/CameraControlExercise/blob/513b927e87fc686fe627bf7d4ff6ff841cf34e9f/Obscura/Assets/Scripts/TerrainGenerator.cs#L6).

You should replay any **bold text** with your relevant information. Liberally use the template when necessary and appropriate.

## Producer

**Describe the steps you took in your role as producer. Typical items include group scheduling mechanism, links to meeting notes, descriptions of team logistics problems with their resolution, project organization tools (e.g., timelines, depedency/task tracking, Gantt charts, etc.), and repository management methodology.**

## User Interface

Responsibilities:
My responsibilites as user interface was to create the main menu and in game menus that allow the player to interact with several game mechanics. 
This included:
- Main Menu
- Buy Menu
- Resource Counters

Successes:
Some successes I found while creating the UI was mapping all the buttons to their corresponding function. This was done in two ways, the first was the transition buttons, that switched the menu from one menu/information to another, this was done in the scene with the easy to use button events. The other way was through a menu manager script that held all the relevant functions the buttons would do, such as buying player assets or starting the game.

Obstacles:
There was a few obstacles at first when I was creating the game. The first obstacle was designing the layout of the UI buttons and texts, where they are placed on the screen, what they would display, and what it would allow the player to do. After trial and error and more insight with the game mechanics, I was able to decided on a layout that would be usefull to the player. Another obstacle was the ui elements not staying in the same positions relative to eachother when the game screen was resized. I had to learn to prevent the misposition of ui elements by comforming them to specific positions that changed with the screen size.

*Resource Counters/Buttons* - The game has different materials that are collected and can be used to build or buy other assets for the player. Five buttons at the bottom of the screen also keep track of how many of each resource the player has, updating when the player gains or uses one of the resources. The resource counters are buttons allowing the player to choose what material they want to build with. This is similar to exercise 1 with keeping track of resource amounts via the ResourceManager script. [ResourceManager Script](https://github.com/nicholasmueller76/Anthell/blob/0f09204b09511f045fd55f54c5f90419fcba61a1/Assets/Scripts/ResourceManager.cs#LL6C18-L6C18).

*Buy Menu* - The game features a buy menu that allows the player to buy different assets in the game, as well as offers an information button for each asset that switches the menu to text showing stats and descriptions of each available asset. Each buy button is mapped to a corresponding buy function in the Shopenu script. I made the script as a framework for easy implementation of all relevant game functions. [ShopMenu Script](https://github.com/nicholasmueller76/Anthell/blob/0f09204b09511f045fd55f54c5f90419fcba61a1/Assets/Scripts/ShopMenu.cs#L5).

*Main Menu* - The game features an interactive Main Menu screen that has multiple different menus, such as how to play screen with information about different aspects of the screen, and a credits screen. This interface uses buttons to switch between each menu and is also able to start and exit the game via the MainMenu script. [MainMenu Script](https://github.com/nicholasmueller76/Anthell/blob/0f09204b09511f045fd55f54c5f90419fcba61a1/Assets/Scripts/MenuManager.cs#LL6C24-L6C24). [Ant Descriptions](https://github.com/nicholasmueller76/Anthell/blob/0f09204b09511f045fd55f54c5f90419fcba61a1/Assets/Scenes/MainMenu.unity#LL4518C12-L4518C12)



## Movement/Physics

**Describe the basics of movement and physics in your game. Is it the standard physics model? What did you change or modify? Did you make your movement scripts that do not use the physics system?**

## Animation and Visuals

**List your assets including their sources and licenses.**

**Describe how your work intersects with game feel, graphic design, and world-building. Include your visual style guide if one exists.**

## Input
Two different input types are supported. The first input type is mouse and keyboard. The second input type is touch controls.

*Camera Movement* - The camera can be moved using WASD or arrow keys if using mouse and keyboard. With touch controls, the camera is moved by touching the left side of the screen, then moving your finger in the direction you want the camera to move in. It basically works like a virtual thumbstick. The further you move your finger, the faster the camera moves. To prevent movement when the player is tapping the screen, there is a deadzone where the player must move their finger greater than that area to move the camera. Since there is no player character to follow, the camera is directly moved with player input. The camera’s position is limited to stay within the game’s map.

*Camera Zooming* - The player can zoom the camera in and out by using the mouse’s scroll wheel. Scrolling up zooms in the camera, scrolling down zooms out the camera. With touch controls, the camera can be zoomed in/out by pinching the screen. There is a maximum distance that the camera can zoom in/out.

*Perform Action* - The player can have an ant perform an action by left clicking on the ant to select it, then right clicking on the mouse or double clicking on a target to perform the action. With touch controls, the player taps on an ant, then double taps on the target. The gameobject that the player is clicking on is detected using raycasts to retrieve the gameobject and then comparing tags.

*Switch Item* - The player can switch the item that they have selected by clicking on the buttons at the bottom of the screen. This action is the same for touch controls. The observer pattern is used here as there is a listener that will call the callback function when the button is clicked.

*Toggle Shop Menu* - The shop menu can be toggled by pressing E on the keyboard. With touch controls, the shop menu can be closed by swiping right on the right side of the screen. It can be opened by swiping left on the right side of the screen. This is implemented by getting the initial touch position, then getting the position when the player lifts their finger and seeing if that position is to the left or right of the initial position.

## Game Logic

**Document what game states and game data you managed and what design patterns you used to complete your task.**

# Sub-Roles

## Cross-Platform
The platform that was our main focus for the game was PC. Then I decided to add mobile support to the game. 

*Mobile Port* - Initially, I had problems trying to create a mobile port as I was getting errors in Unity regarding a part of the directory involving Gradle dependency-locks being missing when trying to export the game to Android. I tried multiple ways to troubleshoot this issue including reinstalling the editor with the Android module. However, I was still getting the same error message about the missing directory. While I wasn’t able to get an Android port working, I figured out another way to create a mobile port by exporting the project as a WebGL app then putting it on itch.io which then allows the game to be played on mobile. I found that it worked using Chrome for Android, though I was not able to test this on iOS devices. This may also work on tablets that run Windows, but I also was not able to test this. However, since I was unable to get an Android build working, this made debugging the touch controls difficult as I couldn’t see the console for any logs.

*Touch Controls* - A challenging part of this sub role was trying to manage the different controls used in the game. As the game progressed further in development, more controls were added which meant that I needed to figure out an equivalent way to perform the same action with touch controls. For example, players on PC can have the ants perform an action by using right click. However, since mobile players wouldn’t have a mouse to perform this action, I had to come up with an alternative to right clicking. My solution was to detect for double clicks so that mobile players can double tap on a target to execute an action. Luckily, some of the controls were easy to port to mobile as they required little to no changes. For example, the action of left clicking with the mouse is interpreted the same as a tap on touch controls, so I did not have to remap the controls for anything that used left click.

## Audio

**List your assets including their sources and licenses.**

**Describe the implementation of your audio system.**

**Document the sound style.** 

## Gameplay Testing

**Add a link to the full results of your gameplay tests.**

**Summarize the key findings from your gameplay tests.**

## Narrative Design

I couldn't find good references to my narrative descriptions because they are found in the secene files

*Description for Player Assets* - Descriptions for each ant the player can buy/spawn. A description that gives a little narrative of the ant and its role in the colony. It also has a description of its stats that is related to the gameplay such as what is its health and damage, or what type of task is it good at. 

*Descriptions for Enemies* - Description for each enemy the player will face, combining story elements and how they affect gameplay and skills they use against the player.

*Intro & HowToPlay* - Short story and gameplay introduction for the player in the main menu. 


## Press Kit and Trailer

**Include links to your presskit materials and trailer.**

**Describe how you showcased your work. How did you choose what to show in the trailer? Why did you choose your screenshots?**



## Game Feel

**Document what you added to and how you tweaked your game to improve its game feel.**
