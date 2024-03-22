using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace FEI.Recipes
{
    public class Golds : ModSystem
    {
        public override void AddRecipeGroups()
        {
            RecipeGroup recipeGroup = new RecipeGroup(() => "金或铂金", 
                new int[]
                {
            ItemID.GoldBar, //金
            ItemID.PlatinumBar //铂金
                });
            recipeGroup.IconicItemId = ItemID.GoldBar; //这是合成组显示的贴图是哪个物品
            RecipeGroup.RegisterGroup("GoldOrPlatinum", recipeGroup);//向游戏注册这个合成组，这里的名字也是之后使用合成组的文字索引
        }
    }
}
