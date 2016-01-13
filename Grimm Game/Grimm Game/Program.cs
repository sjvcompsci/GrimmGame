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
            // Add an Entity that will use Block.png as its Image
            
            for (int x = 43; x < 6800; x += 96)
            {
                scene.Add(new ImageEntity(x , 434, "Floor.bmp"));
                scene.Add(new ImageEntity(x , 338, "Floor.bmp"));
                scene.Add(new ImageEntity(x, 242, "Floor.bmp"));
                scene.Add(new ImageEntity(x, 158, "Floor.bmp"));
            }
            for (int x = 75; x < 6800; x += 150)
            {
                scene.Add(new ImageEntity(x, 65, "stock-vector-cartoon-brick-wall-79588576.bmp"));
            }

            // Add a PlayerEntity to the Scene at half of the Game's width, and half of the Game's height (centered)
            scene.Add(new PlayerEntity(Game.Instance.HalfWidth, Game.Instance.HalfHeight));



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
        private int test = 6800;
        public override void Update()
        {
            base.Update();
            // Every update check for input and react accordingly.
            // If the A key is down,

            
            if (Input.KeyDown(Key.A))
            {
                // Move left by the move speed.
                 

                if (PlayerEntity.x_value < 100)
                {
                    if ( test <= 6800)
                    {
                        X += 5;
                        test += 5;
                    }
                }
            }
            // If the D key is down,
            if (Input.KeyDown(Key.D))
            {
                if (PlayerEntity.x_value > 500)
                {
                    if (test >= 700)
                    {
                        X -= 5;
                        test -= 5;
                    }
                }
                // Move right by the move speed.
                
            }
        }
    }
        class PlayerEntity : Entity
    {
       
        public PlayerEntity(float x, float y) : base(x, y)
        {
            // Create a rectangle image.
            var image = Image.CreateRectangle(32);
            // Add the rectangle graphic to the Entity.
            AddGraphic(image);
            // Center the image's origin.
            image.CenterOrigin();            
        }
        public static float x_value;
        public override void Update()
        {
            base.Update();
            x_value = X;
            // Every update check for input and react accordingly.
            if (Input.KeyDown(Key.A))
            {
                // Move left by the move speed.
                if (X < 100)
                {

                }
                else
                {
                    X -= 5;
                }
            }
            // If the D key is down,
            if (Input.KeyDown(Key.D))
            {
                if (X > 500)
                {
                   
                }
                else
                {
                    X += 5;
                }
                // Move right by the move speed.
               
            }
            // If the W key is down,
            if (Input.KeyDown(Key.W))
            {
                // Move up by the move speed.
                if (Y < 148)
                {

                }
                else
                {
                    Y -= 5;
                }
             
                
            }
            // If the S key is down,
            if (Input.KeyDown(Key.S))
            {
                // Move down by the move speed.
                if (Y > 460)
                {

                }
                else
                {
                    Y += 5;
                }
            }
           
            // If the space bar key is pressed,
           
        }

    }
}
