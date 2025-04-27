using BridgeWE;
using Colossal.Entities;
using Game.Buildings;
using Game.Companies;
using Unity.Entities;

namespace K45WE_GasStationPylonPrices
{
    public static class FnLibrary
    {
        private readonly static EntityManager em = World.DefaultGameObjectInjectionWorld.EntityManager;

        public static DynamicBuffer<TradeCost> GetSellingProducts(Entity src)
            => em.TryGetBuffer(src, true, out DynamicBuffer<Renter> renters)
            && renters.Length > 0
            && em.TryGetBuffer(renters[0].m_Renter, true, out DynamicBuffer<TradeCost> trades)
                ? trades
                : default;

        public static string ToFormattedPrice(float price) => price <= 0 ? "-----" : WENumberFormattingFn.To4DigitsValue(price);
    }
}
