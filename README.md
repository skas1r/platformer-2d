# Infinite Forest

A simple 2D platformer built with Unity. Explore the path through the forest, overcome the terrain and obstacles, and reach the final statue to win.

## Features

- Side-scrolling 2D platforming
- Four playable scenes (`Scene_1` through `Scene_4`)
- Unity 2D sprites, tile palettes, animations, prefabs, and materials
- Player movement and camera support powered by Unity's 2D and Input System features
- Cinemachine camera tooling
- TextMesh Pro interface support
- Sound effects and audio manager configuration
- A Windows build included in `Biuld/v1.0` (folder name preserved as in the project)

## Requirements

- Unity Hub
- Unity Editor **6000.3.24f1** (matching `ProjectSettings/ProjectVersion.txt`)
- A Windows, macOS, or Linux system capable of running the Unity Editor

The project also uses the Unity 2D feature set, the new Input System, Cinemachine, TextMesh Pro, and Unity Visual Scripting. These packages are declared in `Packages/manifest.json` and can be restored automatically by the Editor.

## Run from the source project

1. Install Unity Hub and Unity Editor **6000.3.24f1**.
2. Clone the repository:

   ```bash
   git clone https://github.com/skas1r/platformer-2d.git
   cd platformer-2d
   ```

3. Open Unity Hub, select **Add project from disk**, and choose the cloned repository folder.
4. Open the project with Unity **6000.3.24f1**. Allow Unity to import assets and resolve packages.
5. In the Project window, open `Assets/Scenes/Scene_1.unity`.
6. Press **Play** in the Unity Editor.

To export the game, use **File > Build Profiles** (or **File > Build Settings** in older versions), select your target platform, and choose **Build**.

## Run the included Windows build

A Windows build is located in:

```text
Biuld/v1.0/InfiniteForest.exe
```

On Windows:

1. Download or clone the entire repository so that `InfiniteForest.exe` and `InfiniteForest_Data` remain together.
2. Open `Biuld/v1.0`.
3. Run `InfiniteForest.exe`.

Some Git or download environments may not include the large binary assets locally; if the executable is not runnable, build the project directly in Unity using the source files.

## Controls

Use the controls configured in the project. Default keyboard controls are set through Unity's Input Manager and Input System assets. A controller may also work if supported by the active input configuration.

## Project structure

```text
Assets/
  Animations/       Character and object animations
  InputSystems/     Input System assets
  Materials/        Rendering materials
  Palettes/         2D tile palettes
  Prefabs/          Reusable game objects
  Scenes/           Scene_1 through Scene_4
  Scripts/          C# gameplay scripts
  Sounds/           Audio assets
  Sprites/          2D artwork and textures
ProjectSettings/    Unity project configuration
Packages/           Package dependencies
Biuld/v1.0/         Included Windows build
```
