using Otter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OgmoEditorStuff
{
    class Program
    {
        static void Main(string[] args)
        {

            // Create a new Game.
            var game = new Game("Ogmo Editor Example");
            // Set the background color to see stuff a little better.
            game.Color = Color.Cyan;

            // Create a new Scene to use for the Ogmo data.
            var scene = new Scene();

            // The path to the level to be loaded.
            var pathLevel = "Level.oel";
            // The path to the Ogmo Project to use when loading the level.
            var pathProject = "OgmoProject.oep";

            // Create a new OgmoProject using the .oep file.
            var OgmoProject = new OgmoProject(pathProject);

            // Ensure that the grid layer named "Solids" gets the Solid collision tag when loading.
            OgmoProject.RegisterTag(Tags.Solid, "Solids");

            // Load the level into the Scene.
            OgmoProject.LoadLevelFromFile(pathLevel, scene);

            // Start the game using the Scene with the loaded Ogmo Level.
            game.Start(scene);
        }
    }

    // Collision tags to use in the game.
    enum Tags
    {
        Solid,
        Player,
        Coin,
        Exit
    }

    // A Player Entity to match the Entity in the Ogmo Project.
    class Player : Entity
    {
        public Player(float x, float y) : base(x, y)
        {
            var img = Image.CreateRectangle(32, 32, Color.Red);
            AddGraphic(img);
            SetHitbox(32, 32, Tags.Player);
        }
    }

    // A Coin Entity to match the Coin in the Ogmo Project.
    class Coin : Entity
    {
        public Coin(float x, float y) : base(x, y)
        {
            var img = Image.CreateRectangle(16, 16, Color.Yellow);
            AddGraphic(img);
            SetHitbox(16, 16, Tags.Coin);

            // Adjust the position here because of the Origin in the Ogmo Project.
            X += 8;
            Y += 8;
        }
    }

    // An Exit Entity to match the Exit in the Ogmo Project.
    class Exit : Entity
    {
        public Exit(float x, float y) : base(x, y)
        {
            var img = Image.CreateRectangle(64, 64, Color.Magenta);
            AddGraphic(img);
            SetHitbox(64, 64, Tags.Exit);
        }
    }
}