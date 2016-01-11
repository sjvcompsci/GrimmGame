using Otter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InputInteraction
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a Game
            var game = new Game("Input Example");

            // Create a Scene
            var scene = new Scene();
            // Add a PlayerEntity to the Scene at half of the Game's width, and half of the Game's height (centered)
            scene.Add(new PlayerEntity(Game.Instance.HalfWidth, Game.Instance.HalfHeight));

            // Add an Entity that will use Block.png as its Image
            scene.Add(new ImageEntity(150, 150, "Block.png"));
            
            // Start the game using the created Scene.
            game.Start(scene);
        }
    }
    class ImageEntity : Entity
    {
        public ImageEntity(float x, float y, string imagePath) : base(x, y)
        {
            // Create an Image using the path passed in with the constructor
            var image = new Image(imagePath);
            // Center the origin of the Image
            image.CenterOrigin();
            // Add the Image to the Entity's Graphic list.
            AddGraphic(image);
        }
    }

        class PlayerEntity : Entity
    {

        /// <summary>
        /// The current move speed of the Entity.
        /// </summary>
        public float MoveSpeed;

        /// <summary>
        /// The move speed for when the Entity is moving slowly.
        /// </summary>
        public const float MoveSpeedSlow = 5;
        /// <summary>
        /// The move speed for when the Entity is moving quickly.
        /// </summary>
        public const float MoveSpeedFast = 10;

        public PlayerEntity(float x, float y) : base(x, y)
        {
            // Create a rectangle image.
            var image = Image.CreateRectangle(32);
            // Add the rectangle graphic to the Entity.
            AddGraphic(image);
            // Center the image's origin.
            image.CenterOrigin();

            // Assign the initial move speed to be the slow speed.
            MoveSpeed = MoveSpeedSlow;
        }

        public override void Update()
        {
            base.Update();
            // Every update check for input and react accordingly.

            // If the W key is down,
            if (Input.KeyDown(Key.W))
            {
                // Move up by the move speed.
                Y -= MoveSpeed;
            }
            // If the S key is down,
            if (Input.KeyDown(Key.S))
            {
                // Move down by the move speed.
                Y += MoveSpeed;
            }
            // If the A key is down,
            if (Input.KeyDown(Key.A))
            {
                // Move left by the move speed.
                X -= MoveSpeed;
            }
            // If the D key is down,
            if (Input.KeyDown(Key.D))
            {
                // Move right by the move speed.
                X += MoveSpeed;
            }

            // If the space bar key is pressed,
            if (Input.KeyPressed(Key.Space))
            {
                // If the Entity is currently slow,
                if (MoveSpeed == MoveSpeedSlow)
                {
                    // Set the Entity to fast,
                    MoveSpeed = MoveSpeedFast;
                    // And make its Color red.
                    Graphic.Color = Color.Red;
                }
                // If the Entity is currently fast,
                else {
                    // Set the Entity to slow,
                    MoveSpeed = MoveSpeedSlow;
                    // And make its Color white.
                    Graphic.Color = Color.White;
                }
            }
        }

    }
}
