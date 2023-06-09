# Game Basic Information #

## Summary ##

In the insect world, survival is a contest of brutality where only the strongest survive. For an ant colony to survive, it must defend itself against vicious invading insects who threaten its existence. And war is hell... Anthell. During the day, dig for resources and shape your anthill into the ultimate fortress. When night falls, command your combat-ants to victory and defend the queen. How long can you last?

Anthell is primarily based on 2D colony management games like Oxygen Not Included and Dwarf Fortress, where the objective is to grow and expand your colony while surviving as long as you can. Anthell uses a similar “invasion” element from Dwarf Fortress where you defend your colony against enemies every night while gathering resources during the day.

## Gameplay Explanation ##

During the day, your main priority should be to collect resources so you can afford stronger ants to defend your queen from the first wave. Command your workers to dig some stone first, so you can use your starting cash to purchase a Carpenter Ant. Using the Carpenter, you can dig wood and other blocks faster. Make a longer path to the queen as well, and try to move her deeper to ensure better protection for her. When night falls, your ants will automatically attack nearby insects (and keep following and attacking them until they are dead) if they have no tasks assigned to them. Position them near areas where insects will pass through, or command them to attack directly, to ensure none are allowed to pass. Repeat this basic loop until you build up more and more resources and cash, so you can afford the stronger ants. Digging deeper and further to the left and right yields more valuable resources! Also, do make sure to remember ants can have multiple tasks assigned to them, and they will complete the sequentially.

(Left mouse button) If clicking on an ant, this selects that ant. If an ant is selected, if you click a block this will tell that ant to dig that block and if you click an insect it will attack that insect; if you click an empty tile with a resource selected it will tell that ant to build that resoruce there and with no resource selected the ant will simply move there.
(WASD) Move camera
(Scroll wheel) Zoom camera in/out
(E) Open/close buy menu
(1234) Select resource
(X) Deselect selected ant and resource

Note: an exploit exists where you can make it unreachable to get to the queen via building, causing the enemies to not be able to attack her. A planned dig functionality for the enemies was planned to patch this.

# Main Roles #

Your goal is to relate the work of your role and sub-role in terms of the content of the course. Please look at the role sections below for specific instructions for each role.

Below is a template for you to highlight items of your work. These provide the evidence needed for your work to be evaluated. Try to have at least 4 such descriptions. They will be assessed on the quality of the underlying system and how they are linked to course content. 

*Short Description* - Long description of your work item that includes how it is relevant to topics discussed in class. [link to evidence in your repository](https://github.com/dr-jam/ECS189L/edit/project-description/ProjectDocumentTemplate.md)

Here is an example:  
*Procedural Terrain* - The background of the game consists of procedurally-generated terrain that is produced with Perlin noise. This terrain can be modified by the game at run-time via a call to its script methods. The intent is to allow the player to modify the terrain. This system is based on the component design pattern and the procedural content generation portions of the course. [The PCG terrain generation script](https://github.com/dr-jam/CameraControlExercise/blob/513b927e87fc686fe627bf7d4ff6ff841cf34e9f/Obscura/Assets/Scripts/TerrainGenerator.cs#L6).

You should replay any **bold text** with your relevant information. Liberally use the template when necessary and appropriate.

## Producer

As producer, I focused a lot on trying to communicate what needs to get done for my vision to come true, and organizing and communicating that to the team. I had some difficulties with this since we didn't meet in person much, but I found technology really useful for this. I made a [Trello] (https://trello.com/invite/b/E3Ah5fS1/ATTI997f6243f679bfd1f3ced6899d87f8583320C8F1/anthell), which helped with assigning tasks, and multiple concept documents to try to get everybody on the same page: [Early design document](https://docs.google.com/document/d/1N7qNQeqybhoHWoEstpf8QLu3AIZwrbUOltSKUbGHoY8/edit#heading=h.ezzdxno2zh9c), [Early codebase plan](https://docs.google.com/document/d/1_OIUqSwkoT4HsPMcKx_qCvzqRNkZkuGh6Bk1TKIa9rY/edit#heading=h.54uhqqyo38an), and [Resources and costs](https://docs.google.com/document/d/1lgzJyZyU6TL8AHHPr3jbyEI9uaPQcsEvJ-oVdZVXC68/edit). I also scheduled meetings through Discord and messaged people to check up on their tasks and ask if they needed help or had any questions.

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



## Movement/Pathfinding

Our game, given that ants can walk on walls, does not use gravity or Unity physics. Instead, our movement relies on the [A* Pathfinding Project Pro](https://assetstore.unity.com/packages/tools/ai/a-pathfinding-project-pro-87744) by Aaron Granberg, which I got on sale a while ago. This asset is very powerful and versatile, and supports a wide range of functions for pathfinding without much difficulty on the user end. The package all relies on the A* GameObject in the scene, which allows you to configure the type of navigation mesh to use. I used a Grid Graph since our game used a tilemap, and setting this up was not too difficult since it auto-generated based on the collision I specified. After that was set up, getting the ants to go where they needed to was as simple as adding a Seeker, AILerp, and Destination Setter, then setting the destination on the destination setter script and enabling movement. One difficulty was making sure the Grid Graph would update as the player placed and broke blocks, but this was handled in the TilemapManager by simply adding these lines, which force the Tilemap Collider to update and then rescans the graph: [TilemapManager](https://github.com/nicholasmueller76/Anthell/blob/acb059705deabe8d1971e2e68678aaa47251afda/Assets/Scripts/TilemapManager.cs#L67-L69)

## Animation and Visuals

For our Animations and Visuals, we used the following assets:

[Insect Enemies](https://jeevo.itch.io/insect-enemies)
[Ants and Bugs](https://shandsparil.itch.io/ants-pixelart)
[Rocky Grass Tileset](https://itch.io/queue/c/2720608/nick-burger-gamess-collection?game_id=478039)
[Pixel Valley](https://kauzz.itch.io/pixel-valley-plataform-tiles)
[Pixel Art Pack for UI](https://assetstore.unity.com/packages/2d/gui/icons/simple-free-pixel-art-styled-ui-pack-165012)
[Tileset](https://ipixl.itch.io/pixel-art-16x16-nature-tiles)
[Weapon Pack](https://vladpenn.itch.io/weapon)
[Guns](https://arcadeisland.itch.io/guns-asset-pack-v1)

Since spriting wasn't an option for us, we used these assets to bring our game world to life.

*Environment* -
For our environment which includes the ground and background we used a couple assets. The Rocky Grass Tileset and the Pixel art nature tiles were used for the underground area, making up most of the playable area. These tiles could be were not just for decoration, they also were also part of our gameplay mechanics. The ants could dig parts of the playable area to build and create new ants. The Pixel Valley Assets were mainly for the background making the playable area seem more like a place where ants would reside. It being an asset came with the added benefit of being able to cast light to it. This allowed for a changing Day and Night setting using the Universal RP package for 2D lights. The day/night cycle is important, as the day is where you are supposed to build up your resources and defenses while the night is where the enemies come out.

*Ants*
The ants sprites and animations are taken from a pack on itch.io. They serve as the primary player controlled entity that litters our game world. They also hold different types of tools and weapons and that pertains to what type of ant they are. These weapon and tool sprites come from both the Weapon asset pack and the Guorions asset packs. The ants are the primarily controlled player character in the game. Adding guns and tools to the ants was primarily due to the concept of the world as well as highlighting which ant did what.

*Enemies*
For our enemy sprites and animations, we ended up using a free pack we found on itch.io which fit our world. They were other bugs of varying types and they were going to be the main antagonists gunning for the ant queen. They don't have anything special regarding tools, but they can do much of the same as the ants can.

*UI*
Our UI although not really matching the nature-esque world that we have defined is made mostly from assets garnered from the Pixel Art Pack For UI. It was simple and free which allowed us to have a somewhat nice UI without having to make one ourselves.

## Input
Two different input types are supported. The first input type is mouse and keyboard. The second input type is touch controls.

*Camera Movement* - The camera can be moved using WASD or arrow keys if using mouse and keyboard. With touch controls, the camera is moved by touching the left side of the screen, then moving your finger in the direction you want the camera to move in. It basically works like a virtual thumbstick. The further you move your finger, the faster the camera moves. To prevent movement when the player is tapping the screen, there is a deadzone where the player must move their finger greater than that area to move the camera. Since there is no player character to follow, the camera is directly moved with player input. The camera’s position is limited to stay within the game’s map. 
https://github.com/nicholasmueller76/Anthell/blob/7ae74dd90c966d43471bb789fdf26b0c0da72a89/Assets/Scripts/InputManager.cs#L284-L290
https://github.com/nicholasmueller76/Anthell/blob/7ae74dd90c966d43471bb789fdf26b0c0da72a89/Assets/Scripts/InputManager.cs#L300
https://github.com/nicholasmueller76/Anthell/blob/7ae74dd90c966d43471bb789fdf26b0c0da72a89/Assets/Scripts/CameraController.cs#L16

*Camera Zooming* - The player can zoom the camera in and out by using the mouse’s scroll wheel. Scrolling up zooms in the camera, scrolling down zooms out the camera. With touch controls, the camera can be zoomed in/out by pinching the screen. There is a maximum distance that the camera can zoom in/out.
https://github.com/nicholasmueller76/Anthell/blob/7ae74dd90c966d43471bb789fdf26b0c0da72a89/Assets/Scripts/InputManager.cs#L292-L296
https://github.com/nicholasmueller76/Anthell/blob/7ae74dd90c966d43471bb789fdf26b0c0da72a89/Assets/Scripts/InputManager.cs#L340
https://github.com/nicholasmueller76/Anthell/blob/7ae74dd90c966d43471bb789fdf26b0c0da72a89/Assets/Scripts/CameraController.cs#L22

*Tile Highlighting* - To aid players in knowing which tile they are selecting, there is a highlight that shows up on the tile when the mouse hovers over it. With touch controls, this highlight shows up when the screen is tapped. This is implemented by converting the mouse’s position on the screen to the world position. Then converting the mouse’s world position to the cell position. Then the tile highlight is a sprite which is placed over the tile at the center of the cell position.
https://github.com/nicholasmueller76/Anthell/blob/7ae74dd90c966d43471bb789fdf26b0c0da72a89/Assets/Scripts/InputManager.cs#L87-L91

*Gameobject Detection on Click* - When the player left clicks, a raycast is done at the mouse’s position. This can be used to detect which gameobject the player is clicking on. This functionality works the same with touch controls. Also the game will not detect gameobjects if the player is clicking on the UI so that players won’t do something like accidentally having an ant use up resources to build something when they’re actually trying to buy something in the shop.
https://github.com/nicholasmueller76/Anthell/blob/7ae74dd90c966d43471bb789fdf26b0c0da72a89/Assets/Scripts/InputManager.cs#L111
https://github.com/nicholasmueller76/Anthell/blob/7ae74dd90c966d43471bb789fdf26b0c0da72a89/Assets/Scripts/InputManager.cs#L67-L85

*Switch Item* - The player can switch the item that they have selected by clicking on the buttons at the bottom of the screen. Clicking a resource that is already selected will deselect it. This action is the same for touch controls. The observer pattern is used here as there is a listener that will call the callback function when the button is clicked.
https://github.com/nicholasmueller76/Anthell/blob/7ae74dd90c966d43471bb789fdf26b0c0da72a89/Assets/Scripts/InputManager.cs#L429
https://github.com/nicholasmueller76/Anthell/blob/7ae74dd90c966d43471bb789fdf26b0c0da72a89/Assets/Scripts/InputManager.cs#L59

*Toggle Shop Menu* - The shop menu can be toggled by pressing E on the keyboard. With touch controls, the shop menu can be closed by swiping right on the right side of the screen. It can be opened by swiping left on the right side of the screen. This is implemented by getting the initial touch position, then getting the position when the player lifts their finger and seeing if that position is to the left or right of the initial position.
https://github.com/nicholasmueller76/Anthell/blob/7ae74dd90c966d43471bb789fdf26b0c0da72a89/Assets/Scripts/InputManager.cs#L257-L265
https://github.com/nicholasmueller76/Anthell/blob/7ae74dd90c966d43471bb789fdf26b0c0da72a89/Assets/Scripts/InputManager.cs#L380
https://github.com/nicholasmueller76/Anthell/blob/7ae74dd90c966d43471bb789fdf26b0c0da72a89/Assets/Scripts/InputManager.cs#L408

## Game Logic

We wanted both ants and enemies to have a task queue and an accompanying manager + assigner. We decided to encapsluate this into a common class called [Entity](https://github.com/nicholasmueller76/Anthell/blob/4e5293370b64ea92161ed637f5e5a817b1d79873/Assets/Scripts/Entity.cs). There is an accompanying Scriptable Object called [EntityData](https://github.com/nicholasmueller76/Anthell/blob/93f71bf4f3a7e1c7b851399232d4a9ada3a85067/Assets/Scripts/EntityData.cs) that contains relevant data for the entity, such as speed and attack damage. Then from inheriting this class, we create a [MoveableEntity](https://github.com/nicholasmueller76/Anthell/blob/676685318438804f7a46c4aaa1adc63d25e56933/Assets/Scripts/MoveableEntity.cs) class which adds a Move (to a specific target) task. Finally, the [Ant](https://github.com/nicholasmueller76/Anthell/blob/a38e8b184b8a3347c54135747d6826a1ed676f8e/Assets/Scripts/Ant.cs) and [Enemy](https://github.com/nicholasmueller76/Anthell/blob/4e5293370b64ea92161ed637f5e5a817b1d79873/Assets/Scripts/Enemy.cs) classes inhert from the MoveableEntity class. The Ant class uses information from the EntityData scriptable object to decide it's functionality, since all ants can do any task, they just do them at different speeds. For enemies however, they have different attack patterns, so the Enemy class it self is an abstract class and for each enemy we implement a monobehaviour for them. E.g. For the [Beetle](https://github.com/nicholasmueller76/Anthell/blob/a38e8b184b8a3347c54135747d6826a1ed676f8e/Assets/Scripts/EnemyScripts/Beetle.cs) and [Mantis](https://github.com/nicholasmueller76/Anthell/blob/a38e8b184b8a3347c54135747d6826a1ed676f8e/Assets/Scripts/EnemyScripts/Mantis.cs)

For the enemy spawning, we followed a similar format to the assignments and had a [GameManager](https://github.com/nicholasmueller76/Anthell/blob/3726ec2bf7f068cac9a50d29d388b5d985e8cb8b/Assets/Scripts/GameManager.cs) object and a spawn point object to use as a reference point to instantiate prefabs of the ants or enemies. We have a [WaveManager](https://github.com/nicholasmueller76/Anthell/blob/20048910f02fe21c1fa78131c9b5d8344e1fd20b/Assets/Scripts/WaveManager.cs) and a [WaveInfo](https://github.com/nicholasmueller76/Anthell/blob/93f71bf4f3a7e1c7b851399232d4a9ada3a85067/Assets/Scripts/WaveInfo.cs) Scriptable Objects to allow the designers to create the waves they want. It includes a random wave generator which depends on the wave number (more difficult the higher the wave number) one it exceeds the staticly assigned list of waves. [public WaveInfo GenerateRandomWave(int waveNumber)](https://github.com/nicholasmueller76/Anthell/blob/32cc180daf9b3b4776de1362cc5d70d5e9e9fed6/Assets/Scripts/WaveManager.cs#L56-L96)

For the sandbox elements of the game, such as the breakable and placeable tiles, I implemented the [TilemapManager] (https://github.com/nicholasmueller76/Anthell/blob/acb059705deabe8d1971e2e68678aaa47251afda/Assets/Scripts/TilemapManager.cs#L7) singleton class which constructs an array of GameObjects at start to store data about the tilemap, since tilemaps normally use ScriptableObjects to store tile data. This data is stored and modified in the [TileEntity](https://github.com/nicholasmueller76/Anthell/blob/3f21ca359055c4ab5c5f79b67bb0f335d78780e8/Assets/Scripts/TileEntity.cs#L6) GameObject, which communicates with the TilemapManager. This setup gives a lot of control over each individual tile while also gaining the benefits of the tilemap system.

For the Input, I created the [InputManager](https://github.com/nicholasmueller76/Anthell/blob/3f21ca359055c4ab5c5f79b67bb0f335d78780e8/Assets/Scripts/InputManager.cs#L9) class, which handles all incoming input from the player. A significant portion of this is relatively simple logic, but the clicking and selecting was a design hurdle. We eventually settled that Left clicking could be used for selecting ants and assigning tasks, depending on what was clicked and having the only target with two tasks associated with it be empty tiles (which have different behavior depending on if you have a resource selected or not). I then simply coded each target type to assign the appropriate task and/or set the appropriate data.

## Audio
All of my Music and SFX assets, were downloaded from itch.io with free-to-use liscenses.

The primary packs I used were:
[Infinity Crisis Core](https://sonatina.itch.io/infinity-crisis-core) - Day theme
[Military Shooter Music Pack](https://augustomazzoli.itch.io/military-shooter-music-pack) - Main Menu theme, Night theme, and Game Over theme, Various SFX
[Shapeforms Audio Free SFX](https://shapeforms.itch.io/shapeforms-audio-free-sfx) - Various SFX
[Minifantasy Dungeon SFX Pack](https://leohpaz.itch.io/minifantasy-dungeon-sfx-pack) - Various SFX (Mostly Combat Noises)
[Horror Sound Effects](https://yourpalrob.itch.io/must-have-horror-sound-effects) - Various SFX
[Sound Effects Survival I](https://darkworldaudio.itch.io/sound-effects-survival-i) - Various SFX

I spent a majority of my time searching and sifting through sound effects and looking for other assets for our project. I wanted a diverse set of music and sfx for each situation, since we had 4 different resources available to be mined, 3 different enemies, and 4 different classes of ants to find sounds for. I wanted to bring a military-esque feel to the game so when looking for music, I focused mostly on songs with prominent drums and sfx with trumpets, and any other sound that fit the feeling of an army.

For my implementation, I created a centralized AudioManager to control all music and sfx for the project. I created a Sound class to store necessary variables for each sound, including: name, clip, volume, pitch, and source. My implementation was based on two Youtube videos:

"Unity AUDIO MANAGER Tutorial" - Rehope Games
"Introduction to AUDIO in Unity" - Brackeys

However, I also used function overloading to allow for more control of sfx to be used in different scenarios. My PlaySFX function has three different options: one that takes in only a name, one that takes in a name and a boolean, and one that takes in an array of names. The first one is the basic one, it simply plays the sound effect desccribed by the name. The second, includes a way of looping the sound effect, which was helpful because the digging sounds needed to be looped until the digging task was done. The third played a random sound from the array provided. I wanted to try to avoid repeating sounds too much, especially on attack/taking damage sounds, so I implemented this function as a way of bringing variety. I also included methods to stop sfx and music when I ran into issues with sounds that wouldn't stop when they were supposed to. Finally, as we continued to develop the project, I implemented Music and SFX where appropriate, and found new sounds when the situation required.

# Sub-Roles

## Cross-Platform
The platform that was our main focus for the game was PC. Then I decided to add mobile support to the game. This video is a demo of the touch controls with taps shown on screen: https://www.youtube.com/watch?v=JlXvbyrcs1w

*Mobile Port* - Initially, I had problems trying to create a mobile port as I was getting errors in Unity regarding a part of the directory involving Gradle dependency-locks being missing when trying to export the game to Android. I tried multiple ways to troubleshoot this issue including reinstalling the editor with the Android module. However, I was still getting the same error message about the missing directory. While I wasn’t able to get an Android port working, I figured out another way to create a mobile port by exporting the project as a WebGL app then putting it on itch.io which then allows the game to be played on mobile. I found that it worked using Chrome for Android, though I was not able to test this on iOS devices. This may also work on tablets that run Windows, but I also was not able to test this. However, since I was unable to get an Android build working, this made debugging the touch controls difficult as I couldn’t see the console for any logs.

*Touch Controls* - A challenging part of this sub role was trying to manage the different controls used in the game. As the game progressed further in development, more controls were added which meant that I needed to figure out an equivalent way to perform the same action with touch controls. For example, players on PC can move the camera using WASD or the arrow keys. However, since players on mobile are most likely not going to have a keyboard connected to their phone, I needed to come up with a different way to move the camera. My solution was to implement something like a virtual thumbstick where the player can touch the bottom left corner of their screen and then move their finger in the direction they want the camera to move. Another control I needed to remap was opening and closing the shop menu. On PC players just press E, but mobile players don’t have keyboards so I implemented this action by having the players swipe left/right on the right side of the screen to open/close the shop menu. Another example is that on PC, players can deselect the ant by pressing X, so I implemented this with touch controls by letting the players touch the selected ant again to deselect it. Luckily, some of the controls were easy to port to mobile as they required little to no changes. For example, the action of left clicking with the mouse is interpreted the same as a tap on touch controls, so I only had to make very few changes to ensure that any action using left clicks works on mobile.
https://github.com/nicholasmueller76/Anthell/blob/7ae74dd90c966d43471bb789fdf26b0c0da72a89/Assets/Scripts/InputManager.cs#L300
https://github.com/nicholasmueller76/Anthell/blob/7ae74dd90c966d43471bb789fdf26b0c0da72a89/Assets/Scripts/InputManager.cs#L340
https://github.com/nicholasmueller76/Anthell/blob/7ae74dd90c966d43471bb789fdf26b0c0da72a89/Assets/Scripts/InputManager.cs#L380 

## Gameplay Testing

As we finished the gameplay systems relatively late, we didn't have much time for testing. However, we did end up getting a series of tests in to balance the first wave of enemies to ensure it was not too easy and not too hard. For the next build, we would've gotten much more testing in to add more waves and get more feedback.

First iteration: This wave was way too hard, as it had about as many beetles as the final iteration with double the health and additionally, a second mantis that comes in at the end. This wave was also way too hard without a carpenter ant because the player had no starting cash. Instead of nerfing the stats though, the next iteration spaced out the enemies more and got rid of the second mantis, and gave the player 100 starting cash.

Second iteration: This wave was better, but the beetles still became overwhelming to the player. They were too fast and ants couldn't prevent them from reaching the queen. To try to fix this, the beetle speed was lowered.

Third iteration: Beetles still end up killing ants faster than the player can replace them to defend the queen. Cash rewards for the mantis and beetle were rebalanced, and the beetle's attack was nerfed. Less beetles in the wave.

Fourth iteration: Much more survivable than previous waves, but also shorter. To make the wave take up more of the 180 seconds of night, beetles had their health cut in half but there are now much more beetles in the wave.

Fifth iteration: Now at a decent level of difficulty that should hopefully be manageable to the average player.

## Narrative Design

Responsibilities: To create descriptions for various game assets and integrate it with the UI elements. Provide information to the player both game mechanic related and fun lore.  [My Small Narrative Design Document](https://docs.google.com/document/d/1w1O95kbdPgVgMTn8Z7oiCaZbns_CrKMR95AAKDEnuiU/edit).

I found it straightforward in creating descriptions for the various assets that made it fit into the game, as well as providing the player with more information on what the specific asset does/is used for and how it fit into the game.

I couldn't find good references to my narrative descriptions because they are found in the secene files

*Description for Player Assets* - Descriptions for each ant the player can buy/spawn. A description that gives a little narrative of the ant and its role in the colony. It also has a description of its stats that is related to the gameplay such as what is its health and damage, or what type of task is it good at. 

*Descriptions for Enemies* - Description for each enemy the player will face, combining story elements and how they affect gameplay and skills they use against the player.

*Intro & HowToPlay* - Short story and gameplay introduction for the player in the main menu. 


## Press Kit and Trailer

[Press Kit](https://docs.google.com/document/d/19rNaiatObL4ZzlPjjtPrdOzDXSqwfz1nsnIY_UtPWxk/edit?usp=sharing)
[Trailer](https://youtu.be/lgkBmZA2Po4)

For my press kit and trailer, I wanted to showcase how the game played and it's mechanics. So in the trailer I mostly highlighted the core mechanics of the game and mostly showed a real run of the game. For my screen shots in my press kit, we I didn't really think we needed that many screenshots of the game since the trailer was for the showcase. I added some pictures of the Ant sprites however.


## Game Feel


- Changing input controls: I suggested ideas on making the game feel better, such as having tooltips (i.e. show information on hover) instead of having to click on the ant/enemy to get info on it. Also, we were discussing on what the camera inputs should be, either WASD or hold right click and drag to move around the camera. We decided that WASD would be better since it allows for moving the cursor and moving the camera at the same time.

- Adding particle effects: I added in the particle effects because I thought it looked weird if blocks and enemies just disappeared when they were destroyed, with particle effects these feel more weighty and responsive.

## User Interface 2

I made a Game Over menu, with options to retry and go to main menu. I also implemented the calling of the Game Over Scene when the Queen ant was killed.
