﻿namespace SkyLv_Fountain
{
    using System;

    using LeagueSharp;
    using LeagueSharp.Common;
    using SharpDX;


    internal class FountainMoves
    {
        #region #GET
        private static Obj_AI_Hero Player
        {
            get
            {
                return SkyLv_Fountain.Player;
            }
        }
        #endregion

        private static int FountainMove;

        

        static FountainMoves()
        {
            //Menu
            
            if (Game.MapId == GameMapId.SummonersRift)
            {
                SkyLv_Fountain.Menu.AddItem(new MenuItem(Player.ChampionName.ToString() + ".AutoMoveFountainMovePosSummonersRift", "Auto Move Best Pos in Fountain").SetValue(true));
                SkyLv_Fountain.Menu.AddItem(new MenuItem(Player.ChampionName.ToString() + ".FountainMovePosSummonersRift", "Player Lane").SetValue(new StringList(new[] { "Mid", "Top", "Bot" }, 0)));
            }
            
            if (Game.MapId == GameMapId.TwistedTreeline)
            {
                SkyLv_Fountain.Menu.AddItem(new MenuItem(Player.ChampionName.ToString() + ".AutoMoveFountainMovePosTwistedTreeline", "Auto Move Best Pos in Fountain").SetValue(true));
                SkyLv_Fountain.Menu.AddItem(new MenuItem(Player.ChampionName.ToString() + ".FountainMovePosTwistedTreeline", "Player Lane").SetValue(new StringList(new[] { "Top", "Bot" }, 0)));
            }

            if (Game.MapId == GameMapId.HowlingAbyss)
            {
                SkyLv_Fountain.Menu.AddItem(new MenuItem(Player.ChampionName.ToString() + ".AutoMoveFountainMovePosHowlingAbyss", "Auto Move Best Pos in Fountain").SetValue(true));
            }

            Game.OnUpdate += Game_OnUpdate;
        }

        private static void Game_OnUpdate(EventArgs args)
        {
            FountainAutoMoves();
        }

        public static void FountainAutoMoves()
        {
            if (Player.InFountain() && Utils.GameTimeTickCount - FountainMove >= 20000)
            {
                #region SummonersRift

                if (Game.MapId == GameMapId.SummonersRift && SkyLv_Fountain.Menu.Item(Player.ChampionName.ToString() + ".AutoMoveFountainMovePosSummonersRift").GetValue<bool>())
                {
                    if (Player.Team == GameObjectTeam.Order)
                    {
                        switch (SkyLv_Fountain.Menu.Item(Player.ChampionName.ToString() + ".FountainMovePosSummonersRift").GetValue<StringList>().SelectedIndex)
                        {
                            case 0:
                                {
                                    Player.IssueOrder(GameObjectOrder.MoveTo, new Vector3(834.00f, 1300.00f, 105.60f));
                                    FountainMove = Utils.GameTimeTickCount;
                                    break;
                                }
                            case 1:
                                {
                                    Player.IssueOrder(GameObjectOrder.MoveTo, new Vector3(526.00f, 1352.00f, 103.02f));
                                    FountainMove = Utils.GameTimeTickCount;
                                    break;
                                }
                            case 2:
                                {
                                    Player.IssueOrder(GameObjectOrder.MoveTo, new Vector3(1370.00f, 538.00f, 99.85f));
                                    FountainMove = Utils.GameTimeTickCount;
                                    break;
                                }

                        }
                    }

                    if (Player.Team == GameObjectTeam.Chaos)
                    {
                        switch (SkyLv_Fountain.Menu.Item(Player.ChampionName.ToString() + ".FountainMovePosSummonersRift").GetValue<StringList>().SelectedIndex)
                        {
                            case 0:
                                {
                                    Player.IssueOrder(GameObjectOrder.MoveTo, new Vector3(13886.00f, 13602.00f, 119.23f));
                                    FountainMove = Utils.GameTimeTickCount;
                                    break;
                                }
                            case 1:
                                {
                                    Player.IssueOrder(GameObjectOrder.MoveTo, new Vector3(13408.00f, 14294.00f, 126.02f));
                                    FountainMove = Utils.GameTimeTickCount;
                                    break;
                                }
                            case 2:
                                {
                                    Player.IssueOrder(GameObjectOrder.MoveTo, new Vector3(14172.00f, 13384.00f, 91.65f));
                                    FountainMove = Utils.GameTimeTickCount;
                                    break;
                                }
                        }
                    }
                }

                #endregion

                #region TwistedTreeline

                if (Game.MapId == GameMapId.TwistedTreeline && SkyLv_Fountain.Menu.Item(Player.ChampionName.ToString() + ".AutoMoveFountainMovePosTwistedTreeline").GetValue<bool>())
                {
                    if (Player.Team == GameObjectTeam.Order)
                    {
                        switch (SkyLv_Fountain.Menu.Item(Player.ChampionName.ToString() + ".FountainMovePosTwistedTreeline").GetValue<StringList>().SelectedIndex)
                        {
                            case 0:
                                {
                                    Player.IssueOrder(GameObjectOrder.MoveTo, new Vector3(2120.00f, 8943.00f, 17.44f));
                                    FountainMove = Utils.GameTimeTickCount;
                                    break;
                                }
                            case 1:
                                {
                                    Player.IssueOrder(GameObjectOrder.MoveTo, new Vector3(1018.00f, 6801.00f, 159.32f));
                                    FountainMove = Utils.GameTimeTickCount;
                                    break;
                                }
                        }
                    }

                    if (Player.Team == GameObjectTeam.Chaos)
                    {
                        switch (SkyLv_Fountain.Menu.Item(Player.ChampionName.ToString() + ".FountainMovePosTwistedTreeline").GetValue<StringList>().SelectedIndex)
                        {
                            case 0:
                                {
                                    Player.IssueOrder(GameObjectOrder.MoveTo, new Vector3(13766.00f, 9147.00f, 14.05f));
                                    FountainMove = Utils.GameTimeTickCount;
                                    break;
                                }
                            case 1:
                                {
                                    Player.IssueOrder(GameObjectOrder.MoveTo, new Vector3(14468.00f, 6823.00f, 158.93f));
                                    FountainMove = Utils.GameTimeTickCount;
                                    break;
                                }
                        }
                    }
                }

                #endregion

                #region HowlingAbyss

                if (Game.MapId == GameMapId.HowlingAbyss && SkyLv_Fountain.Menu.Item(Player.ChampionName.ToString() + ".AutoMoveFountainMovePosHowlingAbyss").GetValue<bool>())
                {
                    if (Player.Team == GameObjectTeam.Order)
                    {
                        Player.IssueOrder(GameObjectOrder.MoveTo, new Vector3(1613.00f, 2423.00f, -177.89f));
                        FountainMove = Utils.GameTimeTickCount;
                        return;
                    }

                    if (Player.Team == GameObjectTeam.Chaos)
                    {
                        Player.IssueOrder(GameObjectOrder.MoveTo, new Vector3(10715.00f, 11129.00f, -177.89f));
                        FountainMove = Utils.GameTimeTickCount;
                        return;
                    }
                }

                #endregion
            }
        }
    }
}
