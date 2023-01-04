using System;
using System.Collections.Generic;
using Xunit;

namespace DemoDesign.其他
{
    public class 多态优化
    {
        [Fact]
        public void Test()
        {
            MedalServiceFactory.GetMedalService("vip").showMedal();
        }

        class MedalServiceFactory
        {
            private static Dictionary<string, IMedalService> dict = new Dictionary<string, IMedalService>();
            static MedalServiceFactory()
            {
                dict.Add("guest", new GuestMedalService());
                dict.Add("vip", new VipMedalService());
            }

            public static IMedalService GetMedalService(string medalType)
            {
                return dict[medalType];
            }
        }

        interface IMedalService
        {
            void showMedal();
        }

        class GuestMedalService : IMedalService
        {
            public void showMedal()
            {
                Console.WriteLine("展示嘉宾勋章");
            }
        }

        class VipMedalService : IMedalService
        {
            public void showMedal()
            {
                Console.WriteLine("展示会员勋章");
            }
        }
    }
}
