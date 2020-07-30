﻿using System.Collections.Generic;
using Terraria.DataStructures;

namespace Terraria.ModLoader
{
	/// <summary> This class represents a DrawLayer for the player, and uses PlayerDrawInfo as its InfoType. Drawing should be done by adding Terraria.DataStructures.DrawData objects to Main.playerDrawData. </summary>
	[Autoload(false)]
	public sealed class LegacyPlayerLayer : PlayerLayer
	{
		/// <summary> The delegate of this method, which can either do the actual drawing or add draw data, depending on what kind of layer this is. </summary>
		public readonly LayerFunction Layer;

		private readonly string CustomName;

		public override string Name => CustomName;

		/// <summary> Creates a LegacyPlayerLayer with the given mod name, identifier name, and drawing action. </summary>
		public LegacyPlayerLayer(Mod mod, string name, LayerFunction layer) {
			Mod = mod;
			CustomName = name;
			Layer = layer;
		}

		/// <summary> Creates a LegacyPlayerLayer with the given mod name, identifier name, parent layer, and drawing action. </summary>
		public LegacyPlayerLayer(Mod mod, string name, PlayerLayer parent, LayerFunction layer) : this(mod, name, layer) {
			Parent = parent;
		}

		public override void Setup(Player drawPlayer, IReadOnlyList<PlayerLayer> layers, ref int index) {
		}

		public override void Draw(ref PlayerDrawSet drawInfo) => Layer(ref drawInfo);
	}
}
