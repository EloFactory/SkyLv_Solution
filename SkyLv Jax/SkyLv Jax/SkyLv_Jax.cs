﻿namespace SkyLv_Jax
{

    using LeagueSharp;
    using LeagueSharp.Common;

    using System.Linq;
    using System.Collections.Generic;

    internal class SkyLv_Jax
    {

        public static Menu Menu;
        public static Orbwalking.Orbwalker Orbwalker;
        public static Spell Q;
        public static Spell W;
        public static Spell E;
        public static Spell R;
        public static Spell Ignite = new Spell(SpellSlot.Unknown, 600);

        public static List<Spell> SpellList = new List<Spell>();

        public static List<Obj_AI_Hero> Enemies = new List<Obj_AI_Hero>(), Allies = new List<Obj_AI_Hero>();

        public const string ChampionName = "Jax";

        public static Obj_AI_Hero Player
        {
            get
            {
                return ObjectManager.Player;
            }
        }

        public static readonly string[] Monsters =
        {
            "SRU_Razorbeak", "SRU_Krug", "Sru_Crab", "SRU_Baron", "SRU_Dragon",
            "SRU_Blue", "SRU_Red", "SRU_Murkwolf", "SRU_Gromp", "TT_NGolem5",
            "TT_NGolem2", "TT_NWolf6", "TT_NWolf3","TT_NWraith1", "TT_Spider"
        };

        public SkyLv_Jax()
        {

            if (Player.ChampionName != ChampionName) return;

            Q = new Spell(SpellSlot.Q, 700);
            W = new Spell(SpellSlot.W, Orbwalking.GetRealAutoAttackRange(Player));
            E = new Spell(SpellSlot.E, 375);
            R = new Spell(SpellSlot.R);

            var ignite = Player.Spellbook.Spells.FirstOrDefault(spell => spell.Name == "summonerdot");
            if (ignite != null)
                Ignite.Slot = ignite.Slot;

            SpellList.Add(Q);
            SpellList.Add(W);
            SpellList.Add(E);
            SpellList.Add(R);

            Menu = new Menu("SkyLv " + ChampionName + " By LuNi", "SkyLv " + ChampionName + " By LuNi", true);

            Menu.AddSubMenu(new Menu("Orbwalking", "Orbwalking"));

            var targetSelectorMenu = new Menu("Target Selector", "Target Selector");
            TargetSelector.AddToMenu(targetSelectorMenu);
            Menu.AddSubMenu(targetSelectorMenu);

            Orbwalker = new Orbwalking.Orbwalker(Menu.SubMenu("Orbwalking"));

            Menu.AddSubMenu(new Menu("Combo", "Combo"));

            Menu.AddSubMenu(new Menu("Harass", "Harass"));

            Menu.AddSubMenu(new Menu("LaneClear", "LaneClear"));

            Menu.AddSubMenu(new Menu("JungleClear", "JungleClear"));

            Menu.AddSubMenu(new Menu("Misc", "Misc"));

            Menu.AddSubMenu(new Menu("Drawings", "Drawings"));

            Menu.AddToMainMenu();

            new AfterAttack();
            new KillSteal();
            new JungleSteal();
            new OnUpdateFeatures();
            new Combo();
            new Harass();
            new JungleClear();
            new LaneClear();
            new PotionManager();
            new SpellLeveler();
            new Draw();
            new SkinChanger();
            new FountainMoves();
        }
    }
}