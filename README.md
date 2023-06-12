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

*Resource Counters/Buttons* - The game has different materials that are collected and can be used to build or buy other assets for the player. Five buttons at the bottom of the screen also keep track of how many of each resource the player has, updating when the player gains or uses one of the resources. The resource counters are buttons allowing the player to choose what material they want to build with. This is similar to exercise 1 with keeping track of resource amounts via the ResourceManager script. [ResourceManager Script](https://github.com/nicholasmueller76/Anthell/blob/0f09204b09511f045fd55f54c5f90419fcba61a1/Assets/Scripts/ResourceManager.cs#LL6C18-L6C18).

*Buy Menu* - The game features a buy menu that allows the player to buy different assets in the game, as well as offers an information button for each asset that switches the menu to text showing stats and descriptions of each available asset. Each buy button is mapped to a corresponding buy function in the Shopenu script. I made the script as a framework for easy implementation of all relevant game functions. [ShopMenu Script](https://github.com/nicholasmueller76/Anthell/blob/0f09204b09511f045fd55f54c5f90419fcba61a1/Assets/Scripts/ShopMenu.cs#L5).

*Main Menu* - The game features an interactive Main Menu screen that has multiple different menus, such as how to play screen with information about different aspects of the screen, and a credits screen. This interface uses buttons to switch between each menu and is also able to start and exit the game via the MainMenu script. [MainMenu Script](https://github.com/nicholasmueller76/Anthell/blob/0f09204b09511f045fd55f54c5f90419fcba61a1/Assets/Scripts/MenuManager.cs#LL6C24-L6C24). [Ant Descriptions](https://github.com/nicholasmueller76/Anthell/blob/0f09204b09511f045fd55f54c5f90419fcba61a1/Assets/Scenes/MainMenu.unity#LL4518C12-L4518C12)


## Movement/Physics

**Describe the basics of movement and physics in your game. Is it the standard physics model? What did you change or modify? Did you make your movement scripts that do not use the physics system?**

## Animation and Visuals

**List your assets including their sources and licenses.**

**Describe how your work intersects with game feel, graphic design, and world-building. Include your visual style guide if one exists.**

## Input

**Describe the default input configuration.**

**Add an entry for each platform or input style your project supports.**

## Game Logic

**Document what game states and game data you managed and what design patterns you used to complete your task.**

# Sub-Roles

## Cross-Platform

**Describe the platforms you targeted for your game release. For each, describe the process and unique actions taken for each platform. What obstacles did you overcome? What was easier than expected?**

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
