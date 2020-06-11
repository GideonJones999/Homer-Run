using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Audio;

namespace HomerRun
{
    public class Game1 : Game
{
    // GLOBAL VARIABLES
    GraphicsDeviceManager graphics;
    SpriteBatch spriteBatch;
    public static ContentManager content;
    Texture2D back;
    Rectangle backRec;

        Homer homer = new Homer();
    public Game1()
    {
        graphics = new GraphicsDeviceManager(this);
        graphics.PreferredBackBufferWidth = 1200;
        graphics.PreferredBackBufferHeight = 950;
        Content.RootDirectory = "Content";
        content = Content;
    }
    protected override void Initialize()
    {
        backRec = new Rectangle(0, 0, 1200, 950);
            homer = new Homer(content.Load<Texture2D>("homer_1"),content.Load<SoundEffect>("monkey_1"));

        base.Initialize();
    }
    protected override void LoadContent()
    {
        // Create a new SpriteBatch, which can be used to draw textures.
        spriteBatch = new SpriteBatch(GraphicsDevice);
        back = Content.Load<Texture2D>("jungle_1");
    }
    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();
        base.Update(gameTime);
    }
    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);
        spriteBatch.Begin();
        spriteBatch.Draw(back, backRec, Color.White);

            homer.Animate();
            spriteBatch.Draw(homer.Pic, homer.Rec, homer.SourceRec, Color.White);

        spriteBatch.End();
        base.Draw(gameTime);
    }
}

    public class Homer
{
        //Data Members
        private Texture2D pic;
        private Rectangle rec;
        private Rectangle sourceRec;
        private int counter;
        private SoundEffect talk;
        //Member Methods
        //Constructors
        public Homer()
        {
            rec = new Rectangle(600, 700, 100, 100);
            sourceRec = new Rectangle(0, 0, 100, 100);
            counter = 0;
        }
        
        public Homer(Texture2D p, SoundEffect s)
        {
            pic = p;
            rec = new Rectangle(600, 700, 100, 100);
            sourceRec = new Rectangle(0, 0, 100, 100);
            counter = 0;
            talk = s;
        }
        //Encapsulators
        public Texture2D Pic
        {
            set { pic = value; }
            get { return pic; }
        }
        public Rectangle Rec
        {
            set { rec = value; }
            get { return rec; }
        }
        public Rectangle SourceRec
        {
            //READ ONLY
            get { return sourceRec; }
        }
        public SoundEffect TalkProp
        {
            //READ ONLY
            get { return talk; }
        }
        //Calculation/Behaviors     
        public void Animate()
        {
            if (counter % 30 == 0)
        {
            // TERNARY OPERATOR
            sourceRec.X = sourceRec.X == 400 ? 0 : sourceRec.X = -sourceRec.X;
        }
        counter++;
        Walk();
        Talk();
    }
    private void Walk()
        {
            rec.X += 5;
            // TERNARY OPERATORS
            rec.X = rec.Right > 1100 ? rec.X = 0 : rec.X;
        }
        private void Talk()
        {
            if(counter % 30 == 0)
            {
                //talk.Play();
            }
        }
    }
}
