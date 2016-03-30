﻿namespace SkyLv_AurelionSol
{

    using LeagueSharp;
    using LeagueSharp.Common;


    internal class CastOnDash
    {
        #region #GET
        private static Obj_AI_Hero Player
        {
            get
            {
                return SkyLv_AurelionSol.Player;
            }
        }

        private static Spell Q
        {
            get
            {
                return SkyLv_AurelionSol.Q;
            }
        }
        #endregion

        static CastOnDash()
        {
            //Menu
            SkyLv_AurelionSol.Menu.SubMenu("Combo").AddItem(new MenuItem("AurelionSol.AutoQOnDashPosition", "Auto Use Q On Target Dash End Position").SetValue(true));

            CustomEvents.Unit.OnDash += Unit_OnDash;
        }

        #region On Dash
        static void Unit_OnDash(Obj_AI_Base sender, Dash.DashItem args)
        {
            
            var target = TargetSelector.GetTarget(Q.Range, TargetSelector.DamageType.Magical);

            if (!sender.IsEnemy) return;

            if (sender.NetworkId == target.NetworkId)
            {

                if (SkyLv_AurelionSol.Menu.Item("AurelionSol.AutoQOnDashPosition").GetValue<bool>() && Q.IsReady() && Player.Distance(args.EndPos) > 550 && Player.Distance(sender) < Q.Range)
                {
                    var delay = (int)(args.EndTick - Game.Time - Q.Delay - 0.1f);
                    if (delay > 0)
                    {
                        Utility.DelayAction.Add(delay * 1000, () => Q.Cast(args.EndPos));
                    }
                    else
                    {
                        Q.Cast(args.EndPos);
                    }
                }
            }
        }
        #endregion
    }
}
