﻿using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.IO;
using System;
using static NotSonicGame.Directions;

namespace NotSonicGame
{
    public class RandomLevelLoader
    {
        RandomLevel level;
        StreamReader stream1;
        StreamReader stream2;
        StreamReader stream3;

        public RandomLevel LoadOnePlayerLevel()
        {
            stream1 = new StreamReader("Content/leveltest.csv");
            Random rnd = new Random();      

            if (rnd.NextDouble() % 2 == 0)
            {
               stream2 = new StreamReader("Content/random2.csv");
            }
            else
            {
                stream2 = new StreamReader("Content/random3.csv");
            }

            stream3 = new StreamReader("Content/randomFinish.csv");

            level = LoadLevel();
            return level;

        }

        private RandomLevel LoadLevel()
        {

            List<IGameObject> objects = new List<IGameObject>();
            Background background1;
            background1 = new Background();
            objects.Add(background1);

            int currentBlock; int currentStartingXPosition = 0;
            StreamReader stream = stream1;
            for (currentBlock = 0; currentBlock < 3; currentBlock++) {
                if (currentBlock == 1)
                {
                   stream = stream2;
                }
                else if (currentBlock == 2)
                {
                   stream = stream3;
                } 


            int length = Convert.ToInt32(stream.ReadLine());
            string current = stream.ReadLine();
            Vector2 position = new Vector2(currentStartingXPosition, 0);

            while (current != null)
            {
                for (int j = 0; j < 2 * length - 1; j++)
                {
                    char temp = current[j];

                    if (temp == ',')
                    {
                        //do nothing
                    }
                    else
                    {
                        if (temp == 't')
                        {
                            objects.Add(new SimpleTerrain(position));
                        }
                        else if (temp == 'c')
                        {
                            objects.Add(new Ring(position));
                        }
                        else if (temp == 'v')
                        {
                            temp = current[++j];
                            AddVideoMonitor(objects, position, temp);
                        }
                        else if (temp == 'k')
                        {
                            objects.Add(new Spike(new Vector2(position.X, position.Y + 9), false));
                        }
                        else if (temp == 'j')
                        {
                            objects.Add(new Spike(new Vector2(position.X + 9, position.Y), true));
                        }
                        else if (temp == 's')
                        {
                            objects.Add(new Spring(new Vector2(position.X + 5, position.Y + 22)));
                        }
                        else if (temp == 'd')
                        {
                            objects.Add(new Spring(position, true, true));
                        }
                        else if (temp == '1')
                        {
                            objects.Add(new Chopper(position));
                        }
                        else if (temp == '2')
                        {
                            objects.Add(new MotoBug(new Vector2(position.X, position.Y + 9)));
                        }
                        else if (temp == '3')
                        {
                            objects.Add(new Crabmeat(new Vector2(position.X, position.Y + 8)));
                        }
                        else if (temp == '4')
                        {
                            objects.Add(new BuzzBomber(position));
                        }
                        else if (temp == '5')
                        {
                            objects.Add(new Cannon(new Vector2(position.X, position.Y + 13)));
                        }
                        else if (temp == '|')
                        {
                            objects.Add(new WoodBlock(position));
                        }
                        else if (temp == '_')
                        {
                            objects.Add(new UndergroundBlock(position));
                        }
                        else if (temp == 'p')
                        {
                            temp = current[++j];
                            AddWoodenPlatform(objects, position, temp);
                        }
                        else if (temp == '{')
                        {
                            objects.Add(new Cannon(new Vector2(position.X, position.Y + 12)));
                        }
                        else if (temp == 'F')
                        {
                            objects.Add(new EndRing(position));
                        }

                        position.X += 40;

                    }

                }
                position.X = currentStartingXPosition;
                position.Y += 40;
                current = stream1.ReadLine();
            }

                currentStartingXPosition += (length * 40);
        }

            return new RandomLevel(objects, background1);
        }
        private static void AddWoodenPlatform(List<IGameObject> objectList, Vector2 position, char c)
        {
            switch (c)
            {
                case '1':
                    objectList.Add(new WoodenPlatform(position, Direction.Up));
                    break;
                case '2':
                    objectList.Add(new WoodenPlatform(position, Direction.Down));
                    break;
                case '3':
                    objectList.Add(new WoodenPlatform(position, Direction.Left));
                    break;
                case '4':
                    objectList.Add(new WoodenPlatform(position, Direction.Right));
                    break;
                default:
                    objectList.Add(new WoodenPlatform(position, Direction.None));
                    break;
            }
        }

        private static void AddVideoMonitor(List<IGameObject> objectList, Vector2 position, char variant)
        {
            switch (variant)
            {
                case '1':
                    objectList.Add(new VideoMonitor(1, new Vector2(position.X, position.Y + 10)));
                    break;
                case '2':
                    objectList.Add(new VideoMonitor(2, new Vector2(position.X, position.Y + 10)));
                    break;
                case '3':
                    objectList.Add(new VideoMonitor(3, new Vector2(position.X, position.Y + 10)));
                    break;
                case '4':
                    objectList.Add(new VideoMonitor(4, new Vector2(position.X, position.Y + 10)));
                    break;
                case '5':
                    objectList.Add(new VideoMonitor(5, new Vector2(position.X, position.Y + 10)));
                    break;
                case '6':
                    objectList.Add(new VideoMonitor(6, new Vector2(position.X, position.Y + 10)));
                    break;
            }
        }

    }
}