using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Net;
using Microsoft.Xna.Framework.Storage;

namespace MortalCona1
{

    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        //------------portada--------------
        Texture2D fondo, insert1, insert2;
        Vector2 pfondo, pinsert1, pinsert2;
        int tiempo;
        int coin = 1;
        //------------menu----------------
        Texture2D fondomenu, btnjugar1, btnjugar2, btncomojugar1, btncomojugar2, btncreditos1, btncreditos2, btnsalir1, btnsalir2;
        Vector2 pfondomenu, pbtnjugar1, pbtncomojugar1, pbtncreditos1, pbtnsalir1;
        Vector2 pbtnjugar2, pbtncomojugar2, pbtncreditos2, pbtnsalir2;
        BoundingBox bbtnjugar, bbtncomojugar, bbtncreditos, bbtnsalir, bratoncito;
        MouseState raton;
        Vector2 pratoncito;
        Texture2D ratoncito;
        int showbtnjugar2 = 0;
        int showbtncomojugar2 = 0;
        int showbtncreditos2 = 0;
        int showbtnsalir2 = 0;
        //-------------------escenarios-------------
        Texture2D fondoescenarios, fondoescen1, fondoescen2;
        Vector2 pfondoescenarios, pfondoescen1, pfondoescen2;
        BoundingBox bescen1, bescen2;
        //---------------------escenario1---------
        Texture2D fondoescenario1, fondoimg1, fondoimg2, fondoimg3, fondoimg4, fondoimg5, fondoimg6;
        Vector2 pfondoescenario1, panimamalona;
        int animamamalona = 0;
        bool loading1 = false;
        //escenario2
        Texture2D fondoescenario2;
        Vector2 pfondoescenario2;
        //----------------------player1--------------
        Texture2D imgparado1, imgwalking1, imgwalking2, imgwalking3, imgpunching1, imgkick1, imgkick2, imgkick3, imgdefense, imgabajo;
        Vector2 pPlayer1;
        int animacionP1walking = 1;
        int animacionP1backing = 1;
        int animacionP1punching = 1;
        int animacionP1kicking = 1;
        bool P1walking = false;
        bool P1parado = false;
        bool P1backing = false;
        bool P1punching = false;
        bool P1kicking = false;
        bool P1defense = false;
        bool P1abajo = false;
        bool P1Jumping = false;
        bool PlayerActivated = false;
        //salto de player 1
        bool cae1 = false;
        float masa1;
        float tiemposuelto1;
        float timeup1;
        Texture2D imgJumping1, imgJumping2, imgJumping3, imgJumping4;
        Vector2 posInicial1;
        //-----------------------------player2------------------
        Texture2D imgparado1P2, imgwalking1P2, imgwalking2P2, imgpuching1P2, imgkick1P2, imgkick2P2, imgdefense1P2, imgabajo1P2;
        Vector2 pPlayer2;
        int animacionP2walking = 1;
        int animacionP2backing = 1;
        int animacionP2punching = 1;
        int animacionP2kicking = 1;
        bool P2walking = false;
        bool P2parado = false;
        bool P2backing = false;
        bool P2punching = false;
        bool P2kicking = false;
        bool P2defense = false;
        bool P2abajo = false;
        bool P2Jumping = false;
        bool PlayerActivated2 = false;
        //salto de player 2
        bool cae2 = false;
        float masa2;
        float tiemposuelto2;
        float timeup2;
        Texture2D imgJumping1P2;
        Vector2 posInicial2;
        //--------------------creditos
        Texture2D fondocreditos;
        Vector2 pfondocreditos, pbtnsalir3;
        BoundingBox bbtnsalir2;
        int showbtnsalir3 = 0;
        //-------------------como jugar---------------
        Texture2D fondocomojugar;
        Vector2 pfondocomojugar;
        //-------------banderas opciones menu etc
        bool portada = true;
        bool menu = false;
        bool escenarios = false;
        bool showraton = false;
        bool creditos = false;
        bool escenario1 = false;
        bool escenario2 = false;
        bool comojugar = false;
        int presionar = 0;
        //variables imagenes de vida, vida, daños, golpes
        Texture2D imgvida100P1,imgvida80P1,imgvida60P1,imgvida40P1,imgvida20P1,imgvida10P1;
        Texture2D imgvida100P2, imgvida80P2, imgvida60P2, imgvida40P2, imgvida20P2, imgvida10P2;
        Vector2 PimgvidaP1,PimgvidaP2;
        BoundingBox Bplayer1, Bplayer2;
        //patada - 10
        //puño - 5
        //cubriendose -3
        int VidaPlayer1 = 100;
        int VidaPlayer2 = 100;
        int golpe1 = 0;
        int patada1 = 0;
        int golpe2 = 0;
        int patada2 = 0;
        //variables inversion de imagenes x1 > x2
        Texture2D Eimgparado1, Eimgwalking1, Eimgwalking2, Eimgwalking3, Eimgpunching1, Eimgkick1, Eimgkick2, Eimgkick3, Eimgdefense, Eimgabajo,EimgJumping4;
        Texture2D Eimgparado1P2, Eimgwalking1P2, Eimgwalking2P2, Eimgpuching1P2, Eimgkick1P2, Eimgkick2P2, Eimgdefense1P2, Eimgabajo1P2, EimgJumping1P2;
        //variables fondos wins
        Texture2D fondoPlayer1wins, fondoPlayer2wins;
        Vector2 pfondoPlayer1wins, pfondoPlayer2wins;
        bool volverjugar = false;
        //variable espejo
        int espejo = 0;
        //-----------------------------------------------------------------------sonidos--------------------------------
        //musica
        AudioEngine engine;
        SoundBank soundBank;
        WaveBank waveBank;
        Cue control1,control2,control3;
        //**************************************************************Gametime**************************
        int tiemposucki = 60;
        Vector2 ptiemposucki;
        string Stiemposucki;
        SpriteFont fuente;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            if (portada == true)
            {
                fondo = Content.Load<Texture2D>("imgfondos/fondoportada");
                insert1 = Content.Load<Texture2D>("imgfondos/insertcoin1");
                insert2 = Content.Load<Texture2D>("imgfondos/insertcoin2");
                pfondo = new Vector2(0, 0);
                pinsert1 = new Vector2(355, 500);
                pinsert2 = new Vector2(350, 500);
            }
            //variables menu--------------------------
            fondomenu = Content.Load<Texture2D>("imgfondos/fondomenu");
            fondoimg1 = Content.Load<Texture2D>("imgfondos/imgloading1");
            fondoimg2 = Content.Load<Texture2D>("imgfondos/imgloading2");
            fondoimg3 = Content.Load<Texture2D>("imgfondos/imgloading3");
            fondoimg4 = Content.Load<Texture2D>("imgfondos/imgloading4");
            fondoimg5 = Content.Load<Texture2D>("imgfondos/imgloading5");
            fondoimg6 = Content.Load<Texture2D>("imgfondos/imgloading6");
            btnjugar1 = Content.Load<Texture2D>("imgfondos/jugar1");
            btnjugar2 = Content.Load<Texture2D>("imgfondos/jugar2");
            btncomojugar1 = Content.Load<Texture2D>("imgfondos/comojugar1");
            btncomojugar2 = Content.Load<Texture2D>("imgfondos/comojugar2");
            btncreditos1 = Content.Load<Texture2D>("imgfondos/creditos1");
            btncreditos2 = Content.Load<Texture2D>("imgfondos/creditos2");
            btnsalir1 = Content.Load<Texture2D>("imgfondos/salir1");
            btnsalir2 = Content.Load<Texture2D>("imgfondos/salir2");
            ratoncito = Content.Load<Texture2D>("imgfondos/imagenmouse");
            fondoescenarios = Content.Load<Texture2D>("imgfondos/fondoescenarios");
            fondocreditos = Content.Load<Texture2D>("imgfondos/fondocreditos");
            fondoescen1 = Content.Load<Texture2D>("imgfondos/escen1");
            fondoescenario1 = Content.Load<Texture2D>("imgfondos/escenariograffiti1");
            fondoescen2 = Content.Load<Texture2D>("imgfondos/escen2");
            fondoescenario2 = Content.Load<Texture2D>("imgfondos/escenario2");
            fondocomojugar = Content.Load<Texture2D>("imgfondos/comojuga");
            //--------------------imagenes player 1
            imgparado1 = Content.Load<Texture2D>("imgPlayer1/picS1");
            imgwalking1 = Content.Load<Texture2D>("imgPlayer1/picW1");
            imgwalking2 = Content.Load<Texture2D>("imgPlayer1/picW2");
            imgwalking3 = Content.Load<Texture2D>("imgPlayer1/picW3");
            imgpunching1 = Content.Load<Texture2D>("imgPlayer1/picP1");
            imgkick1 = Content.Load<Texture2D>("imgPlayer1/picK1");
            imgkick2 = Content.Load<Texture2D>("imgPlayer1/picK2");
            imgkick3 = Content.Load<Texture2D>("imgPlayer1/picK3");
            imgdefense = Content.Load<Texture2D>("imgPlayer1/picD1");
            imgabajo = Content.Load<Texture2D>("imgPlayer1/picAbajo1");
            imgJumping1 = Content.Load<Texture2D>("imgPlayer1/picJ1");
            imgJumping2 = Content.Load<Texture2D>("imgPlayer1/picJ2");
            imgJumping3 = Content.Load<Texture2D>("imgPlayer1/picJ3");
            imgJumping4 = Content.Load<Texture2D>("imgPlayer1/picJ4");
            imgvida100P1 = Content.Load<Texture2D>("imgPlayer1/imgvida100");
            imgvida80P1 = Content.Load<Texture2D>("imgPlayer1/imgvida80"); 
            imgvida60P1 = Content.Load<Texture2D>("imgPlayer1/imgvida60"); 
            imgvida40P1 = Content.Load<Texture2D>("imgPlayer1/imgvida40");
            imgvida20P1 = Content.Load<Texture2D>("imgPlayer1/imgvida20");
            imgvida10P1 = Content.Load<Texture2D>("imgPlayer1/imgvida10");
            //-----------------------------imagen player 1 espejo----------
            Eimgparado1 = Content.Load<Texture2D>("imgPlayer11/picS1");
            Eimgwalking1 = Content.Load<Texture2D>("imgPlayer11/picW1");
            Eimgwalking3 = Content.Load<Texture2D>("imgPlayer11/picW3");
            Eimgpunching1 = Content.Load<Texture2D>("imgPlayer11/picP1");
            Eimgkick3 = Content.Load<Texture2D>("imgPlayer11/picK3");
            Eimgdefense = Content.Load<Texture2D>("imgPlayer11/picD1");
            Eimgabajo = Content.Load<Texture2D>("imgPlayer11/picAbajo1");
            EimgJumping4 = Content.Load<Texture2D>("imgPlayer11/picJ4");
            //--------------------------------vectores jugadores
            pPlayer1 = new Vector2(50, 300);
            pPlayer2 = new Vector2(500,290);
            PimgvidaP1 = new Vector2(40,30);
            PimgvidaP2 = new Vector2(450, 30);
            //salto player 1
            posInicial1 = pPlayer1;
            masa1 = 15f;
            tiemposuelto1 = 0;
            timeup1 = 0.05f;
            //--------------------------------------imagen player 2
            imgparado1P2 = Content.Load<Texture2D>("imgPlayer2/parado1");
            imgwalking1P2 = Content.Load<Texture2D>("imgPlayer2/walking1");
            imgwalking2P2 = Content.Load<Texture2D>("imgPlayer2/walking2");
            imgpuching1P2 = Content.Load<Texture2D>("imgPlayer2/puching1");
            imgkick1P2 = Content.Load<Texture2D>("imgPlayer2/kicking1");
            imgkick2P2 = Content.Load<Texture2D>("imgPlayer2/kicking2");
            imgdefense1P2 = Content.Load<Texture2D>("imgPlayer2/defense");
            imgabajo1P2 = Content.Load<Texture2D>("imgPlayer2/abajo");
            imgJumping1P2 = Content.Load<Texture2D>("imgPlayer2/jumping");
            imgvida100P2 = Content.Load<Texture2D>("imgPlayer2/img2vida100");
            imgvida80P2 = Content.Load<Texture2D>("imgPlayer2/img2vida80");
            imgvida60P2 = Content.Load<Texture2D>("imgPlayer2/img2vida60");
            imgvida40P2 = Content.Load<Texture2D>("imgPlayer2/img2vida40");
            imgvida20P2 = Content.Load<Texture2D>("imgPlayer2/img2vida20");
            imgvida10P2 = Content.Load<Texture2D>("imgPlayer2/img2vida10");
            //---------------------------imagen player 2 espejo
            Eimgparado1P2 = Content.Load<Texture2D>("imgPlayer22/parado1");
            Eimgwalking1P2 = Content.Load<Texture2D>("imgPlayer22/walking1");
            Eimgwalking2P2 = Content.Load<Texture2D>("imgPlayer22/walking2");
            Eimgpuching1P2 = Content.Load<Texture2D>("imgPlayer22/puching1");
            Eimgkick1P2 = Content.Load<Texture2D>("imgPlayer22/kicking1");
            Eimgkick2P2 = Content.Load<Texture2D>("imgPlayer22/kicking2");
            Eimgdefense1P2 = Content.Load<Texture2D>("imgPlayer22/defense");
            Eimgabajo1P2 = Content.Load<Texture2D>("imgPlayer22/abajo");
            EimgJumping1P2 = Content.Load<Texture2D>("imgPlayer22/jumping");
            //------------------------salto player 2
            posInicial2 = pPlayer2;
            masa2 = 15f;
            tiemposuelto2 = 0;
            timeup2 = 0.05f;
            //demas variables
            pfondomenu = new Vector2(0, 0);
            panimamalona = new Vector2(0, 0);
            pfondocreditos = new Vector2(0, 0);
            pfondoescenarios = new Vector2(0, 0);
            pbtnjugar1 = new Vector2(325, 120);
            pbtnjugar2 = new Vector2(320, 120);
            pbtncomojugar1 = new Vector2(325, 210);
            pbtncomojugar2 = new Vector2(320, 210);
            pbtncreditos1 = new Vector2(325, 290);
            pbtncreditos2 = new Vector2(320, 290);
            pbtnsalir1 = new Vector2(325, 370);
            pbtnsalir2 = new Vector2(320, 370);
            pbtnsalir3 = new Vector2();
            pratoncito = new Vector2(50, 350);
            pfondoescen1 = new Vector2(150, 200);
            pfondoescen2 = new Vector2(400, 200);
            pfondoescenario1 = new Vector2(0, 0);
            pfondoescenario2 = new Vector2(0,0);
            pfondocomojugar = new Vector2(0,0);
            //------------------
            fondoPlayer1wins = Content.Load<Texture2D>("imgfondos/fondop1wins");
            fondoPlayer2wins = Content.Load<Texture2D>("imgfondos/fondop2wins");
            pfondoPlayer1wins = new Vector2(0,0);
            pfondoPlayer2wins = new Vector2(0,0);
            //
            bbtnjugar = new BoundingBox(new Vector3(pbtnjugar2.X, pbtnjugar2.Y, 0),
                new Vector3(pbtnjugar2.X + btnjugar2.Width, pbtnjugar2.Y + btnjugar2.Height, 0));
            bbtncomojugar = new BoundingBox(new Vector3(pbtncomojugar2.X, pbtncomojugar2.Y, 0),
                new Vector3(pbtncomojugar2.X + btncomojugar2.Width, pbtncomojugar2.Y + btncomojugar2.Height, 0));
            bbtncreditos = new BoundingBox(new Vector3(pbtncreditos2.X, pbtncreditos2.Y, 0),
                new Vector3(pbtncreditos2.X + btncreditos2.Width, pbtncreditos2.Y + btncreditos2.Height, 0));
            bbtnsalir = new BoundingBox(new Vector3(pbtnsalir2.X, pbtnsalir2.Y, 0),
                new Vector3(pbtnsalir2.X + btnsalir2.Width, pbtnsalir2.Y + btnsalir2.Height, 0));
            bratoncito = new BoundingBox(new Vector3(pratoncito.X, pratoncito.Y, 0),
                new Vector3(pratoncito.X + ratoncito.Width, pratoncito.Y + ratoncito.Height, 0));
            bbtnsalir2 = new BoundingBox(new Vector3(pbtnsalir3.X, pbtnsalir3.Y, 0),
                  new Vector3(pbtnsalir3.X + btnsalir2.Width, pbtnsalir3.Y + btnsalir2.Height, 0));
            bescen1 = new BoundingBox(new Vector3(pfondoescen1.X, pfondoescen1.Y, 0),
                new Vector3(pfondoescen1.X + fondoescen1.Width, pfondoescen1.Y + fondoescen1.Height, 0));
            bescen2 = new BoundingBox(new Vector3(pfondoescen2.X, pfondoescen2.Y, 0),
               new Vector3(pfondoescen2.X + fondoescen2.Width, pfondoescen2.Y + fondoescen2.Height, 0));
            Bplayer1 = new BoundingBox(new Vector3(pPlayer1.X ,pPlayer1.Y ,0),
                new Vector3(pPlayer1.X + imgparado1.Width ,pPlayer1.Y + imgparado1.Height,0));
            Bplayer2 = new BoundingBox(new Vector3(pPlayer2.X, pPlayer2.Y ,0),
                new Vector3(pPlayer2.X + imgparado1P2.Width,pPlayer2.Y + imgparado1P2.Height,0));
            //--------------------------------------------------------------
            engine = new AudioEngine("Content\\Sound\\sonidos.xgs");
            soundBank = new SoundBank(engine, "Content\\Sound\\Sound Bank.xsb");
            waveBank = new WaveBank(engine, "Content\\Sound\\Wave Bank.xwb");
            control1 = soundBank.GetCue("slayersong");
            control1.Play();
            control2 = soundBank.GetCue("songescenario1");
            control2.Stop(AudioStopOptions.AsAuthored);
            control3 = soundBank.GetCue("songescenario2");
            control3.Stop(AudioStopOptions.AsAuthored);
            //*****************
            ptiemposucki = new Vector2(400,30);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            fuente = Content.Load<SpriteFont>("SpriteFont1");
        }

        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                this.Exit();
            }
            //********************************************************************************
            
            
            //-------mouse
            if (showraton == true)
            {
                raton = Mouse.GetState();
                pratoncito = new Vector2(raton.X, raton.Y);
                if (raton.LeftButton == ButtonState.Pressed)
                {
                    presionar = 1;
                }
                else
                {
                    presionar = 0;
                }
            }
            //-----portada
            if (portada == true)
            {
                if (Keyboard.GetState().IsKeyDown(Keys.Enter))
                {
                    menu = true;
                    portada = false;
                    showraton = true;
                }
                tiempo = gameTime.TotalGameTime.Milliseconds;
                if (tiempo % 300 == 0)
                {
                    coin++;
                }
                if (coin == 4)
                {
                    coin = 1;
                }
            }
            //----------menu------------
            if (menu == true)
            {
                tiemposucki = 60;
                escenarios = false;
                creditos = false;
                bbtnjugar = new BoundingBox(new Vector3(pbtnjugar2.X, pbtnjugar2.Y, 0),
                    new Vector3(pbtnjugar2.X + btnjugar2.Width, pbtnjugar2.Y + btnjugar2.Height, 0));
                bbtncomojugar = new BoundingBox(new Vector3(pbtncomojugar2.X, pbtncomojugar2.Y, 0),
                    new Vector3(pbtncomojugar2.X + btncomojugar2.Width, pbtncomojugar2.Y + btncomojugar2.Height, 0));
                bbtncreditos = new BoundingBox(new Vector3(pbtncreditos2.X, pbtncreditos2.Y, 0),
                    new Vector3(pbtncreditos2.X + btncreditos2.Width, pbtncreditos2.Y + btncreditos2.Height, 0));
                bbtnsalir = new BoundingBox(new Vector3(pbtnsalir2.X, pbtnsalir2.Y, 0),
                    new Vector3(pbtnsalir2.X + btnsalir2.Width, pbtnsalir2.Y + btnsalir2.Height, 0));
                bratoncito = new BoundingBox(new Vector3(pratoncito.X, pratoncito.Y, 0),
                    new Vector3(pratoncito.X + ratoncito.Width, pratoncito.Y + ratoncito.Height, 0));

                ///////jugar
                if (bbtnjugar.Intersects(bratoncito))
                {
                    showbtnjugar2 = 1;
                }
                else
                {
                    showbtnjugar2 = 0;
                }
                if (bbtnjugar.Intersects(bratoncito) && presionar == 1)
                {
                    menu = false;
                    escenarios = true;
                    creditos = false;
                    comojugar = false;
                }
                ////////como jugar
                if (bratoncito.Intersects(bbtncomojugar))
                {
                    showbtncomojugar2 = 1;
                }
                else
                {
                    showbtncomojugar2 = 0;
                }
                if (bbtncomojugar.Intersects(bratoncito) && presionar == 1)
                {
                    menu = false;
                    creditos = false;
                    escenarios = false;
                    comojugar = true;
                }
                /////////////creditos
                if (bratoncito.Intersects(bbtncreditos))
                {
                    showbtncreditos2 = 1;
                }
                else
                {
                    showbtncreditos2 = 0;
                }
                if (bratoncito.Intersects(bbtncreditos) && presionar == 1)
                {
                    menu = false;
                    escenarios = false;
                    creditos = true;
                    comojugar = false;
                }
                ///////////salir
                if (bratoncito.Intersects(bbtnsalir))
                {
                    showbtnsalir2 = 1;
                }
                else
                {
                    showbtnsalir2 = 0;
                }
                if (bratoncito.Intersects(bbtnsalir) && presionar == 1)
                {
                    this.Exit();
                }

            }
            //-----------------------------------------escenarios opcion menu
            if (escenarios == true)
            {
                menu = false;
                creditos = false;
                comojugar = false;
                portada = false;
                pPlayer1 = new Vector2(50, 300);
                pPlayer2 = new Vector2(500, 300);
                animamamalona = 0;
                pbtnsalir3 = new Vector2(650, 500);
                bratoncito = new BoundingBox(new Vector3(pratoncito.X, pratoncito.Y, 0),
                    new Vector3(pratoncito.X + ratoncito.Width, pratoncito.Y + ratoncito.Height, 0));
                bescen1 = new BoundingBox(new Vector3(pfondoescen1.X, pfondoescen1.Y, 0),
                    new Vector3(pfondoescen1.X + fondoescen1.Width, pfondoescen1.Y + fondoescen1.Height, 0));
                bbtnsalir = new BoundingBox(new Vector3(pbtnsalir3.X, pbtnsalir3.Y, 0),
                    new Vector3(pbtnsalir3.X + btnsalir2.Width, pbtnsalir3.Y + btnsalir2.Height, 0));
                bescen2 = new BoundingBox(new Vector3(pfondoescen2.X, pfondoescen2.Y, 0),
                    new Vector3(pfondoescen2.X + fondoescen2.Width, pfondoescen2.Y + fondoescen2.Height, 0));

                if (bratoncito.Intersects(bbtnsalir))
                {
                    showbtnsalir3 = 1;
                }
                else
                {
                    showbtnsalir3 = 0;
                }
                if (bratoncito.Intersects(bbtnsalir) && presionar == 1)
                {
                    menu = true;
                }
                if (bratoncito.Intersects(bescen1) && presionar == 1)
                {
                    escenario1 = true;
                }
                if (bratoncito.Intersects(bescen2) && presionar == 1)
                {
                    escenario2 = true;
                }
            }
            //////////escenario 1 el de la calle xD
            if (escenario1 == true)
            {
                if (control1.IsPlaying)
                {
                    control1.Stop(AudioStopOptions.AsAuthored);
                }
                
                menu = false;
                escenarios = false;
                creditos = false;
                portada = false;
                loading1 = true;
                tiempo = gameTime.TotalGameTime.Milliseconds;
                if (animamamalona >= 0 && animamamalona < 13)
                {
                    if (tiempo % 200 == 0)
                    {
                        animamamalona++;
                    }

                }
                if (animamamalona == 13)
                {
                    loading1 = false;
                }
                //-------------------codigo movimientos y animaciones por secciones player 1 inicia 
                //just here!
                //lets start it
                //adventure begins
                //night is long
                //do not sleep since today
                //--------------------------------------------------------------------------------------//
                //----------------------espejo----------------------------
                 if (pPlayer1.X < pPlayer2.X)
                {
                    espejo = 1;
                }
                if (espejo == 1)
                {
                    Bplayer1 = new BoundingBox(new Vector3(pPlayer1.X, pPlayer1.Y, 0),
                    new Vector3(pPlayer1.X + imgparado1.Width, pPlayer1.Y + imgparado1.Height, 0));
                    Bplayer2 = new BoundingBox(new Vector3(pPlayer2.X +60, pPlayer2.Y, 0),
                    new Vector3(pPlayer2.X + imgparado1P2.Width , pPlayer2.Y + imgparado1P2.Height, 0));
                }
                if (pPlayer1.X > pPlayer2.X)
                {
                    espejo = 2;
                }
                if (espejo == 2)
                {
                    Bplayer1 = new BoundingBox(new Vector3(pPlayer1.X +60, pPlayer1.Y, 0),
                    new Vector3(pPlayer1.X + Eimgparado1.Width, pPlayer1.Y + Eimgparado1.Height, 0));
                    Bplayer2 = new BoundingBox(new Vector3(pPlayer2.X, pPlayer2.Y, 0),
                    new Vector3(pPlayer2.X + Eimgparado1P2.Width, pPlayer2.Y + Eimgparado1P2.Height, 0));
                }
                if (espejo == 2 && pPlayer1.X + Eimgparado1.Width > 795)
                {
                    pPlayer1.X -= 5;
                    P1walking = false;
                    P1parado = true;
                }
                //-------------------------------------------------------
                if (loading1 == true)
                {
                    PlayerActivated = false;
                }
                if (loading1 == false)
                {
                    PlayerActivated = true;
                    if (tiempo % 1000 == 0)
                    {
                        tiemposucki--;
                    }
                    if (control2.IsStopped)
                {
                    control2 = soundBank.GetCue("songescenario1");
                    control2.Play();
                }
                }
                if (PlayerActivated == true)
                {
                    P1walking = false;
                    P1backing = false;
                    P1punching = false;
                    P1kicking = false;
                    P1defense = false;
                    P1abajo = false;
                    if (pPlayer1.Y >= 300)
                    {
                        P1Jumping = false;
                        P1parado = true;
                    }
                    if (pPlayer1.Y < 300)
                    {
                        P1walking = false;
                        P1backing = false;
                        P1punching = false;
                        P1kicking = false;
                        P1defense = false;
                        P1abajo = false;
                        P1Jumping = true;
                    }
                    if (Keyboard.GetState().IsKeyDown(Keys.D))
                    {
                        if (P1Jumping == false && pPlayer1.Y >= 300)
                        {
                            P1walking = true;
                            P1parado = false;
                        }
                    }
                    if (Keyboard.GetState().IsKeyDown(Keys.A))
                    {
                        if (P1Jumping == false && pPlayer1.Y >= 300)
                        {
                            P1backing = true;
                            P1parado = false;
                        }
                    }
                    if (Keyboard.GetState().IsKeyDown(Keys.A) && Keyboard.GetState().IsKeyDown(Keys.D))
                    {
                        P1walking = true;
                        P1backing = false;
                    }
                    if (Keyboard.GetState().IsKeyDown(Keys.E))
                    {
                        P1parado = false;
                        P1walking = false;
                        P1backing = false;
                        P1punching = true;
                        Bplayer1 = new BoundingBox(new Vector3(pPlayer1.X, pPlayer1.Y, 0),
                        new Vector3(pPlayer1.X + imgpunching1.Width, pPlayer1.Y + imgpunching1.Height, 0));
                        golpe1++;
                        if (tiempo % 20 == 0)
                        {
                            animacionP1punching++;
                        }
                    }
                    
                    if (Keyboard.GetState().IsKeyUp(Keys.E))
                    {
                        animacionP1punching = 1;
                        golpe1 = 0;
                    }
                    if (Keyboard.GetState().IsKeyDown(Keys.R))
                    {
                        Bplayer1 = new BoundingBox(new Vector3(pPlayer1.X, pPlayer1.Y, 0),
                        new Vector3(pPlayer1.X + imgkick3.Width, pPlayer1.Y + imgkick3.Height, 0));
                        P1parado = false;
                        P1walking = false;
                        P1backing = false;
                        P1punching = false;
                        P1kicking = true;
                        patada1++;
                        if (tiempo % 20 == 0)
                        {
                            animacionP1kicking++;
                        }
                    }
                    if (Keyboard.GetState().IsKeyUp(Keys.R))
                    {
                        animacionP1kicking = 1;
                        patada1 = 0;
                    }
                    if (Keyboard.GetState().IsKeyDown(Keys.F))
                    {
                        P1parado = false;
                        P1walking = false;
                        P1backing = false;
                        P1punching = false;
                        P1kicking = false;
                        P1defense = true;
                    }
                    if (Keyboard.GetState().IsKeyDown(Keys.S))
                    {
                        P1abajo = true;
                        P1parado = false;
                        P1walking = false;
                        P1backing = false;
                        P1punching = false;
                        P1kicking = false;
                        P1defense = false;
                    }
                    if (Keyboard.GetState().IsKeyDown(Keys.W))
                    {
                        P1Jumping = true;
                        P1abajo = false;
                        P1parado = false;
                        P1walking = false;
                        P1backing = false;
                        P1punching = false;
                        P1kicking = false;
                        P1defense = false;
                        pPlayer1.Y -= 10;
                    }
                    if (Keyboard.GetState().IsKeyDown(Keys.W) && Keyboard.GetState().IsKeyDown(Keys.D))
                    {
                        pPlayer1.Y -= 10;
                        pPlayer1.X += 5;
                        P1Jumping = true;
                    }
                    if (Keyboard.GetState().IsKeyDown(Keys.W) && Keyboard.GetState().IsKeyDown(Keys.A))
                    {
                        pPlayer1.Y -= 10;
                        pPlayer1.X -= 5;
                        P1Jumping = true;
                    }
                    if (Keyboard.GetState().IsKeyDown(Keys.W) && Keyboard.GetState().IsKeyDown(Keys.A) &&
                        Keyboard.GetState().IsKeyDown(Keys.D))
                    {
                        P1Jumping = true;
                        pPlayer1.X += 5;
                    }

                    //salto
                    if (P1Jumping == true)
                    {
                        P1abajo = false;
                        P1parado = false;
                        P1walking = false;
                        P1backing = false;
                        P1punching = false;
                        P1kicking = false;
                        P1defense = false;
                        if (pPlayer1.Y < 300)
                        {
                            cae1 = true;
                        }
                        else
                        {
                            cae1 = false;
                            posInicial1 = pPlayer1;
                            masa1 = 15f;
                            tiemposuelto1 = 0;
                            timeup1 = 0.05f;
                        } if (cae1 == true)
                        {
                            tiemposuelto1 += timeup1;
                            pPlayer1.Y = pPlayer1.Y + (masa1 * tiemposuelto1);
                        }
                    }

                    if (P1backing == true)
                    {
                        pPlayer1.X -= 5;
                        if (tiempo % 40 == 0)
                        {
                            animacionP1backing++;
                        }
                        if (animacionP1backing == 3)
                        {
                            animacionP1backing = 1;
                        }
                    }

                    if (P1walking == true)
                    {
                        pPlayer1.X += 5;
                        if (tiempo % 40 == 0)
                        {
                            animacionP1walking++;
                        }
                        if (animacionP1walking == 3)
                        {
                            animacionP1walking = 1;
                        }
                    }

                    if (pPlayer1.X <= 2)
                    {
                        pPlayer1.X += 5;
                        P1backing = false;
                        P1parado = true;
                        if (Keyboard.GetState().IsKeyDown(Keys.W))
                        {
                            P1parado = false;
                        }
                    }
                    if (pPlayer1.X + imgparado1.Width >= 795)
                    {
                        pPlayer1.X -= 5;
                        P1backing = false;
                        P1parado = true;
                        P1walking = false;
                        if (Keyboard.GetState().IsKeyDown(Keys.W))
                        {
                            P1parado = false;
                        }
                    }

                }
                //codigo para player 2--------------------------------
                //codigo para player 2-------------------------------- 
                //i do sleep 12 hours everyday

                if (loading1 == true)
                {
                    PlayerActivated2 = false;
                }
                if (loading1 == false)
                {
                    PlayerActivated2 = true;
                }
                if (PlayerActivated2 == true)
                {
                    P2walking = false;
                    P2backing = false;
                    P2punching = false;
                    P2kicking = false;
                    P2defense = false;
                    P2abajo = false;
                    if (pPlayer2.Y >= 300)
                    {
                        P2Jumping = false;
                        P2parado = true;
                    }
                    if (pPlayer2.Y < 300)
                    {
                        P2walking = false;
                        P2backing = false;
                        P2punching = false;
                        P2kicking = false;
                        P2defense = false;
                        P2abajo = false;
                        P2Jumping = true;
                    }
                    if (Keyboard.GetState().IsKeyDown(Keys.Right))
                    {
                        if (P2Jumping == false && pPlayer2.Y >= 300)
                        {
                            P2walking = true;
                            P2parado = false;
                        }
                    }
                    if (Keyboard.GetState().IsKeyDown(Keys.Left))
                    {
                        if (P2Jumping == false && pPlayer2.Y >= 300)
                        {
                            P2backing = true;
                            P2parado = false;
                        }
                    }
                    if (Keyboard.GetState().IsKeyDown(Keys.Left) && Keyboard.GetState().IsKeyDown(Keys.Right))
                    {
                        P2walking = true;
                        P2backing = false;
                    }
                    if (Keyboard.GetState().IsKeyDown(Keys.O))
                    {
                        Bplayer2 = new BoundingBox(new Vector3(pPlayer2.X, pPlayer2.Y, 0),
                        new Vector3(pPlayer2.X + imgpuching1P2.Width, pPlayer2.Y + imgpuching1P2.Height, 0));
                        P2parado = false;
                        P2walking = false;
                        P2backing = false;
                        P2punching = true;
                        golpe2++;
                        if (tiempo % 20 == 0)
                        {
                            animacionP2punching++;
                        }
                    }
                    if (Keyboard.GetState().IsKeyUp(Keys.O))
                    {
                        animacionP2punching = 1;
                        golpe2 = 0;
                    }
                    if (Keyboard.GetState().IsKeyDown(Keys.I))
                    {
                        Bplayer2 = new BoundingBox(new Vector3(pPlayer2.X, pPlayer2.Y, 0),
                        new Vector3(pPlayer2.X + imgkick2P2.Width, pPlayer2.Y + imgkick2P2.Height, 0));
                        P2parado = false;
                        P2walking = false;
                        P2backing = false;
                        P2punching = false;
                        P2kicking = true;
                        patada2++;
                        if (tiempo % 20 == 0)
                        {
                            animacionP2kicking++;
                        }
                    }
                    if (Keyboard.GetState().IsKeyUp(Keys.I))
                    {
                        animacionP2kicking = 1;
                        patada2 = 0;
                    }
                    if (Keyboard.GetState().IsKeyDown(Keys.P))
                    {
                        P2parado = false;
                        P2walking = false;
                        P2backing = false;
                        P2punching = false;
                        P2kicking = false;
                        P2defense = true;
                    }
                    if (Keyboard.GetState().IsKeyDown(Keys.Down))
                    {
                        P2abajo = true;
                        P2parado = false;
                        P2walking = false;
                        P2backing = false;
                        P2punching = false;
                        P2kicking = false;
                        P2defense = false;
                    }
                    if (Keyboard.GetState().IsKeyDown(Keys.Up))
                    {
                        P2Jumping = true;
                        P2abajo = false;
                        P2parado = false;
                        P2walking = false;
                        P2backing = false;
                        P2punching = false;
                        P2kicking = false;
                        P2defense = false;
                        pPlayer2.Y -= 10;
                    }
                    if (Keyboard.GetState().IsKeyDown(Keys.Up) && Keyboard.GetState().IsKeyDown(Keys.Right))
                    {
                        pPlayer2.Y -= 10;
                        pPlayer2.X += 5;
                        P2Jumping = true;
                    }
                    if (Keyboard.GetState().IsKeyDown(Keys.Up) && Keyboard.GetState().IsKeyDown(Keys.Left))
                    {
                        pPlayer2.Y -= 10;
                        pPlayer2.X -= 5;
                        P2Jumping = true;
                    }
                    if (Keyboard.GetState().IsKeyDown(Keys.Up) && Keyboard.GetState().IsKeyDown(Keys.Left) &&
                        Keyboard.GetState().IsKeyDown(Keys.Right))
                    {
                        P2Jumping = true;
                        pPlayer2.X += 5;
                    }

                    //salto
                    if (P2Jumping == true)
                    {
                        P2abajo = false;
                        P2parado = false;
                        P2walking = false;
                        P2backing = false;
                        P2punching = false;
                        P2kicking = false;
                        P2defense = false;
                        if (pPlayer2.Y < 300)
                        {
                            cae2 = true;
                        }
                        else
                        {
                            cae2 = false;
                            posInicial2 = pPlayer2;
                            masa2 = 15f;
                            tiemposuelto2 = 0;
                            timeup2 = 0.05f;
                        } if (cae2 == true)
                        {
                            tiemposuelto2 += timeup2;
                            pPlayer2.Y = pPlayer2.Y + (masa2 * tiemposuelto2);
                        }
                    }

                    if (P2backing == true)
                    {
                        pPlayer2.X -= 5;
                        if (tiempo % 40 == 0)
                        {
                            animacionP2backing++;
                        }
                        if (animacionP2backing == 3)
                        {
                            animacionP2backing = 1;
                        }
                    }

                    if (P2walking == true)
                    {
                        pPlayer2.X += 5;
                        if (tiempo % 40 == 0)
                        {
                            animacionP2walking++;
                        }
                        if (animacionP2walking == 3)
                        {
                            animacionP2walking = 1;
                        }
                    }

                    if (pPlayer2.X <= 2)
                    {
                        pPlayer2.X += 5;
                        P2backing = false;
                        P2parado = true;
                        if (Keyboard.GetState().IsKeyDown(Keys.Up))
                        {
                            P2parado = false;
                        }
                    }
                    if (pPlayer2.X + imgparado1P2.Width >= 795)
                    {
                        pPlayer2.X -= 5;
                        P2backing = false;
                        P2parado = true;
                        P2walking = false;
                        if (Keyboard.GetState().IsKeyDown(Keys.Up))
                        {
                            P2parado = false;
                        }
                    }
                }
                //------------------------------------codigo danio player 1 al player 2----------------------------
                if ((Bplayer1.Intersects(Bplayer2)) && (P1punching == true) && (golpe1 == 1) && (P2defense == false))
                { 
                    VidaPlayer2 = VidaPlayer2 - 5;
                    soundBank.PlayCue("dolor");
                    soundBank.PlayCue("golpe");
                }
                if ((Bplayer1.Intersects(Bplayer2)) && (P1punching == true) && (P2defense == true) && (golpe1 == 1))
                    {
                        VidaPlayer2 = VidaPlayer2 - 0;
                        soundBank.PlayCue("golpe");
                    }
                if ((Bplayer1.Intersects(Bplayer2)) && (P1kicking == true) && (patada1 == 1) && (P2defense == false))
                {
                    VidaPlayer2 = VidaPlayer2 - 10;
                    soundBank.PlayCue("dolor");
                    soundBank.PlayCue("golpe");
                    
                }
                if ((Bplayer2.Intersects(Bplayer2)) && (P1kicking == true) && (P2defense == true) && (patada1 == 1))
                    {
                        VidaPlayer2 = VidaPlayer2 - 0;
                        soundBank.PlayCue("golpe");
                    }
                //-----------------------------------codigo danio player 2 a player 1
                if ((Bplayer2.Intersects(Bplayer1)) && (P2punching == true) && (golpe2 == 1) && (P1defense == false))
                {
                    VidaPlayer1 = VidaPlayer1 - 5;
                    soundBank.PlayCue("dolor");
                    soundBank.PlayCue("golpe");
                }
                if ((Bplayer1.Intersects(Bplayer2)) && (P2punching == true) && (P1defense == true) && (golpe2==1))
                    {
                        VidaPlayer1 = VidaPlayer1 - 0;
                        soundBank.PlayCue("golpe");
                    }
                if ((Bplayer1.Intersects(Bplayer2)) && (P2kicking == true) && (patada2 == 1) && (P1defense==false))
                {
                    VidaPlayer1 = VidaPlayer1 - 10;
                    soundBank.PlayCue("dolor");
                    soundBank.PlayCue("golpe");
                }
                if ((Bplayer2.Intersects(Bplayer1)) && (P2kicking == true) && (P1defense == true) && (golpe2==1))
                    {
                        VidaPlayer1 = VidaPlayer1 - 0;
                        soundBank.PlayCue("golpe");
                    }
                    if (VidaPlayer1 < 0 || VidaPlayer2 < 0)
                    {
                        volverjugar = true;
                        PlayerActivated = false;
                        PlayerActivated = false;
                    }
                    if (tiemposucki <= 0 && VidaPlayer1 > VidaPlayer2)
                    {
                        volverjugar = true;

                        PlayerActivated = false;
                        PlayerActivated = false;
                    }
                    if (tiemposucki <= 0 && VidaPlayer1 < VidaPlayer2)
                    {
                        volverjugar = true;

                        PlayerActivated = false;
                        PlayerActivated = false;
                    }
                    if (volverjugar == true)
                    {
                        if (Keyboard.GetState().IsKeyDown(Keys.Space))
                        {
                            menu = true;
                            portada = false;
                            escenarios = false;
                            creditos = false;
                            escenario1 = false;
                            escenario2 = false;
                            volverjugar = false;
                            comojugar = false;
                            PlayerActivated = false;
                            PlayerActivated = false;
                            VidaPlayer1 = 100;
                            VidaPlayer2 = 100;
                            if (control2.IsPlaying)
                            {
                                control2.Stop(AudioStopOptions.AsAuthored);
                            }
                            if (control1.IsStopped)
                            {
                                control1 = soundBank.GetCue("slayersong");
                                control1.Play();
                            }
                        }
                    }
            }
            //-----------------------escenario2 endiablado-------------------
            if (escenario2 == true)
            {
                if (control1.IsPlaying)
                {
                    control1.Stop(AudioStopOptions.AsAuthored);
                }
                
                menu = false;
                escenarios = false;
                creditos = false;
                portada = false;
                loading1 = true;
                tiempo = gameTime.TotalGameTime.Milliseconds;
                if (animamamalona >= 0 && animamamalona < 13)
                {
                    if (tiempo % 200 == 0)
                    {
                        animamamalona++;
                    }

                }
                
                if (animamamalona == 13)
                {
                    loading1 = false;
                }

                //-------------------codigo movimientos y animaciones por secciones player 1 inicia 
                //just here!
                //lets start it
                //adventure begins
                //night is long
                //do not sleep since today
                //--------------------------------------------------------------------------------------//
                if (pPlayer1.X < pPlayer2.X)
                {
                    espejo = 1;
                }
                if (espejo == 1)
                {
                    Bplayer1 = new BoundingBox(new Vector3(pPlayer1.X +60, pPlayer1.Y, 0),
                    new Vector3(pPlayer1.X + imgparado1.Width, pPlayer1.Y + imgparado1.Height, 0));
                    Bplayer2 = new BoundingBox(new Vector3(pPlayer2.X , pPlayer2.Y, 0),
                    new Vector3(pPlayer2.X + imgparado1P2.Width, pPlayer2.Y + imgparado1P2.Height, 0));
                }
                if (pPlayer1.X > pPlayer2.X)
                {
                    espejo = 2;
                }
                if (espejo == 2)
                {
                    Bplayer1 = new BoundingBox(new Vector3(pPlayer1.X , pPlayer1.Y, 0),
                    new Vector3(pPlayer1.X + Eimgparado1.Width, pPlayer1.Y + Eimgparado1.Height, 0));
                    Bplayer2 = new BoundingBox(new Vector3(pPlayer2.X +60, pPlayer2.Y, 0),
                    new Vector3(pPlayer2.X + Eimgparado1P2.Width, pPlayer2.Y + Eimgparado1P2.Height, 0));
                }
                if (espejo == 2 && pPlayer1.X + Eimgparado1.Width > 795)
                {
                    pPlayer1.X -= 5;
                    P1walking = false;
                    P1parado = true;
                }
                ////////////////----------------------
                if (loading1 == true)
                {
                    PlayerActivated = false;
                    
                }
                if (loading1 == false)
                {
                    PlayerActivated = true;
                    if (tiempo % 1000 == 0)
                    {
                        tiemposucki--;
                    }
                    if (control3.IsStopped)
                    {
                    control3 = soundBank.GetCue("songescenario2");
                    control3.Play();
                    }
                }
                if (PlayerActivated == true)
                {
                    P1walking = false;
                    P1backing = false;
                    P1punching = false;
                    P1kicking = false;
                    P1defense = false;
                    P1abajo = false;
                    if (pPlayer1.Y >= 300)
                    {
                        P1Jumping = false;
                        P1parado = true;
                    }
                    if (pPlayer1.Y < 300)
                    {
                        P1walking = false;
                        P1backing = false;
                        P1punching = false;
                        P1kicking = false;
                        P1defense = false;
                        P1abajo = false;
                        P1Jumping = true;
                    }
                    if (Keyboard.GetState().IsKeyDown(Keys.D))
                    {
                        if (P1Jumping == false && pPlayer1.Y >= 300)
                        {
                            P1walking = true;
                            P1parado = false;
                        }
                    }
                    if (Keyboard.GetState().IsKeyDown(Keys.A))
                    {
                        if (P1Jumping == false && pPlayer1.Y >= 300)
                        {
                            P1backing = true;
                            P1parado = false;
                        }
                    }
                    if (Keyboard.GetState().IsKeyDown(Keys.A) && Keyboard.GetState().IsKeyDown(Keys.D))
                    {
                        P1walking = true;
                        P1backing = false;
                    }
                    if (Keyboard.GetState().IsKeyDown(Keys.E))
                    {
                        Bplayer1 = new BoundingBox(new Vector3(pPlayer1.X, pPlayer1.Y, 0),
                        new Vector3(pPlayer1.X + imgpunching1.Width, pPlayer1.Y + imgpunching1.Height, 0));
                        P1parado = false;
                        P1walking = false;
                        P1backing = false;
                        P1punching = true;
                        golpe1++;
                        if (tiempo % 20 == 0)
                        {
                            animacionP1punching++;
                        }
                    }
                    if (Keyboard.GetState().IsKeyUp(Keys.E))
                    {
                        animacionP1punching = 1;
                        golpe1 = 0;
                    }
                    if (Keyboard.GetState().IsKeyDown(Keys.R))
                    {
                        Bplayer1 = new BoundingBox(new Vector3(pPlayer1.X, pPlayer1.Y, 0),
                        new Vector3(pPlayer1.X + imgkick1.Width, pPlayer1.Y + imgkick1.Height, 0));
                        P1parado = false;
                        P1walking = false;
                        P1backing = false;
                        P1punching = false;
                        P1kicking = true;
                        patada1++;
                        if (tiempo % 20 == 0)
                        {
                            animacionP1kicking++;
                        }
                    }
                    if (Keyboard.GetState().IsKeyUp(Keys.R))
                    {
                        animacionP1kicking = 1;
                        patada1 = 0;
                    }
                    if (Keyboard.GetState().IsKeyDown(Keys.F))
                    {
                        P1parado = false;
                        P1walking = false;
                        P1backing = false;
                        P1punching = false;
                        P1kicking = false;
                        P1defense = true;
                    }
                    if (Keyboard.GetState().IsKeyDown(Keys.S))
                    {
                        P1abajo = true;
                        P1parado = false;
                        P1walking = false;
                        P1backing = false;
                        P1punching = false;
                        P1kicking = false;
                        P1defense = false;
                    }
                    if (Keyboard.GetState().IsKeyDown(Keys.W))
                    {
                        P1Jumping = true;
                        P1abajo = false;
                        P1parado = false;
                        P1walking = false;
                        P1backing = false;
                        P1punching = false;
                        P1kicking = false;
                        P1defense = false;
                        pPlayer1.Y -= 10;
                    }
                    if (Keyboard.GetState().IsKeyDown(Keys.W) && Keyboard.GetState().IsKeyDown(Keys.D))
                    {
                        pPlayer1.Y -= 10;
                        pPlayer1.X += 5;
                        P1Jumping = true;
                    }
                    if (Keyboard.GetState().IsKeyDown(Keys.W) && Keyboard.GetState().IsKeyDown(Keys.A))
                    {
                        pPlayer1.Y -= 10;
                        pPlayer1.X -= 5;
                        P1Jumping = true;
                    }
                    if (Keyboard.GetState().IsKeyDown(Keys.W) && Keyboard.GetState().IsKeyDown(Keys.A) &&
                        Keyboard.GetState().IsKeyDown(Keys.D))
                    {
                        P1Jumping = true;
                        pPlayer1.X += 5;
                    }


                    //salto
                    if (P1Jumping == true)
                    {
                        P1abajo = false;
                        P1parado = false;
                        P1walking = false;
                        P1backing = false;
                        P1punching = false;
                        P1kicking = false;
                        P1defense = false;
                        if (pPlayer1.Y < 300)
                        {
                            cae1 = true;
                        }
                        else
                        {
                            cae1 = false;
                            posInicial1 = pPlayer1;
                            masa1 = 15f;
                            tiemposuelto1 = 0;
                            timeup1 = 0.05f;
                        } if (cae1 == true)
                        {
                            tiemposuelto1 += timeup1;
                            pPlayer1.Y = pPlayer1.Y + (masa1 * tiemposuelto1);
                        }
                    }

                    if (P1backing == true)
                    {
                        pPlayer1.X -= 5;
                        if (tiempo % 40 == 0)
                        {
                            animacionP1backing++;
                        }
                        if (animacionP1backing == 3)
                        {
                            animacionP1backing = 1;
                        }
                    }

                    if (P1walking == true)
                    {
                        pPlayer1.X += 5;
                        if (tiempo % 40 == 0)
                        {
                            animacionP1walking++;
                        }
                        if (animacionP1walking == 3)
                        {
                            animacionP1walking = 1;
                        }
                    }

                    if (pPlayer1.X <= 2)
                    {
                        pPlayer1.X += 5;
                        P1backing = false;
                        P1parado = true;
                        if (Keyboard.GetState().IsKeyDown(Keys.W))
                        {
                            P1parado = false;
                        }
                    }
                    if (pPlayer1.X + imgparado1.Width >= 795)
                    {
                        pPlayer1.X -= 5;
                        P1backing = false;
                        P1parado = true;
                        P1walking = false;
                        if (Keyboard.GetState().IsKeyDown(Keys.W))
                        {
                            P1parado = false;
                        }
                    }

                }
                //codigo para player 2--------------------------------
                //codigo para player 2--------------------------------
                //i do sleep 12 hours everyday

                if (loading1 == true)
                {
                    PlayerActivated2 = false;
                }
                if (loading1 == false)
                {
                    PlayerActivated2 = true;
                }
                if (PlayerActivated2 == true)
                {
                    P2walking = false;
                    P2backing = false;
                    P2punching = false;
                    P2kicking = false;
                    P2defense = false;
                    P2abajo = false;
                    if (pPlayer2.Y >= 300)
                    {
                        P2Jumping = false;
                        P2parado = true;
                    }
                    if (pPlayer2.Y < 300)
                    {
                        P2walking = false;
                        P2backing = false;
                        P2punching = false;
                        P2kicking = false;
                        P2defense = false;
                        P2abajo = false;
                        P2Jumping = true;
                    }
                    if (Keyboard.GetState().IsKeyDown(Keys.Right))
                    {
                        if (P2Jumping == false && pPlayer2.Y >= 300)
                        {
                            P2walking = true;
                            P2parado = false;
                        }
                    }
                    if (Keyboard.GetState().IsKeyDown(Keys.Left))
                    {
                        if (P2Jumping == false && pPlayer1.Y >= 300)
                        {
                            P2backing = true;
                            P2parado = false;
                        }
                    }
                    if (Keyboard.GetState().IsKeyDown(Keys.Left) && Keyboard.GetState().IsKeyDown(Keys.Right))
                    {
                        P2walking = true;
                        P2backing = false;
                    }
                    if (Keyboard.GetState().IsKeyDown(Keys.O))
                    {
                        P2parado = false;
                        P2walking = false;
                        P2backing = false;
                        P2punching = true;
                        golpe2++;
                        if (tiempo % 20 == 0)
                        {
                            animacionP2punching++;
                        }
                    }
                    if (Keyboard.GetState().IsKeyUp(Keys.O))
                    {
                        animacionP2punching = 1;
                        golpe2 = 0;
                    }
                    if (Keyboard.GetState().IsKeyDown(Keys.I))
                    {
                        P2parado = false;
                        P2walking = false;
                        P2backing = false;
                        P2punching = false;
                        P2kicking = true;
                        patada2++;
                        if (tiempo % 20 == 0)
                        {
                            animacionP2kicking++;
                        }
                    }
                    if (Keyboard.GetState().IsKeyUp(Keys.I))
                    {
                        animacionP2kicking = 1;
                        patada2 = 0;
                    }
                    if (Keyboard.GetState().IsKeyDown(Keys.P))
                    {
                        P2parado = false;
                        P2walking = false;
                        P2backing = false;
                        P2punching = false;
                        P2kicking = false;
                        P2defense = true;
                    }
                    if (Keyboard.GetState().IsKeyDown(Keys.Down))
                    {
                        P2abajo = true;
                        P2parado = false;
                        P2walking = false;
                        P2backing = false;
                        P2punching = false;
                        P2kicking = false;
                        P2defense = false;
                    }
                    if (Keyboard.GetState().IsKeyDown(Keys.Up))
                    {
                        P2Jumping = true;
                        P2abajo = false;
                        P2parado = false;
                        P2walking = false;
                        P2backing = false;
                        P2punching = false;
                        P2kicking = false;
                        P2defense = false;
                        pPlayer2.Y -= 10;
                    }
                    if (Keyboard.GetState().IsKeyDown(Keys.Up) && Keyboard.GetState().IsKeyDown(Keys.Right))
                    {
                        pPlayer2.Y -= 10;
                        pPlayer2.X += 5;
                        P2Jumping = true;
                    }
                    if (Keyboard.GetState().IsKeyDown(Keys.Up) && Keyboard.GetState().IsKeyDown(Keys.Left))
                    {
                        pPlayer2.Y -= 10;
                        pPlayer2.X -= 5;
                        P2Jumping = true;
                    }
                    if (Keyboard.GetState().IsKeyDown(Keys.Up) && Keyboard.GetState().IsKeyDown(Keys.Left) &&
                        Keyboard.GetState().IsKeyDown(Keys.Right))
                    {
                        P2Jumping = true;
                        pPlayer2.X += 5;
                    }

                    //salto
                    if (P2Jumping == true)
                    {
                        P2abajo = false;
                        P2parado = false;
                        P2walking = false;
                        P2backing = false;
                        P2punching = false;
                        P2kicking = false;
                        P2defense = false;
                        if (pPlayer2.Y < 300)
                        {
                            cae2 = true;
                        }
                        else
                        {
                            cae2 = false;
                            posInicial2 = pPlayer2;
                            masa2 = 15f;
                            tiemposuelto2 = 0;
                            timeup2 = 0.05f;
                        } if (cae2 == true)
                        {
                            tiemposuelto2 += timeup2;
                            pPlayer2.Y = pPlayer2.Y + (masa2 * tiemposuelto2);
                        }
                    }

                    if (P2backing == true)
                    {
                        pPlayer2.X -= 5;
                        if (tiempo % 40 == 0)
                        {
                            animacionP2backing++;
                        }
                        if (animacionP2backing == 3)
                        {
                            animacionP2backing = 1;
                        }
                    }

                    if (P2walking == true)
                    {
                        pPlayer2.X += 5;
                        if (tiempo % 40 == 0)
                        {
                            animacionP2walking++;
                        }
                        if (animacionP2walking == 3)
                        {
                            animacionP2walking = 1;
                        }
                    }

                    if (pPlayer2.X <= 2)
                    {
                        pPlayer2.X += 5;
                        P2backing = false;
                        P2parado = true;
                        if (Keyboard.GetState().IsKeyDown(Keys.Up))
                        {
                            P2parado = false;
                        }
                    }
                    if (pPlayer2.X + imgparado1P2.Width >= 795)
                    {
                        pPlayer2.X -= 5;
                        P2backing = false;
                        P2parado = true;
                        P2walking = false;
                        if (Keyboard.GetState().IsKeyDown(Keys.Up))
                        {
                            P2parado = false;
                        }
                    }
                }
                //------------------------------------codigo danio player 1 al player 2----------------------------
                if ((Bplayer1.Intersects(Bplayer2)) && (P1punching == true) && (golpe1 == 1) && (P2defense == false))
                {
                    VidaPlayer2 = VidaPlayer2 - 5;
                    soundBank.PlayCue("dolor");
                    soundBank.PlayCue("golpe");
                }
                if ((Bplayer1.Intersects(Bplayer2)) && (P1punching == true) && (P2defense == true) && (golpe1 == 1))
                {
                    VidaPlayer2 = VidaPlayer2 - 0;
                    soundBank.PlayCue("golpe");
                }
                if ((Bplayer1.Intersects(Bplayer2)) && (P1kicking == true) && (patada1 == 1) && (P2defense == false))
                {
                    VidaPlayer2 = VidaPlayer2 - 10;
                    soundBank.PlayCue("dolor");
                    soundBank.PlayCue("golpe");
                }
                if ((Bplayer2.Intersects(Bplayer2)) && (P1kicking == true) && (P2defense == true) && (patada1 == 1))
                {
                    VidaPlayer2 = VidaPlayer2 - 0;
                    soundBank.PlayCue("golpe");
                }
                //-----------------------------------codigo danio player 2 a player 1
                if ((Bplayer2.Intersects(Bplayer1)) && (P2punching == true) && (golpe2 == 1) && (P1defense == false))
                {
                    VidaPlayer1 = VidaPlayer1 - 5;
                    soundBank.PlayCue("dolor");
                    soundBank.PlayCue("golpe");
                }
                if ((Bplayer1.Intersects(Bplayer2)) && (P2punching == true) && (P1defense == true) && (golpe2 == 1))
                {
                    VidaPlayer1 = VidaPlayer1 - 0;
                    soundBank.PlayCue("golpe");
                }
                if ((Bplayer1.Intersects(Bplayer2)) && (P2kicking == true) && (patada2 == 1) && (P1defense == false))
                {
                    VidaPlayer1 = VidaPlayer1 - 10;
                    soundBank.PlayCue("dolor");
                    soundBank.PlayCue("golpe");
                }
                if ((Bplayer2.Intersects(Bplayer1)) && (P2kicking == true) && (P1defense == true) && (golpe2 == 1))
                {
                    VidaPlayer1 = VidaPlayer1 - 0;
                    soundBank.PlayCue("golpe");
                }
                if (VidaPlayer1 < 0 || VidaPlayer2 < 0)
                    {
                        volverjugar = true;
                        PlayerActivated = false;
                        PlayerActivated = false;
                    }
                    if (tiemposucki <= 0 && VidaPlayer1 > VidaPlayer2)
                    {
                        volverjugar = true;

                        PlayerActivated = false;
                        PlayerActivated = false;
                    }
                    if (tiemposucki <= 0 && VidaPlayer1 < VidaPlayer2)
                    {
                        volverjugar = true;

                        PlayerActivated = false;
                        PlayerActivated = false;
                    }
                    if (volverjugar == true)
                    {
                        if (Keyboard.GetState().IsKeyDown(Keys.Space))
                        {
                            menu = true;
                            portada = false;
                            escenarios = false;
                            creditos = false;
                            escenario1 = false;
                            escenario2 = false;
                            volverjugar = false;
                            comojugar = false;
                            PlayerActivated = false;
                            PlayerActivated = false;
                            VidaPlayer1 = 100;
                            VidaPlayer2 = 100;
                            if (control3.IsPlaying)
                            {
                                control3.Stop(AudioStopOptions.AsAuthored);
                            }
                            if (control1.IsStopped)
                            {
                                control1 = soundBank.GetCue("slayersong");
                                control1.Play();
                            }
                        }
                    }
            }

            //-----------creditos----------------
            if (creditos == true)
            {
                menu = false;
                escenarios = false;
                pbtnsalir3 = new Vector2(650, 500);
                bbtnsalir2 = new BoundingBox(new Vector3(pbtnsalir3.X, pbtnsalir3.Y, 0),
                new Vector3(pbtnsalir3.X + btnsalir1.Width, pbtnsalir3.Y + btnsalir1.Height, 0));
                bratoncito = new BoundingBox(new Vector3(pratoncito.X, pratoncito.Y, 0),
                new Vector3(pratoncito.X + ratoncito.Width, pratoncito.Y + ratoncito.Height, 0));

                if (bratoncito.Intersects(bbtnsalir2))
                {
                    showbtnsalir3 = 1;
                }
                else
                {
                    showbtnsalir3 = 0;
                }
                if (bratoncito.Intersects(bbtnsalir2) && presionar == 1)
                {
                    menu = true;
                }
            }
            if (comojugar == true)
            {
                menu = false;
                escenarios = false;
                creditos = false;
                pbtnsalir3 = new Vector2(650, 550);
                bratoncito = new BoundingBox(new Vector3(pratoncito.X, pratoncito.Y, 0),
                new Vector3(pratoncito.X + ratoncito.Width, pratoncito.Y + ratoncito.Height, 0));
                bbtnsalir2 = new BoundingBox(new Vector3(pbtnsalir3.X, pbtnsalir3.Y, 0),
                new Vector3(pbtnsalir3.X + btnsalir1.Width, pbtnsalir3.Y + btnsalir1.Height, 0));
                if (bratoncito.Intersects(bbtnsalir2))
                {
                    showbtnsalir3 = 1;
                }
                else
                {
                    showbtnsalir3 = 0;
                }
                if (bratoncito.Intersects(bbtnsalir2) && presionar == 1)
                {
                    menu = true;
                    comojugar = false;
                }
            }
            

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            graphics.GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
            //--------------------------portada---------------------
            if (portada == true)
            {
                spriteBatch.Draw(fondo, pfondo, Color.White);
                if (coin == 1)
                {
                    spriteBatch.Draw(insert1, pinsert1, Color.White);
                }
                if (coin == 2)
                {
                    spriteBatch.Draw(insert2, pinsert2, Color.White);
                }
                if (coin == 3)
                {
                    spriteBatch.Draw(insert1, pinsert1, Color.White);
                }
            }
            //-------------------menu--------------------------
            if (menu == true)
            {
                spriteBatch.Draw(fondomenu, pfondomenu, Color.White);
                if (showbtnjugar2 == 0)
                {
                    spriteBatch.Draw(btnjugar1, pbtnjugar1, Color.White);
                }
                if (showbtnjugar2 == 1)
                {
                    spriteBatch.Draw(btnjugar2, pbtnjugar2, Color.White);
                }
                //
                if (showbtncomojugar2 == 0)
                {
                    spriteBatch.Draw(btncomojugar1, pbtncomojugar1, Color.White);
                }
                if (showbtncomojugar2 == 1)
                {
                    spriteBatch.Draw(btncomojugar2, pbtncomojugar2, Color.White);
                }
                //
                if (showbtncreditos2 == 0)
                {
                    spriteBatch.Draw(btncreditos1, pbtncreditos1, Color.White);
                }
                if (showbtncreditos2 == 1)
                {
                    spriteBatch.Draw(btncreditos2, pbtncreditos2, Color.White);
                }
                //
                if (showbtnsalir2 == 0)
                {
                    spriteBatch.Draw(btnsalir1, pbtnsalir1, Color.White);
                }
                if (showbtnsalir2 == 1)
                {
                    spriteBatch.Draw(btnsalir2, pbtnsalir2, Color.White);
                }
                spriteBatch.Draw(ratoncito, pratoncito, Color.White);
            }
            //---------------escenarios----------------------
            if (escenarios == true)
            {
                spriteBatch.Draw(fondoescenarios, pfondoescenarios, Color.White);
                spriteBatch.Draw(fondoescen1, pfondoescen1, Color.White);
                spriteBatch.Draw(fondoescen2, pfondoescen2, Color.White);
                if (showbtnsalir3 == 0)
                {

                    spriteBatch.Draw(btnsalir1, pbtnsalir3, Color.White);
                }
                if (showbtnsalir3 == 1)
                {
                    spriteBatch.Draw(btnsalir2, pbtnsalir3, Color.White);
                }
                spriteBatch.Draw(ratoncito, pratoncito, Color.White);
            }
            //-----------------------como jugar----------------------
            if (comojugar == true)
            {
                spriteBatch.Draw(fondocomojugar,pfondocomojugar,Color.White);
                if (showbtnsalir3 == 0)
                {
                    spriteBatch.Draw(btnsalir1, pbtnsalir3, Color.White);
                }
                if (showbtnsalir3 == 1)
                {
                    spriteBatch.Draw(btnsalir2, pbtnsalir3, Color.White);
                }
                spriteBatch.Draw(ratoncito, pratoncito, Color.White);
            }
            //-----------------------creditos---------------
            if (creditos == true)
            {

                spriteBatch.Draw(fondocreditos, pfondocreditos, Color.White);

                if (showbtnsalir3 == 0)
                {
                    spriteBatch.Draw(btnsalir1, pbtnsalir3, Color.White);
                }
                if (showbtnsalir3 == 1)
                {
                    spriteBatch.Draw(btnsalir2, pbtnsalir3, Color.White);
                }
                spriteBatch.Draw(ratoncito, pratoncito, Color.White);
            }
            //--------------------escenario1------------
            if (escenario1 == true)
            {
                Stiemposucki = Convert.ToString(tiemposucki);
                spriteBatch.Draw(fondoescenario1, pfondoescenario1, Color.White);
                spriteBatch.DrawString(fuente,Stiemposucki,ptiemposucki,Color.White);
                //////////////////////////////vidas player1
                if (VidaPlayer1 <= 100 && VidaPlayer1 > 90)
                {
                    spriteBatch.Draw(imgvida100P1,PimgvidaP1,Color.White);
                }
                if (VidaPlayer1 > 80 && VidaPlayer1 <= 90)
                {
                    spriteBatch.Draw(imgvida80P1, PimgvidaP1, Color.White);
                }
                if (VidaPlayer1 > 60 && VidaPlayer1 <= 80)
                {
                    spriteBatch.Draw(imgvida60P1, PimgvidaP1, Color.White);
                }
                if (VidaPlayer1 > 40 && VidaPlayer1 <= 60)
                {
                    spriteBatch.Draw(imgvida40P1, PimgvidaP1, Color.White);
                }
                if (VidaPlayer1 > 20 && VidaPlayer1 <= 40)
                {
                    spriteBatch.Draw(imgvida20P1, PimgvidaP1, Color.White);
                }
                if (VidaPlayer1 <= 20)
                {
                    spriteBatch.Draw(imgvida10P1, PimgvidaP1, Color.White);
                }
                ////////////////////////////////vidas player2
                if (VidaPlayer2 <= 100 && VidaPlayer2 > 90)
                {
                    spriteBatch.Draw(imgvida100P2, PimgvidaP2, Color.White);
                }
                if (VidaPlayer2 > 80 && VidaPlayer2 <= 90)
                {
                    spriteBatch.Draw(imgvida80P2, PimgvidaP2, Color.White);
                }
                if (VidaPlayer2 > 60 && VidaPlayer2 <= 80)
                {
                    spriteBatch.Draw(imgvida60P2, PimgvidaP2, Color.White);
                }
                if (VidaPlayer2 > 40 && VidaPlayer2 <= 60)
                {
                    spriteBatch.Draw(imgvida40P2, PimgvidaP2, Color.White);
                }
                if (VidaPlayer2 > 20 && VidaPlayer2 <= 40)
                {
                    spriteBatch.Draw(imgvida20P2, PimgvidaP2, Color.White);
                }
                if ( VidaPlayer2 <= 20)
                {
                    spriteBatch.Draw(imgvida10P2, PimgvidaP2, Color.White);
                }
                /////////////////////////
                if (loading1 == true)
                {
                            if (animamamalona == 0)
                            {
                                spriteBatch.Draw(fondoimg1, panimamalona, Color.White);
                            }
                            if (animamamalona == 1)
                            {
                                spriteBatch.Draw(fondoimg2, panimamalona, Color.White);
                            }
                            if (animamamalona == 2)
                            {
                                spriteBatch.Draw(fondoimg3, panimamalona, Color.White);
                            }
                            if (animamamalona == 3)
                            {
                                spriteBatch.Draw(fondoimg4, panimamalona, Color.White);
                            }
                            if (animamamalona == 4)
                            {
                                spriteBatch.Draw(fondoimg5, panimamalona, Color.White);
                            }
                            if (animamamalona == 5)
                            {
                                spriteBatch.Draw(fondoimg6, panimamalona, Color.White);
                            }
                            if (animamamalona == 6)
                            {
                                spriteBatch.Draw(fondoimg1, panimamalona, Color.White);
                            }
                            if (animamamalona == 7)
                            {
                                spriteBatch.Draw(fondoimg2, panimamalona, Color.White);
                            }
                            if (animamamalona == 8)
                            {
                                spriteBatch.Draw(fondoimg3, panimamalona, Color.White);
                            }
                            if (animamamalona == 9)
                            {
                                spriteBatch.Draw(fondoimg4, panimamalona, Color.White);
                            }
                            if (animamamalona == 10)
                            {
                                spriteBatch.Draw(fondoimg5, panimamalona, Color.White);
                            }
                            if (animamamalona == 11)
                            {
                                spriteBatch.Draw(fondoimg6, panimamalona, Color.White);
                            }
                            if (animamamalona == 12)
                            {
                                spriteBatch.Draw(fondoimg1, panimamalona, Color.White);
                            }
                     }
                }
                    //----------------------------escenario2----------------------
                if (escenario2 == true)
                {
                    Stiemposucki = Convert.ToString(tiemposucki);
                    spriteBatch.Draw(fondoescenario2, pfondoescenario2, Color.White);
                    spriteBatch.DrawString(fuente, Stiemposucki, ptiemposucki, Color.Black);
                    
                    if (VidaPlayer1 <= 100 && VidaPlayer1 > 90)
                    {
                        spriteBatch.Draw(imgvida100P1, PimgvidaP1, Color.White);
                    }
                    if (VidaPlayer1 > 80 && VidaPlayer1 <= 90)
                    {
                        spriteBatch.Draw(imgvida80P1, PimgvidaP1, Color.White);
                    }
                    if (VidaPlayer1 > 60 && VidaPlayer1 <= 80)
                    {
                        spriteBatch.Draw(imgvida60P1, PimgvidaP1, Color.White);
                    }
                    if (VidaPlayer1 > 40 && VidaPlayer1 <= 60)
                    {
                        spriteBatch.Draw(imgvida40P1, PimgvidaP1, Color.White);
                    }
                    if (VidaPlayer1 > 20 && VidaPlayer1 <= 40)
                    {
                        spriteBatch.Draw(imgvida20P1, PimgvidaP1, Color.White);
                    }
                    if (VidaPlayer1 <= 20)
                    {
                        spriteBatch.Draw(imgvida10P1, PimgvidaP1, Color.White);
                    }
                    ////////////////////////////////vidas player2
                    if (VidaPlayer2 <= 100 && VidaPlayer2 > 90)
                    {
                        spriteBatch.Draw(imgvida100P2, PimgvidaP2, Color.White);
                    }
                    if (VidaPlayer2 > 80 && VidaPlayer2 <= 90)
                    {
                        spriteBatch.Draw(imgvida80P2, PimgvidaP2, Color.White);
                    }
                    if (VidaPlayer2 > 60 && VidaPlayer2 <= 80)
                    {
                        spriteBatch.Draw(imgvida60P2, PimgvidaP2, Color.White);
                    }
                    if (VidaPlayer2 > 40 && VidaPlayer2 <= 60)
                    {
                        spriteBatch.Draw(imgvida40P2, PimgvidaP2, Color.White);
                    }
                    if (VidaPlayer2 > 20 && VidaPlayer2 <= 40)
                    {
                        spriteBatch.Draw(imgvida20P2, PimgvidaP2, Color.White);
                    }
                    if (VidaPlayer2 <= 20)
                    {
                        spriteBatch.Draw(imgvida10P2, PimgvidaP2, Color.White);
                    }
                    /////////////////////////
                    if (loading1 == true)
                    {
                        if (animamamalona == 0)
                        {
                            spriteBatch.Draw(fondoimg1, panimamalona, Color.White);
                        }
                        if (animamamalona == 1)
                        {
                            spriteBatch.Draw(fondoimg2, panimamalona, Color.White);
                        }
                        if (animamamalona == 2)
                        {
                            spriteBatch.Draw(fondoimg3, panimamalona, Color.White);
                        }
                        if (animamamalona == 3)
                        {
                            spriteBatch.Draw(fondoimg4, panimamalona, Color.White);
                        }
                        if (animamamalona == 4)
                        {
                            spriteBatch.Draw(fondoimg5, panimamalona, Color.White);
                        }
                        if (animamamalona == 5)
                        {
                            spriteBatch.Draw(fondoimg6, panimamalona, Color.White);
                        }
                        if (animamamalona == 6)
                        {
                            spriteBatch.Draw(fondoimg1, panimamalona, Color.White);
                        }
                        if (animamamalona == 7)
                        {
                            spriteBatch.Draw(fondoimg2, panimamalona, Color.White);
                        }
                        if (animamamalona == 8)
                        {
                            spriteBatch.Draw(fondoimg3, panimamalona, Color.White);
                        }
                        if (animamamalona == 9)
                        {
                            spriteBatch.Draw(fondoimg4, panimamalona, Color.White);
                        }
                        if (animamamalona == 10)
                        {
                            spriteBatch.Draw(fondoimg5, panimamalona, Color.White);
                        }
                        if (animamamalona == 11)
                        {
                            spriteBatch.Draw(fondoimg6, panimamalona, Color.White);
                        }
                        if (animamamalona == 12)
                        {
                            spriteBatch.Draw(fondoimg1, panimamalona, Color.White);
                        }
                    }
                }

                    //-------
                if (PlayerActivated == true && PlayerActivated2 ==  true)
                {
                    if (espejo == 1)
                    {
                        //-----------------------!!!!!!!!ANIMACION PLAYER 1!!!!!!!!!!----------------//
                        if (P1parado == true)
                        {
                            spriteBatch.Draw(imgparado1, pPlayer1, Color.White);
                        }
                        /////////////
                        if (P1walking)
                        {
                            if (animacionP1walking == 1)
                            {
                                spriteBatch.Draw(imgwalking1, pPlayer1, Color.White);
                            }
                            if (animacionP1walking == 2)
                            {
                                spriteBatch.Draw(imgwalking3, pPlayer1, Color.White);
                            }

                        }
                        /////////////////
                        if (P1backing == true)
                        {
                            if (animacionP1backing == 1)
                            {
                                spriteBatch.Draw(imgwalking3, pPlayer1, Color.White);
                            }
                            if (animacionP1backing == 2)
                            {
                                spriteBatch.Draw(imgwalking1, pPlayer1, Color.White);
                            }

                        }
                        //////////////////animacion golpe
                        if (P1punching == true)
                        {
                            if (animacionP1punching >= 1 && animacionP1punching <= 3)
                            {
                                spriteBatch.Draw(imgpunching1, pPlayer1, Color.White);
                            }
                            if (animacionP1punching > 3)
                            {
                                spriteBatch.Draw(imgparado1, pPlayer1, Color.White);
                            }
                        }
                        ////////////////////animacion patada
                        if (P1kicking == true)
                        {
                            if (animacionP1kicking >= 1 && animacionP1kicking <= 3)
                            {
                                spriteBatch.Draw(imgkick3, pPlayer1, Color.White);
                            }

                            if (animacionP1kicking > 3)
                            {
                                spriteBatch.Draw(imgparado1, pPlayer1, Color.White);
                            }
                        }
                        ///////////////////////////////////animacion defensa
                        if (P1defense == true)
                        {
                            spriteBatch.Draw(imgdefense, pPlayer1, Color.White);
                        }
                        /////////////animacion abajo
                        if (P1abajo == true)
                        {
                            spriteBatch.Draw(imgabajo, pPlayer1, Color.White);
                        }
                        if (P1Jumping == true)
                        {
                            spriteBatch.Draw(imgJumping4, pPlayer1, Color.White);
                        }

                        //--------------------**************ANIMACION PLAYER 2**********----------------//
                        if (P2parado == true)
                        {
                            spriteBatch.Draw(imgparado1P2, pPlayer2, Color.White);
                        }
                        /////////////
                        if (P2walking)
                        {
                            if (animacionP2walking == 1)
                            {
                                spriteBatch.Draw(imgwalking1P2, pPlayer2, Color.White);
                            }
                            if (animacionP2walking == 2)
                            {
                                spriteBatch.Draw(imgwalking2P2, pPlayer2, Color.White);
                            }

                        }
                        /////////////////
                        if (P2backing == true)
                        {
                            if (animacionP2backing == 1)
                            {
                                spriteBatch.Draw(imgwalking2P2, pPlayer2, Color.White);
                            }
                            if (animacionP2backing == 2)
                            {
                                spriteBatch.Draw(imgwalking1P2, pPlayer2, Color.White);
                            }

                        }
                        //////////////////animacion golpe
                        if (P2punching == true)
                        {
                            if (animacionP2punching >= 1 && animacionP2punching <= 3)
                            {
                                spriteBatch.Draw(imgpuching1P2, pPlayer2, Color.White);
                            }
                            if (animacionP2punching > 2)
                            {
                                spriteBatch.Draw(imgparado1P2, pPlayer2, Color.White);
                            }
                        }
                        ////////////////////animacion patada
                        if (P2kicking == true)
                        {
                            if (animacionP2kicking >= 1 && animacionP2kicking <= 3)
                            {
                                spriteBatch.Draw(imgkick2P2, pPlayer2, Color.White);
                            }

                            if (animacionP2kicking > 3)
                            {
                                spriteBatch.Draw(imgparado1P2, pPlayer2, Color.White);
                            }
                        }
                        ///////////////////////////////////animacion defensa
                        if (P2defense == true)
                        {
                            spriteBatch.Draw(imgdefense1P2, pPlayer2, Color.White);
                        }
                        /////////////animacion abajo
                        if (P2abajo == true)
                        {
                            spriteBatch.Draw(imgabajo1P2, pPlayer2, Color.White);
                        }
                        if (P2Jumping == true)
                        {
                            spriteBatch.Draw(imgJumping1P2, pPlayer2, Color.White);
                        }
                    }
                }
            //////////////////////////////*****************************************************************
                if (PlayerActivated2 == true == PlayerActivated == true)
                {
                    if (espejo == 2)
                    {
                        //-----------------------!!!!!!!!ANIMACION PLAYER 1!!!!!!!!!!----------------//
                        if (P1parado == true)
                        {
                            spriteBatch.Draw(Eimgparado1, pPlayer1, Color.White);
                        }
                        /////////////
                        if (P1walking)
                        {
                            if (animacionP1walking == 1)
                            {
                                spriteBatch.Draw(Eimgwalking1, pPlayer1, Color.White);
                            }
                            if (animacionP1walking == 2)
                            {
                                spriteBatch.Draw(Eimgwalking3, pPlayer1, Color.White);
                            }

                        }
                        /////////////////
                        if (P1backing == true)
                        {
                            if (animacionP1backing == 1)
                            {
                                spriteBatch.Draw(Eimgwalking3, pPlayer1, Color.White);
                            }
                            if (animacionP1backing == 2)
                            {
                                spriteBatch.Draw(Eimgwalking1, pPlayer1, Color.White);
                            }

                        }
                        //////////////////animacion golpe
                        if (P1punching == true)
                        {
                            if (animacionP1punching >= 1 && animacionP1punching <= 3)
                            {
                                spriteBatch.Draw(Eimgpunching1, pPlayer1, Color.White);
                            }
                            if (animacionP1punching > 3)
                            {
                                spriteBatch.Draw(Eimgparado1, pPlayer1, Color.White);
                            }
                        }
                        ////////////////////animacion patada
                        if (P1kicking == true)
                        {
                            if (animacionP1kicking >= 1 && animacionP1kicking <= 3)
                            {
                                spriteBatch.Draw(Eimgkick3, pPlayer1, Color.White);
                            }

                            if (animacionP1kicking > 3)
                            {
                                spriteBatch.Draw(Eimgparado1, pPlayer1, Color.White);
                            }
                        }
                        ///////////////////////////////////animacion defensa
                        if (P1defense == true)
                        {
                            spriteBatch.Draw(Eimgdefense, pPlayer1, Color.White);
                        }
                        /////////////animacion abajo
                        if (P1abajo == true)
                        {
                            spriteBatch.Draw(Eimgabajo, pPlayer1, Color.White);
                        }
                        if (P1Jumping == true)
                        {
                            spriteBatch.Draw(EimgJumping4, pPlayer1, Color.White);
                        }

                        //--------------------**************ANIMACION PLAYER 2**********----------------//
                        if (P2parado == true)
                        {
                            spriteBatch.Draw(Eimgparado1P2, pPlayer2, Color.White);
                        }
                        /////////////
                        if (P2walking)
                        {
                            if (animacionP2walking == 1)
                            {
                                spriteBatch.Draw(Eimgwalking1P2, pPlayer2, Color.White);
                            }
                            if (animacionP2walking == 2)
                            {
                                spriteBatch.Draw(Eimgwalking2P2, pPlayer2, Color.White);
                            }

                        }
                        /////////////////
                        if (P2backing == true)
                        {
                            if (animacionP2backing == 1)
                            {
                                spriteBatch.Draw(Eimgwalking2P2, pPlayer2, Color.White);
                            }
                            if (animacionP2backing == 2)
                            {
                                spriteBatch.Draw(Eimgwalking1P2, pPlayer2, Color.White);
                            }

                        }
                        //////////////////animacion golpe
                        if (P2punching == true)
                        {
                            if (animacionP2punching >= 1 && animacionP2punching <= 3)
                            {
                                spriteBatch.Draw(Eimgpuching1P2, pPlayer2, Color.White);
                            }
                            if (animacionP2punching > 2)
                            {
                                spriteBatch.Draw(Eimgparado1P2, pPlayer2, Color.White);
                            }
                        }
                        ////////////////////animacion patada
                        if (P2kicking == true)
                        {
                            if (animacionP2kicking >= 1 && animacionP2kicking <= 3)
                            {
                                spriteBatch.Draw(Eimgkick2P2, pPlayer2, Color.White);
                            }

                            if (animacionP2kicking > 3)
                            {
                                spriteBatch.Draw(Eimgparado1P2, pPlayer2, Color.White);
                            }
                        }
                        ///////////////////////////////////animacion defensa
                        if (P2defense == true)
                        {
                            spriteBatch.Draw(Eimgdefense1P2, pPlayer2, Color.White);
                        }
                        /////////////animacion abajo
                        if (P2abajo == true)
                        {
                            spriteBatch.Draw(Eimgabajo1P2, pPlayer2, Color.White);
                        }
                        if (P2Jumping == true)
                        {
                            spriteBatch.Draw(EimgJumping1P2, pPlayer2, Color.White);
                        }
                    }
                }
                    //***********************************************************************************

                if ((volverjugar == true && VidaPlayer1 < 0) || (volverjugar == true && VidaPlayer1 < VidaPlayer2))
                    {
                        spriteBatch.Draw(fondoPlayer2wins,pfondoPlayer2wins,Color.White);
                    }
                    if ((volverjugar == true && VidaPlayer2 < 0) || (volverjugar == true && VidaPlayer2 < VidaPlayer1))
                    {
                        spriteBatch.Draw(fondoPlayer1wins, pfondoPlayer1wins, Color.White);
                    }
                spriteBatch.End();
                base.Draw(gameTime);
            }
        }
    }

