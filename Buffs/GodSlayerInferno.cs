using RecolorMod;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace RecolorMod.Buffs
{

	public class GodSlayerInferno : ModBuff
	{
		public static int DefenseReduction = 10;

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("God Slayer Inferno");
			Description.SetDefault("Your flesh is burning off");
			Main.debuff[Type] = true;
			Main.pvpBuff[Type] = true;
			Main.buffNoSave[Type] = true;
			BuffID.Sets.LongerExpertDebuff[Type] = true;

		}

		public override void Update(Player player, ref int buffIndex)
		{
			player.GetModPlayer<RecolorPlayer>().gsInferno = true;
		}

		public override void Update(NPC npc, ref int buffIndex)
		{
			RecolorGlobalNPC recolorGlobalNPC = npc.GetGlobalNPC<RecolorGlobalNPC>();
			if (RecolorGlobalNPC.gsInferno < npc.buffTime[buffIndex])
			{
				RecolorGlobalNPC.gsInferno = npc.buffTime[buffIndex];
			}
			npc.DelBuff(buffIndex);
			buffIndex--;
		}
	}

}
